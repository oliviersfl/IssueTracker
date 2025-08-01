using IssueTracker.Models;

namespace IssueTracker.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        Task<List<TicketCategory>> GetTicketCategories();
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
        void ClearTickets();
        List<string> GetTicketTypes();
        List<Ticket> FilterTickets(
            List<string> statuses,
            DateTime? fromDate,
            DateTime? toDate,
            string type,
            string category
        );
    }
}
