using IssueTracker.Models;
using IssueTracker.Models.Enums;
using Microsoft.Extensions.Configuration;

namespace IssueTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();
        private readonly IConfiguration _configuration;

        public TicketService(IConfiguration configuration)
        {
            _configuration = configuration;
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

        public List<string> GetTicketTypes() =>
            _configuration.GetSection("TicketTypes").Get<List<string>>();

        public List<Ticket> FilterTickets(
            List<Status> statuses,
            DateTime? fromDate,
            DateTime? toDate,
            string type,
            TicketCategory? category
        )
        {
            return _tickets
                .Where(t => statuses.Contains(t.Status))
                .Where(t => !fromDate.HasValue || t.CreatedDate >= fromDate.Value)
                .Where(t => !toDate.HasValue || t.CreatedDate <= toDate.Value)
                .Where(t => string.IsNullOrEmpty(type) || t.Type == type)
                .Where(t => !category.HasValue || t.Category == category.Value)
                .ToList();
        }
    }
}
