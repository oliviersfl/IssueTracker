using IssueTracker.Services.Interfaces;
using Microsoft.Data.Sqlite;

namespace IssueTracker.Services
{
    public class DatabaseBackupService : IDatabaseBackupService
    {
        private readonly TimeSpan _minimumBackupInterval;

        public DatabaseBackupService(TimeSpan minimumBackupInterval)
        {
            _minimumBackupInterval = minimumBackupInterval;
        }

        public DatabaseBackupService() : this(TimeSpan.FromHours(1))
        {
        }

        public string CreateBackup(string dbPath, string destinationPath, int backupCount, string backupExtension = ".backup")
        {
            if (!CanCreateBackup(destinationPath, backupExtension))
            {
                return null;
            }

            ValidateParameters(dbPath, destinationPath, backupCount);

            try
            {
                Directory.CreateDirectory(destinationPath);
                string backupFileName = GenerateBackupFileName(dbPath, backupExtension);
                string backupFilePath = Path.Combine(destinationPath, backupFileName);

                CreateSqliteBackup(dbPath, backupFilePath);
                CleanupOldBackups(destinationPath, backupCount, backupExtension);

                return backupFilePath;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Backup failed: {ex.Message}", ex);
            }
        }

        public string ForceCreateBackup(string dbPath, string destinationPath, int backupCount, string backupExtension = ".backup")
        {
            ValidateParameters(dbPath, destinationPath, backupCount);

            try
            {
                Directory.CreateDirectory(destinationPath);
                string backupFileName = GenerateBackupFileName(dbPath, backupExtension);
                string backupFilePath = Path.Combine(destinationPath, backupFileName);

                CreateSqliteBackup(dbPath, backupFilePath);
                CleanupOldBackups(destinationPath, backupCount, backupExtension);

                return backupFilePath;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Forced backup failed: {ex.Message}", ex);
            }
        }

        public bool CanCreateBackup(string destinationPath, string backupExtension = ".backup")
        {
            var lastBackupTime = GetLastBackupTime(destinationPath, backupExtension);
            return DateTime.Now - lastBackupTime >= _minimumBackupInterval;
        }

        public TimeSpan GetTimeUntilNextBackup(string destinationPath, string backupExtension = ".backup")
        {
            var lastBackupTime = GetLastBackupTime(destinationPath, backupExtension);
            var timeSinceLastBackup = DateTime.Now - lastBackupTime;
            return timeSinceLastBackup >= _minimumBackupInterval ? TimeSpan.Zero : _minimumBackupInterval - timeSinceLastBackup;
        }

        public DateTime GetLastBackupTime(string destinationPath, string backupExtension = ".backup")
        {
            if (!Directory.Exists(destinationPath))
                return DateTime.MinValue;

            var backupFiles = Directory.GetFiles(destinationPath, $"*{backupExtension}");
            if (backupFiles.Length == 0)
                return DateTime.MinValue;

            // Get the most recent backup file creation time
            var latestBackup = backupFiles
                .Select(file => new FileInfo(file))
                .OrderByDescending(fi => fi.CreationTime)
                .FirstOrDefault();

            return latestBackup?.CreationTime ?? DateTime.MinValue;
        }

        public List<BackupInfo> GetBackupInfo(string destinationPath, string backupExtension = ".backup")
        {
            var backups = new List<BackupInfo>();

            if (!Directory.Exists(destinationPath))
                return backups;

            var backupFiles = Directory.GetFiles(destinationPath, $"*{backupExtension}")
                .Select(file => new FileInfo(file))
                .OrderByDescending(fi => fi.CreationTime);

            foreach (var file in backupFiles)
            {
                backups.Add(new BackupInfo
                {
                    FileName = file.Name,
                    FullPath = file.FullName,
                    CreationTime = file.CreationTime,
                    Size = file.Length,
                    LastWriteTime = file.LastWriteTime,
                    IsValid = IsValidBackupFile(file.FullName)
                });
            }

            return backups;
        }

        public TimeSpan GetMinimumBackupInterval() => _minimumBackupInterval;

        private void ValidateParameters(string dbPath, string destinationPath, int backupCount)
        {
            if (string.IsNullOrEmpty(dbPath))
                throw new ArgumentException("Database path cannot be null or empty", nameof(dbPath));

            if (string.IsNullOrEmpty(destinationPath))
                throw new ArgumentException("Destination path cannot be null or empty", nameof(destinationPath));

            if (backupCount <= 0)
                throw new ArgumentException("Backup count must be greater than 0", nameof(backupCount));

            if (!File.Exists(dbPath))
                throw new FileNotFoundException($"Database file not found: {dbPath}");

            if (!IsValidSqliteDatabase(dbPath))
                throw new InvalidOperationException($"File is not a valid SQLite database: {dbPath}");
        }

        private bool IsValidSqliteDatabase(string dbPath)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={dbPath}"))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' LIMIT 1;";
                        command.ExecuteScalar();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidBackupFile(string backupFilePath)
        {
            try
            {
                // Quick check if file exists and has reasonable size
                var fileInfo = new FileInfo(backupFilePath);
                if (!fileInfo.Exists || fileInfo.Length == 0)
                    return false;

                // Optional: Add more validation if needed
                // For example, check if it's a valid SQLite file
                return IsValidSqliteDatabase(backupFilePath);
            }
            catch
            {
                return false;
            }
        }

        private string GenerateBackupFileName(string dbPath, string backupExtension)
        {
            string dbName = Path.GetFileNameWithoutExtension(dbPath);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{dbName}_{timestamp}{backupExtension}";
        }

        private void CreateSqliteBackup(string sourceDbPath, string backupFilePath)
        {
            // Use file copy for backup
            File.Copy(sourceDbPath, backupFilePath, overwrite: true);

            // Optional: Set the creation time to current time explicitly
            File.SetCreationTime(backupFilePath, DateTime.Now);
            File.SetLastWriteTime(backupFilePath, DateTime.Now);
        }

        private void CleanupOldBackups(string destinationPath, int backupCount, string backupExtension)
        {
            try
            {
                var backupFiles = Directory.GetFiles(destinationPath, $"*{backupExtension}")
                    .Select(file => new FileInfo(file))
                    .OrderByDescending(fi => fi.CreationTime)
                    .ToList();

                if (backupFiles.Count > backupCount)
                {
                    var filesToDelete = backupFiles.Skip(backupCount);
                    foreach (var file in filesToDelete)
                    {
                        try
                        {
                            File.Delete(file.FullName);
                        }
                        catch
                        {
                            // Continue with other files if one fails to delete
                        }
                    }
                }
            }
            catch
            {
                // Silently fail cleanup
            }
        }
    }

    public class BackupInfo
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public long Size { get; set; }
        public bool IsValid { get; set; }
    }
}
