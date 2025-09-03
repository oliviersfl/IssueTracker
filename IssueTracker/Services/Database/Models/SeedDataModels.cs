namespace IssueTracker.Services.Database.Models
{
    public class SeedData
    {
        public List<CategorySeed> TicketCategories { get; set; } = new();
        public List<PrioritySeed> TicketPriorities { get; set; } = new();
        public List<TypeSeed> TicketTypes { get; set; } = new();
        public List<StatusSeed> TicketStatuses { get; set; } = new();
        public List<TicketSeed> Tickets { get; set; } = new();
        public List<CommentSeed> TicketComments { get; set; } = new();
        public List<SubTaskSeed> TicketSubTasks { get; set; } = new();
    }

    public class CategorySeed
    {
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDefault { get; set; }
    }

    public class PrioritySeed
    {
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDefault { get; set; }
    }

    public class TypeSeed
    {
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDefault { get; set; }
    }

    public class StatusSeed
    {
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDefault { get; set; }
    }

    public class TicketSeed
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int PriorityId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
    }

    public class CommentSeed
    {
        public int TicketId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }

    public class SubTaskSeed
    {
        public int TicketId { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
