using IssueTracker.Models;
using IssueTracker.Models.Enums;

namespace IssueTracker.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
        void AddTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(int id);
        List<string> GetTicketTypes();
        List<Ticket> FilterTickets(
            List<Status> statuses,
            DateTime? fromDate,
            DateTime? toDate,
            string type,
            string category
        );
    }
}
