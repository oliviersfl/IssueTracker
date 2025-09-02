using ClosedXML.Excel;
using IssueTracker.Models;
using IssueTracker.Services.Interfaces;
namespace IssueTracker.Services
{
    public class ExcelExportService : IExcelExportService
    {
        public byte[] ExportTicketsToExcel(List<Ticket> tickets)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tickets");

                // Set headers with black background and white text
                var headerRow = worksheet.Row(1);
                headerRow.Style.Fill.BackgroundColor = XLColor.Black;
                headerRow.Style.Font.FontColor = XLColor.White;
                headerRow.Style.Font.Bold = true;

                string[] headers = { "Title", "Description", "Category", "Priority", "Type",
                   "Created Date", "Modified Date", "Status", "Comments" };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = headers[i];
                }

                // Set column widths and text wrapping for specific columns
                worksheet.Column(2).Width = 55; // Description column
                worksheet.Column(9).Width = 55; // Comment Text column

                // Set smaller widths for other columns
                worksheet.Column(1).Width = 35; // Title
                worksheet.Column(3).Width = 15; // Category
                worksheet.Column(4).Width = 12; // Priority
                worksheet.Column(5).Width = 20; // Type
                worksheet.Column(6).Width = 15; // Created Date
                worksheet.Column(7).Width = 15; // Modified Date
                worksheet.Column(8).Width = 22; // Status

                // Enable text wrapping for all cells
                worksheet.Columns().Style.Alignment.WrapText = true;

                // Set alignment to top for better appearance with wrapped text
                worksheet.Columns().Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

                // Populate data
                int row = 2;
                foreach (var ticket in tickets)
                {
                    if (ticket.Comments != null && ticket.Comments.Count > 0)
                    {
                        // First row with ticket info and first comment
                        worksheet.Cell(row, 1).Value = ticket.Title;
                        worksheet.Cell(row, 2).Value = ticket.Description.Replace("\r", "");
                        worksheet.Cell(row, 3).Value = ticket.Category;
                        worksheet.Cell(row, 4).Value = ticket.Priority;
                        worksheet.Cell(row, 5).Value = ticket.Type;
                        worksheet.Cell(row, 6).Value = ticket.CreatedDate;
                        worksheet.Cell(row, 7).Value = ticket.ModifiedDate;
                        worksheet.Cell(row, 8).Value = ticket.Status;

                        var firstComment = ticket.Comments[0];
                        worksheet.Cell(row, 9).Value = $"({firstComment.CreatedDate:yyyy-MM-dd HH:mm}):{Environment.NewLine}{firstComment.Text}";

                        row++;

                        // Additional comments (only comment column filled, others left empty)
                        for (int i = 1; i < ticket.Comments.Count; i++)
                        {
                            var comment = ticket.Comments[i];
                            worksheet.Cell(row, 9).Value = $"({comment.CreatedDate:yyyy-MM-dd HH:mm}):{Environment.NewLine}{comment.Text}";
                            row++;
                        }
                    }
                    else
                    {
                        // Ticket with no comments
                        worksheet.Cell(row, 1).Value = ticket.Title;
                        worksheet.Cell(row, 2).Value = ticket.Description.Replace("\r", "");
                        worksheet.Cell(row, 3).Value = ticket.Category;
                        worksheet.Cell(row, 4).Value = ticket.Priority;
                        worksheet.Cell(row, 5).Value = ticket.Type;
                        worksheet.Cell(row, 6).Value = ticket.CreatedDate;
                        worksheet.Cell(row, 7).Value = ticket.ModifiedDate;
                        worksheet.Cell(row, 8).Value = ticket.Status;
                        row++;
                    }

                    // Set row height to auto-adjust
                    worksheet.Rows(2, row - 1).Height = -1;
                }

                // Optional: Adjust row heights for better visibility
                worksheet.Rows(2, row - 1).AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public void ExportTicketsToFile(List<Ticket> tickets, string filePath)
        {
            // Get the directory path from the file path
            string directoryPath = Path.GetDirectoryName(filePath);

            // Check if directory exists and create it if it doesn't
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var excelData = ExportTicketsToExcel(tickets);
            File.WriteAllBytes(filePath, excelData);
        }
    }
}
