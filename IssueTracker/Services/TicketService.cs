using IssueTracker.Models;
using IssueTracker.Services.Database.Repository.Interfaces;

namespace IssueTracker.Services
{
    public class TicketService : ITicketService
    {
        private readonly List<Ticket> _tickets = new List<Ticket>();
        private ITicketRepository _ticketRepository;
        private readonly AppSettings _appSettings;

        public TicketService(AppSettings appSettings, ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
            _appSettings = appSettings;
        }
        #region Get Methods
        public List<Ticket> GetAllTickets() => _tickets;
        public Ticket GetTicketById(int id) => _tickets.FirstOrDefault(t => t.Id == id);
        public async Task<List<TicketCategory>> GetTicketCategories()
        {
            var categories = await _ticketRepository.GetAllCategoriesAsync();

            return categories.Select(c => new TicketCategory
            {
                Id = c.Id,
                Description = c.Description,
                Order = c.Order,
                IsDefault = c.IsDefault,
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate
            }).ToList();
        }
        public async Task<List<TicketType>> GetTicketTypes()
        {
            var types = await _ticketRepository.GetAllTypesAsync();

            return types.Select(t => new TicketType
            {
                Id = t.Id,
                Description = t.Description,
                Order = t.Order,
                IsDefault = t.IsDefault,
                CreatedDate = t.CreatedDate,
                ModifiedDate = t.ModifiedDate
            }).ToList();
        }

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
        #endregion
        #region Add/Update/Delete
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
        #endregion
    }
}
