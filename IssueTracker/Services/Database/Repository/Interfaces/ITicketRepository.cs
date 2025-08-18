using IssueTracker.Services.Database.Models;
using Ticket = IssueTracker.Services.Database.Models.Ticket;
using TicketCategory = IssueTracker.Services.Database.Models.TicketCategory;
namespace IssueTracker.Services.Database.Repository.Interfaces
{
    public interface ITicketRepository
    {
        // Ticket operations
        Task<int> CreateTicketAsync(Ticket ticket);
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int id);

        // Category/Priority/Type operations
        Task<IEnumerable<TicketCategory>> GetAllCategoriesAsync();
        Task<IEnumerable<TicketPriority>> GetAllPrioritiesAsync();
        Task<IEnumerable<TicketType>> GetAllTypesAsync();
        Task<IEnumerable<TicketStatus>> GetAllStatusesAsync();

        // Subtask operations
        Task<int> AddSubTaskAsync(int ticketId, TicketSubTask subTask);
        Task<int> DeleteSubTaskAsync(int subtaskId);
        Task<IEnumerable<TicketSubTask>> GetSubTasksByTicketIdAsync(int ticketId);
        Task UpdateSubTaskAsync(TicketSubTask subTask);

        // Comment operations
        Task<int> AddCommentAsync(int ticketId, TicketComment comment);
        Task<int> UpdateCommentAsync(int ticketId, TicketComment comment);
        Task<int> DeleteCommentAsync(int ticketId, int commentId);
        Task<IEnumerable<TicketComment>> GetCommentsByTicketIdAsync(int ticketId);
    }
}
