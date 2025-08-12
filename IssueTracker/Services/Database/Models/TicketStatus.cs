namespace IssueTracker.Services.Database.Models
{
    public class TicketStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
