using Microsoft.Data.Sqlite;

namespace IssueTracker.Services.Database
{
    public sealed class SqliteDatabaseService : IDatabaseService, IDisposable
    {
        private AppSettings _appSettings;
        private readonly string _connectionString;
        private SqliteConnection? _connection;
        private SqliteTransaction? _transaction;

        public SqliteDatabaseService(AppSettings appSettings)
        {
            _appSettings = appSettings;
            _connectionString = _appSettings.ConnectionStrings.SQLite!;
        }

        private async Task EnsureConnectionOpenAsync()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection(_connectionString);
                await _connection.OpenAsync();
            }
        }

        public async Task ExecuteNonQueryAsync(string sql, params SqliteParameter[] parameters)
        {
            await EnsureConnectionOpenAsync();
            using var command = new SqliteCommand(sql, _connection, _transaction);
            command.Parameters.AddRange(parameters);
            await command.ExecuteNonQueryAsync();
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, params SqliteParameter[] parameters)
        {
            await EnsureConnectionOpenAsync();
            using var command = new SqliteCommand(sql, _connection, _transaction);
            command.Parameters.AddRange(parameters);
            var result = await command.ExecuteScalarAsync();
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(
            string sql,
            Func<SqliteDataReader, T> mapper,
            params SqliteParameter[] parameters)
        {
            await EnsureConnectionOpenAsync();
            using var command = new SqliteCommand(sql, _connection, _transaction);
            command.Parameters.AddRange(parameters);

            var results = new List<T>();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                results.Add(mapper(reader));
            }
            return results;
        }

        public async Task BeginTransactionAsync()
        {
            await EnsureConnectionOpenAsync();
            _transaction = _connection!.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No active transaction.");

            await _transaction.CommitAsync();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No active transaction.");

            await _transaction.RollbackAsync();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
