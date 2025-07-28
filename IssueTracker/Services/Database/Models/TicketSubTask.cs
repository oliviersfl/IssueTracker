namespace IssueTracker.Services.Database.Models
{
    public class TicketSubTask
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
