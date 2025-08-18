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

        public async Task<List<SubTask>> GetTicketSubTasksByTicketId(int ticketId)
        {
            // Get all subtasks for the given ticket from the repository
            var dbSubTasks = await _ticketRepository.GetSubTasksByTicketIdAsync(ticketId);

            // Map database subtasks to service model subtasks
            var subTasks = dbSubTasks.Select(dbSubTask => new SubTask
            {
                Id = dbSubTask.Id,
                Title = dbSubTask.Title,
                IsCompleted = dbSubTask.IsCompleted
            }).ToList();

            return subTasks;
        }

        public async Task<List<Comment>> GetTicketCommentsByTicketId(int ticketId)
        {
            // Get all comments for the given ticket from the repository
            var dbComments = await _ticketRepository.GetCommentsByTicketIdAsync(ticketId);

            // Map database comments to service model comments
            var comments = dbComments.Select(dbComment => new Comment
            {
                Id = dbComment.Id,
                Author = dbComment.Author,
                Text = dbComment.Text,
                CreatedDate = dbComment.CreatedDate
            }).ToList();

            return comments;
        }

        private async Task UpdateComments(int ticketId, List<Comment> comments)
        {
            // Get existing comments from database
            var existingDbComments = await _ticketRepository.GetCommentsByTicketIdAsync(ticketId);

            // Identify comments to add, update, or delete
            var commentsToAdd = comments.Where(c => c.Id == 0).ToList();
            var commentsToUpdate = comments.Where(c => c.Id > 0).ToList();
            var commentIdsToDelete = existingDbComments
                .Where(dbC => !comments.Any(c => c.Id == dbC.Id))
                .Select(dbC => dbC.Id)
                .ToList();

            // Add new comments
            foreach (var comment in commentsToAdd)
            {
                var dbComment = new Database.Models.TicketComment
                {
                    TicketId = ticketId,
                    Author = comment.Author,
                    Text = comment.Text,
                    CreatedDate = comment.CreatedDate
                };
                await _ticketRepository.AddCommentAsync(ticketId, dbComment);
            }

            // Update existing comments
            foreach (var comment in commentsToUpdate)
            {
                var dbComment = new Database.Models.TicketComment
                {
                    Id = comment.Id,
                    TicketId = ticketId,
                    Author = comment.Author,
                    Text = comment.Text,
                    CreatedDate = comment.CreatedDate
                };
                await _ticketRepository.UpdateCommentAsync(ticketId, dbComment);
            }

            // Delete removed comments
            foreach (var commentId in commentIdsToDelete)
            {
                await _ticketRepository.DeleteCommentAsync(ticketId, commentId);
            }
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
        public async Task AddTicket(Ticket ticket)
        {
            // Get reference data for mapping
            var dbCategories = await _ticketRepository.GetAllCategoriesAsync();
            var dbTypes = await _ticketRepository.GetAllTypesAsync();
            var dbPriorities = await _ticketRepository.GetAllPrioritiesAsync();
            var dbStatuses = await _ticketRepository.GetAllStatusesAsync();

            // Map service model to database model with proper status handling
            var dbTicket = new Services.Database.Models.Ticket
            {
                Title = ticket.Title,
                Description = ticket.Description,
                CategoryId = dbCategories.FirstOrDefault(c => c.Description == ticket.Category)?.Id ?? 0,
                PriorityId = dbPriorities.FirstOrDefault(p => p.Description == ticket.Priority)?.Id ?? 0,
                TypeId = dbTypes.FirstOrDefault(t => t.Description == ticket.Type)?.Id ?? 0,
                StatusId = !string.IsNullOrEmpty(ticket.Status)
                    ? dbStatuses.FirstOrDefault(s => s.Description == ticket.Status)?.Id
                    : (int?)null,
                DueDate = ticket.DueDate,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            // Create ticket in database
            var newId = await _ticketRepository.CreateTicketAsync(dbTicket);

            // Add all comments to the new ticket
            foreach (var comment in ticket.Comments)
            {
                var dbComment = new Database.Models.TicketComment
                {
                    TicketId = newId,
                    Author = comment.Author,
                    Text = comment.Text,
                    CreatedDate = comment.CreatedDate
                };
                await _ticketRepository.AddCommentAsync(newId, dbComment);
            }

            // Add all subtasks to the new ticket
            foreach (var subTask in ticket.SubTasks)
            {
                var dbSubTask = new Database.Models.TicketSubTask
                {
                    TicketId = newId,
                    Title = subTask.Title,
                    IsCompleted = subTask.IsCompleted,
                    CreatedDate = DateTime.Now
                };
                await _ticketRepository.AddSubTaskAsync(newId, dbSubTask);
            }

            // Update the ticket with the new ID and add to local collection
            ticket.Id = newId;
            ticket.CreatedDate = dbTicket.CreatedDate;
            ticket.ModifiedDate = dbTicket.ModifiedDate;

            // Load fresh data from database to ensure consistency
            ticket.Comments = await GetTicketCommentsByTicketId(newId);
            ticket.SubTasks = await GetTicketSubTasksByTicketId(newId);

            _tickets.Add(ticket);
        }

        public async Task UpdateTicket(Ticket ticket)
        {
            // Get reference data for mapping
            var dbCategories = await _ticketRepository.GetAllCategoriesAsync();
            var dbTypes = await _ticketRepository.GetAllTypesAsync();
            var dbPriorities = await _ticketRepository.GetAllPrioritiesAsync();
            var dbStatuses = await _ticketRepository.GetAllStatusesAsync();

            // Map service model to database model with proper status handling
            var dbTicket = new Services.Database.Models.Ticket
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                CategoryId = dbCategories.FirstOrDefault(c => c.Description == ticket.Category)?.Id ?? 0,
                PriorityId = dbPriorities.FirstOrDefault(p => p.Description == ticket.Priority)?.Id ?? 0,
                TypeId = dbTypes.FirstOrDefault(t => t.Description == ticket.Type)?.Id ?? 0,
                StatusId = !string.IsNullOrEmpty(ticket.Status)
                    ? dbStatuses.FirstOrDefault(s => s.Description == ticket.Status)?.Id
                    : (int?)null,
                DueDate = ticket.DueDate,
                ModifiedDate = DateTime.Now
            };

            // Update ticket in database
            await _ticketRepository.UpdateTicketAsync(dbTicket);

            // Update comments in database
            await UpdateComments(ticket.Id, ticket.Comments);

            // Update subtasks in database
            await UpdateSubTasks(ticket.Id, ticket.SubTasks);

            // Update local ticket collection
            var existingTicket = _tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (existingTicket != null)
            {
                existingTicket.Title = ticket.Title;
                existingTicket.Description = ticket.Description;
                existingTicket.Category = ticket.Category;
                existingTicket.Priority = ticket.Priority;
                existingTicket.Type = ticket.Type;
                existingTicket.Status = ticket.Status;
                existingTicket.DueDate = ticket.DueDate;
                existingTicket.ModifiedDate = dbTicket.ModifiedDate;
                existingTicket.Comments = ticket.Comments;
                existingTicket.SubTasks = ticket.SubTasks;
            }
        }

        private async Task UpdateSubTasks(int ticketId, List<SubTask> subTasks)
        {
            // Get existing subtasks from database
            var existingDbSubTasks = await _ticketRepository.GetSubTasksByTicketIdAsync(ticketId);

            // Identify subtasks to add, update, or delete
            var subTasksToAdd = subTasks.Where(st => st.Id == 0).ToList();
            var subTasksToUpdate = subTasks.Where(st => st.Id > 0).ToList();
            var subTaskIdsToDelete = existingDbSubTasks
                .Where(dbSt => !subTasks.Any(st => st.Id == dbSt.Id))
                .Select(dbSt => dbSt.Id)
                .ToList();

            // Add new subtasks
            foreach (var subTask in subTasksToAdd)
            {
                var dbSubTask = new Database.Models.TicketSubTask
                {
                    TicketId = ticketId,
                    Title = subTask.Title,
                    IsCompleted = subTask.IsCompleted,
                    CreatedDate = DateTime.Now
                };
                await _ticketRepository.AddSubTaskAsync(ticketId, dbSubTask);
            }

            // Update existing subtasks
            foreach (var subTask in subTasksToUpdate)
            {
                var dbSubTask = new Database.Models.TicketSubTask
                {
                    Id = subTask.Id,
                    TicketId = ticketId,
                    Title = subTask.Title,
                    IsCompleted = subTask.IsCompleted
                };
                await _ticketRepository.UpdateSubTaskAsync(dbSubTask);
            }

            // Delete removed subtasks
            foreach (var subTaskId in subTaskIdsToDelete)
            {
                await _ticketRepository.DeleteSubTaskAsync(subTaskId);
            }
        }

        public async Task DeleteTicket(int id)
        {
            // Delete from database
            await _ticketRepository.DeleteTicketAsync(id);

            // Remove from local collection
            var ticket = _tickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                _tickets.Remove(ticket);
            }
        }
        public void ClearTickets()
        {
            _tickets.Clear();
        }
        #endregion
    }
}
