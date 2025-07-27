using Microsoft.Data.Sqlite;

namespace IssueTracker.Services.Database
{
    public interface IDatabaseService
    {
        Task ExecuteNonQueryAsync(string sql, params SqliteParameter[] parameters);
        Task<T> ExecuteScalarAsync<T>(string sql, params SqliteParameter[] parameters);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, Func<SqliteDataReader, T> mapper, params SqliteParameter[] parameters);
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
