using Microsoft.Data.Sqlite;

namespace IssueTracker.Services.Database
{
    public sealed class SqliteDatabaseInitializer : IDatabaseInitializer
    {
        private AppSettings _appSettings;
        private readonly IDatabaseService _db;

        public SqliteDatabaseInitializer(
            IDatabaseService db,
            AppSettings appSettings
        )
        {
            _db = db;
            _appSettings = appSettings;
        }

        public async Task InitializeAsync()
        {
            var dbPath = new SqliteConnectionStringBuilder("Data Source=" + _appSettings.Database.DbPath!).DataSource;
            if (!File.Exists(dbPath))
            {
                await ExecuteScriptAsync("Schema.sql");

                if (_appSettings.Database.SeedSampleData)
                    await ExecuteScriptAsync("SeedData.sql");
            }

            // Always run all migration scripts in alphabetical order (idempotent).
            // New migrations are picked up automatically — no code change needed here.
            var scriptsFolder = _appSettings.Database.ScriptsFolder;
            if (Directory.Exists(scriptsFolder))
            {
                var migrations = Directory.GetFiles(scriptsFolder, "Migration_*.sql")
                    .OrderBy(f => Path.GetFileName(f))
                    .ToList();

                foreach (var migration in migrations)
                {
                    await ExecuteScriptAsync(Path.GetFileName(migration));
                }
            }
        }

        private async Task ExecuteScriptAsync(string scriptName)
        {
            var scriptPath = Path.Combine(_appSettings.Database.ScriptsFolder, scriptName);
            if (!File.Exists(scriptPath))
            {
                return;
            }

            var scriptContent = await File.ReadAllTextAsync(scriptPath);
            await _db.ExecuteNonQueryAsync(scriptContent);
        }
    }
}