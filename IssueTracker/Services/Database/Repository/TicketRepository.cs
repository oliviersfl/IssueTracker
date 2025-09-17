using IssueTracker.Services.Database.Models;
using IssueTracker.Services.Database.Repository.Interfaces;
using Microsoft.Data.Sqlite;

namespace IssueTracker.Services.Database.Repository
{
    // Inject and use
    public class TicketRepository : ITicketRepository
    {
        private readonly IDatabaseService _db;

        public TicketRepository(IDatabaseService db)
        {
            _db = db;
        }
        #region Get Methods
        // Get Tickets
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            const string sql = @"SELECT
	            t.id,
	            t.title,
	            t.description,
	            t.categoryid,
	            t.priorityid,
	            t.typeid,
	            t.statusid,
	            t.CreatedDate,
	            t.ModifiedDate,
	            DueDate
            FROM Ticket t
            INNER JOIN TicketStatus s ON t.statusid = s.id
            INNER JOIN TicketPriority p ON t.priorityid = p.id
            ORDER BY
	            s.""order"",
	            p.""order"" DESC,
	            t.ModifiedDate DESC";
            return await _db.QueryAsync(sql, MapTicket);
        }

        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Ticket WHERE id = @Id";
            var tickets = await _db.QueryAsync(sql, MapTicket,
                new SqliteParameter("@Id", id));

