namespace IssueTracker.Services.Database.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}