public class ConnectionStrings
{
    private string _sQLite;
    public string SQLite
    {
        get => _sQLite;
        set => _sQLite = value;
    }

}


public class Database
{
    private string _dbPath;
    public string DbPath
    {
        get => _dbPath;
        set => _dbPath = value;
    }

    private bool _seedSampleData;
    public bool SeedSampleData
    {
        get => _seedSampleData;
        set => _seedSampleData = value;
    }

    private string _scriptsFolder;
    public string ScriptsFolder
    {
        get => _scriptsFolder;
        set => _scriptsFolder = value;
    }

    private string _backupDirectory;
    public string BackupDirectory
    {
        get => _backupDirectory;
        set => _backupDirectory = value;
    }

    private int _backupCount;
    public int BackupCount
    {
        get => _backupCount;
        set => _backupCount = value;
    }

    private int _backupHoursInterval;
    public int BackupHoursInterval
    {
        get => _backupHoursInterval;
        set => _backupHoursInterval = value;
    }

}


public class CellFormatting
{
    private int _dueDateWarningThresholdDays;
    public int DueDateWarningThresholdDays
    {
        get => _dueDateWarningThresholdDays;
        set => _dueDateWarningThresholdDays = value;
    }

    private int _modifiedDateStaleThresholdDays;
    public int ModifiedDateStaleThresholdDays
    {
        get => _modifiedDateStaleThresholdDays;
        set => _modifiedDateStaleThresholdDays = value;
    }

}


public class AppSettings
{
    private ConnectionStrings _connectionStrings;
    public ConnectionStrings ConnectionStrings
    {
        get => _connectionStrings;
        set => _connectionStrings = value;
    }

    private Database _database;
    public Database Database
    {
        get => _database;
        set => _database = value;
    }

    private string _exportPath;
    public string ExportPath
    {
        get => _exportPath;
        set => _exportPath = value;
    }

    private string _exportFileName;
    public string ExportFileName
    {
        get => _exportFileName + $"-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.xlsx";
        set => _exportFileName = value;
    }

    private CellFormatting _cellFormatting;
    public CellFormatting CellFormatting
    {
        get => _cellFormatting;
        set => _cellFormatting = value;
    }

}