            return tickets.FirstOrDefault();
        }

        // --- Category/Priority/Type Methods ---
        public async Task<IEnumerable<TicketCategory>> GetAllCategoriesAsync()
        {
            const string sql = "SELECT * FROM TicketCategory ORDER BY \"order\"";
            return await _db.QueryAsync(sql, reader => new TicketCategory
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                Order = reader.GetInt32(2),
                IsDefault = reader.GetBoolean(3),
                CreatedDate = reader.GetDateTime(4),
                ModifiedDate = reader.GetDateTime(5)
            });
        }
        public async Task<IEnumerable<TicketPriority>> GetAllPrioritiesAsync()
        {
            const string sql = "SELECT * FROM TicketPriority ORDER BY \"order\"";
            return await _db.QueryAsync(sql, reader => new TicketPriority
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                Order = reader.GetInt32(2),
                IsDefault = reader.GetBoolean(3),
                CreatedDate = reader.GetDateTime(4),
                ModifiedDate = reader.GetDateTime(5)
            });
        }
        public async Task<IEnumerable<TicketType>> GetAllTypesAsync()
        {
            const string sql = "SELECT * FROM TicketType ORDER BY \"order\"";
            return await _db.QueryAsync(sql, reader => new TicketType
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                Order = reader.GetInt32(2),
                IsDefault = reader.GetBoolean(3),
                CreatedDate = reader.GetDateTime(4),
                ModifiedDate = reader.GetDateTime(5)
            });
        }
        public async Task<IEnumerable<TicketStatus>> GetAllStatusesAsync()
        {
            const string sql = "SELECT * FROM TicketStatus ORDER BY \"order\"";
            return await _db.QueryAsync(sql, reader => new TicketStatus
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                Order = reader.GetInt32(2),
                IsDefault = reader.GetBoolean(3),
                CreatedDate = reader.GetDateTime(4),
                ModifiedDate = reader.GetDateTime(5)
            });
        }
        // Subtask
        public async Task<IEnumerable<TicketSubTask>> GetSubTasksByTicketIdAsync(int ticketId)
        {
            const string sql = "SELECT * FROM TicketSubTask WHERE ticketid = @TicketId";
            return await _db.QueryAsync(sql, reader => new TicketSubTask
            {
                Id = reader.GetInt32(0),
                TicketId = reader.GetInt32(1),
                Title = reader.GetString(2),
                IsCompleted = reader.GetBoolean(3),
                CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(4), TimeZoneInfo.Local)
            }, new SqliteParameter("@TicketId", ticketId));
        }
        // Comments
        public async Task<IEnumerable<TicketComment>> GetCommentsByTicketIdAsync(int ticketId)
        {
            const string sql = "SELECT * FROM TicketComment WHERE ticketid = @TicketId ORDER BY CreatedDate";
            return await _db.QueryAsync(sql, reader => new TicketComment
            {
                Id = reader.GetInt32(0),
                TicketId = reader.GetInt32(1),
                Author = reader.GetString(2),
                Text = reader.GetString(3),
                CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(4), TimeZoneInfo.Local)
            }, new SqliteParameter("@TicketId", ticketId));
        }
        #endregion

        #region Create/Update
        public async Task<int> CreateTicketAsync(Ticket ticket)
        {
            const string sql = @"
            INSERT INTO Ticket (title, description, categoryid, priorityid, typeid, statusid, DueDate)
            VALUES (@Title, @Description, @CategoryId, @PriorityId, @TypeId, @StatusId, @DueDate);
            SELECT last_insert_rowid();";

            return await _db.ExecuteScalarAsync<int>(sql,
                new SqliteParameter("@Title", ticket.Title),
                new SqliteParameter("@Description", ticket.Description ?? (object)DBNull.Value),
                new SqliteParameter("@CategoryId", ticket.CategoryId),
                new SqliteParameter("@PriorityId", ticket.PriorityId),
                new SqliteParameter("@TypeId", ticket.TypeId),
                new SqliteParameter("@StatusId", ticket.StatusId),
                new SqliteParameter("@DueDate", ticket.DueDate ?? (object)DBNull.Value));
        }
        public async Task UpdateTicketAsync(Ticket ticket)
        {
            const string sql = @"
            UPDATE Ticket SET 
                title = @Title,
                description = @Description,
                categoryid = @CategoryId,
                priorityid = @PriorityId,
                typeid = @TypeId,
                statusid = @StatusId,
                DueDate = @DueDate,
                ModifiedDate = CURRENT_TIMESTAMP
            WHERE id = @Id";

            await _db.ExecuteNonQueryAsync(sql,
                new SqliteParameter("@Title", ticket.Title),
                new SqliteParameter("@Description", ticket.Description ?? (object)DBNull.Value),
                new SqliteParameter("@CategoryId", ticket.CategoryId),
                new SqliteParameter("@PriorityId", ticket.PriorityId),
                new SqliteParameter("@TypeId", ticket.TypeId),
                new SqliteParameter("@StatusId", ticket.StatusId),
                new SqliteParameter("@DueDate", ticket.DueDate ?? (object)DBNull.Value),
                new SqliteParameter("@Id", ticket.Id));
        }
        // --- Subtask Methods ---
        public async Task<int> AddSubTaskAsync(int ticketId, TicketSubTask subTask)
        {
            const string sql = @"
            INSERT INTO TicketSubTask (ticketid, title, isCompleted)
            VALUES (@TicketId, @Title, @IsCompleted);
            SELECT last_insert_rowid();";

            return await _db.ExecuteScalarAsync<int>(sql,
                new SqliteParameter("@TicketId", ticketId),
                new SqliteParameter("@Title", subTask.Title),
                new SqliteParameter("@IsCompleted", subTask.IsCompleted));
        }
        public async Task UpdateSubTaskAsync(TicketSubTask subTask)
        {
            const string sql = @"
            UPDATE TicketSubTask SET 
                title = @Title,
                isCompleted = @IsCompleted
            WHERE id = @Id";

            await _db.ExecuteNonQueryAsync(sql,
                new SqliteParameter("@Title", subTask.Title),
                new SqliteParameter("@IsCompleted", subTask.IsCompleted),
                new SqliteParameter("@Id", subTask.Id));
        }
        public async Task<int> DeleteSubTaskAsync(int subTaskId)
        {
            const string sql = @"
            DELETE FROM TicketSubTask 
            WHERE id = @SubTaskId;
            SELECT changes();";  // Returns number of rows deleted

            return await _db.ExecuteScalarAsync<int>(sql,
                new SqliteParameter("@SubTaskId", subTaskId));
        }
        // --- Comment Methods ---
        public async Task<int> AddCommentAsync(int ticketId, TicketComment comment)
        {
            const string sql = @"
            INSERT INTO TicketComment (ticketid, author, text)
            VALUES (@TicketId, @Author, @Text);
            SELECT last_insert_rowid();";

            return await _db.ExecuteScalarAsync<int>(sql,
                new SqliteParameter("@TicketId", ticketId),
                new SqliteParameter("@Author", comment.Author),
                new SqliteParameter("@Text", comment.Text));
        }
        public async Task<int> UpdateCommentAsync(int ticketId, TicketComment comment)
        {
            const string sql = @"
            UPDATE TicketComment SET 
                author = @Author,
                text = @Text
            WHERE id = @Id AND ticketid = @TicketId;
            SELECT changes();";  // Returns number of rows affected

            return await _db.ExecuteScalarAsync<int>(sql,
                new SqliteParameter("@Id", comment.Id),
                new SqliteParameter("@TicketId", ticketId),
                new SqliteParameter("@Author", comment.Author),
                new SqliteParameter("@Text", comment.Text));
        }
        public async Task<int> DeleteCommentAsync(int ticketId, int commentId)
        {
            const string sql = @"
            DELETE FROM TicketComment 
            WHERE id = @CommentId AND ticketid = @TicketId;
            SELECT changes();";  // Returns number of rows deleted

            return await _db.ExecuteScalarAsync<int>(sql,
                new SqliteParameter("@CommentId", commentId),
                new SqliteParameter("@TicketId", ticketId));
        }
        public async Task DeleteTicketAsync(int id)
        {
            // Using a transaction to ensure all related data is deleted
            await _db.BeginTransactionAsync();
            try
            {
                // Delete subtasks first (due to foreign key constraint)
                await _db.ExecuteNonQueryAsync(
                    "DELETE FROM TicketSubTask WHERE ticketid = @TicketId",
                    new SqliteParameter("@TicketId", id));

                // Delete comments
                await _db.ExecuteNonQueryAsync(
                    "DELETE FROM TicketComment WHERE ticketid = @TicketId",
                    new SqliteParameter("@TicketId", id));

                // Finally, delete the ticket
                await _db.ExecuteNonQueryAsync(
                    "DELETE FROM Ticket WHERE id = @Id",
                    new SqliteParameter("@Id", id));

                await _db.CommitAsync();
            }
            catch
            {
                await _db.RollbackAsync();
                throw;
            }
        }
        #endregion

        #region Helpers
        // --- Helper Methods ---
        private Ticket MapTicket(SqliteDataReader reader) => new()
        {
            Id = reader.GetInt32(0),
            Title = reader.GetString(1),
            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
            CategoryId = reader.GetInt32(3),
            PriorityId = reader.GetInt32(4),
            TypeId = reader.GetInt32(5),
            StatusId = reader.GetInt32(6),
            CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(7), TimeZoneInfo.Local),
            ModifiedDate = TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(8), TimeZoneInfo.Local),
            DueDate = reader.IsDBNull(9) ? (DateTime?)null : TimeZoneInfo.ConvertTimeFromUtc(reader.GetDateTime(9), TimeZoneInfo.Local)
        };
        #endregion
    }
}