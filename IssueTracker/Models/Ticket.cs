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
    }
}
