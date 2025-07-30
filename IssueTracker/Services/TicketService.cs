using IssueTracker.Models;
using IssueTracker.Models.Enums;

namespace IssueTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();
        private readonly AppSettings _appSettings;

        public TicketService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public List<Ticket> GetAllTickets() => _tickets;

        public Ticket GetTicketById(int id) => _tickets.FirstOrDefault(t => t.Id == id);

        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            // Implementation will go here
        }

        public void DeleteTicket(int id)
        {
            // Implementation will go here
        }

        public void ClearTickets()
        {
            _tickets.Clear();
        }

        public List<string> GetTicketTypes() =>
            _appSettings.TicketTypes;

        public List<Ticket> FilterTickets(
            List<string> statuses,
            DateTime? fromDate,
            DateTime? toDate,
            string type,
            string category
        )
        {
            return _tickets
                .Where(t => statuses.Contains(t.Status))
                .Where(t => !fromDate.HasValue || t.CreatedDate >= fromDate.Value)
                .Where(t => !toDate.HasValue || t.CreatedDate <= toDate.Value)
                .Where(t => string.IsNullOrEmpty(type) || t.Type == type)
                .Where(t => string.IsNullOrEmpty(category) || t.Category == category)
                .ToList();
        }
    }
}
