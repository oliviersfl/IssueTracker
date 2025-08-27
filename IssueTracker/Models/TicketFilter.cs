namespace IssueTracker.Models
{
    public class TicketFilter
    {
        public List<string> Category { get; set; }
        public List<string> Type { get; set; }
        public List<string> Status { get; set; }
        public DateTime? CreatedFromDate { get; set; }
        public DateTime? CreatedToDate { get; set; }
        public DateTime? ModifiedFromDate { get; set; }
        public DateTime? ModifiedToDate { get; set; }

        public TicketFilter()
        {
            Category = null; // Default to "All"
            Type = null;
            Status = null;
            CreatedFromDate = null;
            CreatedToDate = null;
            ModifiedFromDate = null;
            ModifiedToDate = null;
        }
    }
}
