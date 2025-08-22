using IssueTracker.Models;

namespace IssueTracker.Services.Interfaces
{
    public interface IExcelExportService
    {
        /// <summary>
        /// Exports a list of tickets to an Excel file and returns the data as a byte array
        /// </summary>
        /// <param name="tickets">The list of tickets to export</param>
        /// <returns>Excel file data as byte array</returns>
        byte[] ExportTicketsToExcel(List<Ticket> tickets);

        /// <summary>
        /// Exports a list of tickets to an Excel file and saves it to the specified file path
        /// </summary>
        /// <param name="tickets">The list of tickets to export</param>
        /// <param name="filePath">The path where the Excel file should be saved</param>
        void ExportTicketsToFile(List<Ticket> tickets, string filePath);
    }
}
