namespace IssueTracker.Models
{
    public class TicketFilter
    {
        public string Category { get; set; }

        // (We'll add other filter properties later as needed)
        // public List<string> Statuses { get; set; }
        // public string Type { get; set; }
        // etc...

        public TicketFilter()
        {
            Category = null; // Default to "All"
        }
    }
}
