public class ConnectionStrings
{
    private string _sQLite;
    public string SQLite
    {
        get => _sQLite;
        set => _sQLite = value;
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

}