public class ConnectionStrings
{
    private string _sqlite;
    public string SQLite
    {
        get => _sqlite;
        set => _sqlite = value;
    }

}


public class Database
{
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

}


public class AppSettings
{
    private List<string> _ticketTypes;
    public List<string> TicketTypes
    {
        get => _ticketTypes;
        set => _ticketTypes = value;
    }

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

}

