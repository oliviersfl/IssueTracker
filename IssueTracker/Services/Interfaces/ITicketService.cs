using IssueTracker.Models;

namespace IssueTracker.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTickets();
        Ticket GetTicketById(int id);
        Task<List<TicketCategory>> GetTicketCategories();
        Task<List<TicketType>> GetTicketTypes();
        Task<List<TicketStatus>> GetTicketStatuses();
        Task<List<TicketPriority>> GetTicketPriorities();
        Task<List<SubTask>> GetTicketSubTasksByTicketId(int ticketId);
        Task<List<Comment>> GetTicketCommentsByTicketId(int ticketId);
        Task AddTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(int id);
        void ClearTickets();
        List<Ticket> FilterTickets(
            List<string> statuses,
            DateTime? fromDate,
            DateTime? toDate,
            string type,
            string category
        );
    }
}
