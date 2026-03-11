namespace IssueTracker.Models
{
    public class TicketAuditLog
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ChangeType { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
