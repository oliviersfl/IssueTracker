using IssueTracker.Models;
using IssueTracker.Services.Database.Repository.Interfaces;
using System.Threading.Tasks;

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
        public async Task<List<Ticket>> GetAllTickets()
        {
            // Get all database tickets
            var dbTickets = await _ticketRepository.GetAllTicketsAsync();

            // Get reference data for mapping
            var categories = await GetTicketCategories();
            var types = await GetTicketTypes();
            var priorities = await _ticketRepository.GetAllPrioritiesAsync();
            var statuses = await _ticketRepository.GetAllStatusesAsync();

            // Map database tickets to service model tickets
            var tickets = dbTickets.Select(dbTicket => new Models.Ticket
            {
                Id = dbTicket.Id,
                Title = dbTicket.Title,
                Description = dbTicket.Description,
                Category = categories.FirstOrDefault(c => c.Id == dbTicket.CategoryId)?.Description ?? "Unknown",
                Priority = priorities.FirstOrDefault(p => p.Id == dbTicket.PriorityId)?.Description ?? "Unknown",
                Type = types.FirstOrDefault(t => t.Id == dbTicket.TypeId)?.Description ?? "Unknown",
                Status = statuses.FirstOrDefault(s => s.Id == dbTicket.StatusId)?.Description ?? "Unknown",
                CreatedDate = dbTicket.CreatedDate,
                ModifiedDate = dbTicket.ModifiedDate,
                DueDate = dbTicket.DueDate,
                // TODO
                // SubTasks and Comments would need to be loaded separately if needed
                SubTasks = new List<SubTask>(),
                Comments = new List<Comment>()
            }).ToList();

            _tickets.Clear();
            _tickets.AddRange(tickets);

            return tickets;
        }
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

        public async Task<List<TicketStatus>> GetTicketStatuses()
        {
            var types = await _ticketRepository.GetAllStatusesAsync();

            return types.Select(t => new TicketStatus
            {
                Id = t.Id,
                Description = t.Description,
                Order = t.Order,
                CreatedDate = t.CreatedDate,
                ModifiedDate = t.ModifiedDate
            }).ToList();
        }

        public async Task<List<TicketPriority>> GetTicketPriorities()
        {
            var types = await _ticketRepository.GetAllPrioritiesAsync();

            return types.Select(t => new TicketPriority
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
