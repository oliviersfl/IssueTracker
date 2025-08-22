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
                worksheet.Column(2).Width = 50; // Description column
                worksheet.Column(9).Width = 50; // Comment Text column

                // Set smaller widths for other columns
                worksheet.Column(1).Width = 30; // Title
                worksheet.Column(3).Width = 15; // Category
                worksheet.Column(4).Width = 12; // Priority
                worksheet.Column(5).Width = 20; // Type
                worksheet.Column(6).Width = 18; // Created Date
                worksheet.Column(7).Width = 18; // Modified Date
                worksheet.Column(8).Width = 12; // Status

                // Enable text wrapping for all cells
                worksheet.Columns().Style.Alignment.WrapText = true;

                // Set alignment to top for better appearance with wrapped text
                worksheet.Columns().Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

                // Populate data
                int row = 2;
                foreach (var ticket in tickets)
                {
                    string commentText = string.Join(Environment.NewLine + Environment.NewLine,
                        ticket.Comments.ConvertAll(c =>
                            $"({c.CreatedDate:yyyy-MM-dd HH:mm}):{Environment.NewLine}{c.Text}"));

                    worksheet.Cell(row, 1).Value = ticket.Title;
                    worksheet.Cell(row, 2).Value = ticket.Description.Replace("\r", "");
                    worksheet.Cell(row, 3).Value = ticket.Category;
                    worksheet.Cell(row, 4).Value = ticket.Priority;
                    worksheet.Cell(row, 5).Value = ticket.Type;
                    worksheet.Cell(row, 6).Value = ticket.CreatedDate;
                    worksheet.Cell(row, 7).Value = ticket.ModifiedDate;
                    worksheet.Cell(row, 8).Value = ticket.Status;
                    worksheet.Cell(row, 9).Value = commentText;

                    // Set row height to auto-adjust to wrapped text
                    worksheet.Row(row).Height = -1; // -1 means auto-height

                    row++;
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
