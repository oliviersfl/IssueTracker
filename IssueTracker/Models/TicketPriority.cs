namespace IssueTracker.Models
{
    public class TicketPriority
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
