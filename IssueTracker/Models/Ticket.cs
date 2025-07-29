using IssueTracker.Models.Enums;

namespace IssueTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Priority Priority { get; set; }
        public string Type { get; set; } // From appsettings.json
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public List<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
