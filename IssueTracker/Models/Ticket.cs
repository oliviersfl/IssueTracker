namespace IssueTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
        public List<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<DateTime> ModificationDates { get; set; } = new List<DateTime>();

        // Snapshot of values before the current save — used by UpdateTicket() for audit diffing
        public string PreviousTitle { get; set; }
        public string PreviousDescription { get; set; }
        public string PreviousStatus { get; set; }
        public string PreviousPriority { get; set; }
        public string PreviousCategory { get; set; }
        public string PreviousType { get; set; }
        public DateTime? PreviousDueDate { get; set; }

        public int PendingSubTasksCount => SubTasks.Count(st => !st.IsCompleted);
    }
}