namespace IssueTracker.Services
{
    public interface IDatabaseBackupService
    {
        string CreateBackup(string dbPath, string destinationPath, int backupCount, string backupExtension = ".backup");
        string ForceCreateBackup(string dbPath, string destinationPath, int backupCount, string backupExtension = ".backup");
        bool CanCreateBackup(string destinationPath, string backupExtension = ".backup");
        TimeSpan GetTimeUntilNextBackup(string destinationPath, string backupExtension = ".backup");
        List<BackupInfo> GetBackupInfo(string destinationPath, string backupExtension = ".backup");
        DateTime GetLastBackupTime(string destinationPath, string backupExtension = ".backup");
        TimeSpan GetMinimumBackupInterval();
    }
}
