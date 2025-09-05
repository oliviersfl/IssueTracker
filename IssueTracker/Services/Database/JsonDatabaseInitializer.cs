using IssueTracker.Services.Database.Models;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace IssueTracker.Services.Database
{
    public sealed class JsonDatabaseInitializer : IDatabaseInitializer
    {
        private readonly AppSettings _appSettings;
        private readonly IDatabaseService _db;

        public JsonDatabaseInitializer(
            IDatabaseService db,
            AppSettings appSettings)
        {
            _db = db;
            _appSettings = appSettings;
        }

        public async Task InitializeAsync()
        {
            var dbPath = _appSettings.Database.DbPath;
            if (string.IsNullOrEmpty(dbPath))
            {
                throw new InvalidOperationException("Database path is not configured");
            }

            var directoryPath = Path.GetDirectoryName(dbPath);
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }


            if (!File.Exists(dbPath))
            {
                await ExecuteScriptAsync("Schema.sql");

                if (_appSettings.Database.SeedSampleData)
                    await SeedFromJsonAsync();
            }
        }

        private async Task SeedFromJsonAsync()
        {
            var jsonPath = Path.Combine(_appSettings.Database.ScriptsFolder, "seed-data.json");
            if (!File.Exists(jsonPath))
            {
                return;
            }

            var jsonContent = await File.ReadAllTextAsync(jsonPath);
            var seedData = JsonSerializer.Deserialize<SeedData>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (seedData == null)
            {
                return;
            }

            try
            {
                await _db.BeginTransactionAsync();

                // Insert categories
                foreach (var category in seedData.TicketCategories)
                {
                    await _db.ExecuteNonQueryAsync(
                        "INSERT INTO TicketCategory (description, \"order\", isDefault) VALUES (@Description, @Order, @IsDefault)",
                        new SqliteParameter("@Description", category.Description),
                        new SqliteParameter("@Order", category.Order),
                        new SqliteParameter("@IsDefault", category.IsDefault ? 1 : 0));
                }

                // Insert priorities
                foreach (var priority in seedData.TicketPriorities)
                {
                    await _db.ExecuteNonQueryAsync(
                        "INSERT INTO TicketPriority (description, \"order\", isDefault) VALUES (@Description, @Order, @IsDefault)",
                        new SqliteParameter("@Description", priority.Description),
                        new SqliteParameter("@Order", priority.Order),
                        new SqliteParameter("@IsDefault", priority.IsDefault ? 1 : 0));
                }

                // Insert types
                foreach (var type in seedData.TicketTypes)
                {
                    await _db.ExecuteNonQueryAsync(
                        "INSERT INTO TicketType (description, \"order\", isDefault) VALUES (@Description, @Order, @IsDefault)",
                        new SqliteParameter("@Description", type.Description),
                        new SqliteParameter("@Order", type.Order),
                        new SqliteParameter("@IsDefault", type.IsDefault ? 1 : 0));
                }

                // Insert statuses
                foreach (var status in seedData.TicketStatuses)
                {
                    await _db.ExecuteNonQueryAsync(
                        "INSERT INTO TicketStatus (description, \"order\", isDefault) VALUES (@Description, @Order, @IsDefault)",
                        new SqliteParameter("@Description", status.Description),
                        new SqliteParameter("@Order", status.Order),
                        new SqliteParameter("@IsDefault", status.IsDefault ? 1 : 0));
                }

                // Insert tickets
                foreach (var ticket in seedData.Tickets)
                {
                    await _db.ExecuteNonQueryAsync(
                        @"INSERT INTO Ticket (title, description, categoryid, priorityid, typeid, statusid) 
                      VALUES (@Title, @Description, @CategoryId, @PriorityId, @TypeId, @StatusId)",
                        new SqliteParameter("@Title", ticket.Title),
                        new SqliteParameter("@Description", ticket.Description),
                        new SqliteParameter("@CategoryId", ticket.CategoryId),
                        new SqliteParameter("@PriorityId", ticket.PriorityId),
                        new SqliteParameter("@TypeId", ticket.TypeId),
                        new SqliteParameter("@StatusId", ticket.StatusId));
                }

                // Insert comments
                foreach (var comment in seedData.TicketComments)
                {
                    await _db.ExecuteNonQueryAsync(
                        "INSERT INTO TicketComment (ticketid, author, text) VALUES (@TicketId, @Author, @Text)",
                        new SqliteParameter("@TicketId", comment.TicketId),
                        new SqliteParameter("@Author", comment.Author),
                        new SqliteParameter("@Text", comment.Text));
                }

                // Insert subtasks
                foreach (var subtask in seedData.TicketSubTasks)
                {
                    await _db.ExecuteNonQueryAsync(
                        "INSERT INTO TicketSubTask (ticketid, title, isCompleted) VALUES (@TicketId, @Title, @IsCompleted)",
                        new SqliteParameter("@TicketId", subtask.TicketId),
                        new SqliteParameter("@Title", subtask.Title),
                        new SqliteParameter("@IsCompleted", subtask.IsCompleted ? 1 : 0));
                }

                await _db.CommitAsync();
            }
            catch
            {
                await _db.RollbackAsync();
                throw;
            }
        }

        private async Task ExecuteScriptAsync(string scriptName)
        {
            var scriptPath = Path.Combine(_appSettings.Database.ScriptsFolder, scriptName);
            if (!File.Exists(scriptPath))
            {
                return;
            }

            var scriptContent = await File.ReadAllTextAsync(scriptPath);
            await _db.ExecuteNonQueryAsync(scriptContent);
        }
    }
}
