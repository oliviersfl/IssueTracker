namespace IssueTracker.Models
{
    public class TicketFilter
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public List<string> Status { get; set; }
        public DateTime? CreatedFromDate { get; set; }
        public DateTime? CreatedToDate { get; set; }

        public TicketFilter()
        {
            Category = null; // Default to "All"
            Type = null;
            Status = null;
            CreatedFromDate = null;
            CreatedToDate = null;
        }
    }
}
