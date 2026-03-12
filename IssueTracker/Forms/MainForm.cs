using System.Diagnostics;
using IssueTracker.Models;
using IssueTracker.Services.Database.Repository.Interfaces;
using IssueTracker.Services.Interfaces;

namespace IssueTracker
{
    public partial class MainForm : Form
    {
        private readonly ITicketService _ticketService;
        private readonly AppSettings _appSettings;
        private readonly IDatabaseBackupService _databaseBackupService;
        private readonly IExcelExportService _excelExportService;
        private readonly TicketFilter _currentFilter = new TicketFilter();
        private BindingSource _ticketsBindingSource = new BindingSource();

        private ITicketRepository _ticketRepo;
        private List<TicketStatus> _cachedStatuses = new List<TicketStatus>();

        public MainForm(
            AppSettings appSettings,
            IDatabaseBackupService databaseBackupService,
            ITicketService ticketService,
            ITicketRepository ticketRepository,
            IExcelExportService excelExportService
        )
        {
            _appSettings = appSettings;
            _databaseBackupService = databaseBackupService;
            _excelExportService = excelExportService;
            _ticketService = ticketService;
            _ticketRepo = ticketRepository;

            InitializeComponent();
            ConfigureUI();
            LoadTickets().Wait();
            ApplyDefaultFilters().Wait();

            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 300; // 300ms delay
            _searchTimer.Tick += SearchTimer_Tick;
        }
        private void ConfigureUI()
        {
            // Configure DataGridView
            dgvTickets.AutoGenerateColumns = false;
            dgvTickets.DataSource = _ticketsBindingSource;
            dgvTickets.CellFormatting += dgvTickets_CellFormatting;

            // Clear existing columns if any
            dgvTickets.Columns.Clear();

            // Add columns

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                MinimumWidth = 200
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Category",
                HeaderText = "Category",
                Width = 100
            });
            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Type",
                HeaderText = "Type",
                Width = 100
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Priority",
                HeaderText = "Priority",
                Width = 80
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 100
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "PendingSubTasksCount",
                HeaderText = "Pending Subtasks",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "N0"  // Number format with no decimals
                },
                MinimumWidth = 125
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CreatedDate",
                HeaderText = "Created",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "g",  // General date/time pattern (short time)
                    NullValue = "N/A"
                }
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ModifiedDate",
                HeaderText = "Modified",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "g",  // General date/time pattern (short time)
                    NullValue = "N/A"
                }
            });

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DueDate",
                HeaderText = "Due Date",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "d",  // Short date pattern
                    NullValue = "N/A"
                }
            });

            // Update ticket count
            UpdateTicketCount();

            #region Sorting
            foreach (DataGridViewColumn column in dgvTickets.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dgvTickets.ColumnHeaderMouseClick += (sender, e) =>
            {
                DataGridViewColumn column = dgvTickets.Columns[e.ColumnIndex];

                // Get the current data source
                if (_ticketsBindingSource.DataSource is List<Ticket> currentList)
                {
                    // Determine sort direction
                    SortOrder newSortDirection;

                    if (column.HeaderCell.SortGlyphDirection == SortOrder.None)
                    {
                        // First click on this column - sort ascending
                        newSortDirection = SortOrder.Ascending;
                    }
                    else if (column.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                    {
                        // Second click - sort descending
                        newSortDirection = SortOrder.Descending;
                    }
                    else
                    {
                        // Third click - back to ascending
                        newSortDirection = SortOrder.Ascending;
                    }

                    // Sort the list
                    List<Ticket> sortedTickets;

                    if (newSortDirection == SortOrder.Ascending)
                    {
                        sortedTickets = currentList
                            .OrderBy(t => GetPropertyValue(t, column.DataPropertyName))
                            .ToList();
                    }
                    else
                    {
                        sortedTickets = currentList
                            .OrderByDescending(t => GetPropertyValue(t, column.DataPropertyName))
                            .ToList();
                    }

                    // Update the data source
                    _ticketsBindingSource.DataSource = sortedTickets;

                    // Update sort glyph
                    column.HeaderCell.SortGlyphDirection = newSortDirection;

                    // Clear other sort glyphs
                    foreach (DataGridViewColumn col in dgvTickets.Columns)
                    {
                        if (col != column)
                            col.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
            };
            #endregion
        }

        public async Task LoadTickets()
        {
            _ticketService.ClearTickets();

            await _ticketService.GetAllTickets();

            _cachedStatuses = await _ticketService.GetTicketStatuses();

            var filteredTickets = _ticketService.FilterTickets(
                    _currentFilter.Status,
                    _currentFilter.CreatedFromDate,
                    _currentFilter.CreatedToDate,
                    _currentFilter.ModifiedFromDate,
                    _currentFilter.ModifiedToDate,
                    _currentFilter.Type,
                    _currentFilter.Category
                );

            _ticketsBindingSource.DataSource = filteredTickets;
            UpdateTicketCount();
            UpdateDashboard();

            dgvTickets.Refresh();
        }

        private void UpdateTicketCount()
        {
            lblTicketCount.Text = _ticketsBindingSource.Count.ToString();
        }

        private void UpdateDashboard()
        {
            // Compute stats from whatever is currently visible in the grid,
            // so the dashboard always reflects the active filter + search.
            var allTickets = _ticketsBindingSource.DataSource as List<Ticket> ?? new List<Ticket>();

            flpDashboardContent.SuspendLayout();
            flpDashboardContent.Controls.Clear();

            int panelWidth = flpDashboardContent.ClientSize.Width - flpDashboardContent.Padding.Horizontal - 4;

            // ── Helper factories ──────────────────────────────────────────
            Label MakeSectionHeader(string text)
            {
                return new Label
                {
                    Text = text,
                    AutoSize = false,
                    Width = panelWidth,
                    Height = 20,
                    Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(100, 100, 120),
                    Padding = new Padding(0, 6, 0, 2),
                    Margin = new Padding(0, 2, 0, 0)
                };
            }

            Label MakeTitleLabel()
            {
                return new Label
                {
                    Text = "📊  Dashboard",
                    AutoSize = false,
                    Width = panelWidth,
                    Height = 28,
                    Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(40, 40, 60),
                    Margin = new Padding(0, 0, 0, 4)
                };
            }

            Panel MakeDivider()
            {
                return new Panel
                {
                    Height = 1,
                    Width = panelWidth,
                    BackColor = Color.FromArgb(220, 220, 230),
                    Margin = new Padding(0, 4, 0, 4)
                };
            }

            Control MakeStatRow(string label, int count, Color dotColor)
            {
                var row = new Panel
                {
                    Width = panelWidth,
                    Height = 22,
                    Margin = new Padding(0, 1, 0, 1),
                    BackColor = Color.Transparent
                };

                // Coloured dot
                var dot = new Panel
                {
                    Width = 8,
                    Height = 8,
                    BackColor = dotColor,
                    Location = new Point(2, 7),
                    Tag = "dot"
                };
                // Make it round-ish
                dot.Region = new System.Drawing.Region(new System.Drawing.Rectangle(0, 0, 8, 8));

                var lblName = new Label
                {
                    Text = label,
                    AutoSize = false,
                    Width = panelWidth - 44,
                    Height = 20,
                    Location = new Point(16, 2),
                    Font = new Font("Segoe UI", 8.5f),
                    ForeColor = Color.FromArgb(50, 50, 70),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var lblCount = new Label
                {
                    Text = count.ToString(),
                    AutoSize = false,
                    Width = 28,
                    Height = 18,
                    Location = new Point(panelWidth - 30, 2),
                    Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = count > 0 ? dotColor : Color.FromArgb(180, 180, 190),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                row.Controls.AddRange(new Control[] { dot, lblName, lblCount });
                return row;
            }

            // ── Build content ─────────────────────────────────────────────
            flpDashboardContent.Controls.Add(MakeTitleLabel());
            flpDashboardContent.Controls.Add(MakeDivider());

            // By Status
            flpDashboardContent.Controls.Add(MakeSectionHeader("BY STATUS"));
            var byStatus = allTickets
                .GroupBy(t => t.Status ?? "Unknown")
                .OrderBy(g =>
                {
                    var match = _cachedStatuses.FirstOrDefault(s => s.Description == g.Key);
                    return match?.Order ?? int.MaxValue;
                })
                .ToList();

            // Assign colours cycling through a palette
            Color[] statusColors =
            {
                Color.FromArgb(70, 130, 180),   // SteelBlue
                Color.FromArgb(60, 179, 113),   // MediumSeaGreen
                Color.FromArgb(255, 165, 0),    // Orange
                Color.FromArgb(147, 112, 219),  // MediumPurple
                Color.FromArgb(220, 90, 90),    // Red
                Color.FromArgb(64, 164, 164),   // Teal
            };

            for (int i = 0; i < byStatus.Count; i++)
            {
                var g = byStatus[i];
                flpDashboardContent.Controls.Add(
                    MakeStatRow(g.Key, g.Count(), statusColors[i % statusColors.Length]));
            }

            flpDashboardContent.Controls.Add(MakeDivider());

            // By Priority
            flpDashboardContent.Controls.Add(MakeSectionHeader("BY PRIORITY"));
            var byPriority = allTickets
                .GroupBy(t => t.Priority ?? "Unknown")
                .OrderBy(g => g.Key)
                .ToList();

            Color[] priorityColors =
            {
                Color.FromArgb(220, 60, 60),    // High → Red
                Color.FromArgb(255, 165, 0),    // Medium → Orange
                Color.FromArgb(60, 179, 113),   // Low → Green
                Color.FromArgb(150, 150, 165),  // Fallback grey
            };

            // Map well-known priority names to fixed colours
            Color PriorityColor(string name) => name.ToLower() switch
            {
                "high" or "critical" or "urgent" => priorityColors[0],
                "medium" or "normal" => priorityColors[1],
                "low" or "minor" => priorityColors[2],
                _ => priorityColors[3]
            };

            foreach (var g in byPriority)
            {
                flpDashboardContent.Controls.Add(
                    MakeStatRow(g.Key, g.Count(), PriorityColor(g.Key)));
            }

            flpDashboardContent.Controls.Add(MakeDivider());

            // ── Date-based alerts ─────────────────────────────────────────
            flpDashboardContent.Controls.Add(MakeSectionHeader("DUE DATE"));

            var now = DateTime.Now;
            int overdue = allTickets.Count(t => t.DueDate.HasValue && t.DueDate.Value < now);
            int dueSoon = allTickets.Count(t => t.DueDate.HasValue
                && t.DueDate.Value >= now
                && (t.DueDate.Value - now).TotalDays <= _appSettings.CellFormatting.DueDateWarningThresholdDays);

            flpDashboardContent.Controls.Add(
                MakeStatRow("Overdue", overdue, Color.FromArgb(200, 60, 60)));
            flpDashboardContent.Controls.Add(
                MakeStatRow("Due soon", dueSoon, Color.FromArgb(70, 130, 180)));

            flpDashboardContent.ResumeLayout(true);
        }
        public async Task ApplyDefaultFilters()
        {
            var filters = await _ticketRepo.GetAllStatusesAsync();

            var statusesToInclude = filters.Where(s => s.IsDefault == true).Select(s => s.Description).ToList();
            _currentFilter.Status = statusesToInclude;

            List<Ticket> tickets = _ticketService.FilterTickets(statusesToInclude, null, null, null, null, null, null);

            _ticketsBindingSource.DataSource = tickets;

            UpdateTicketCount();
            UpdateDashboard();
        }

        // Used for sorting
        private object GetPropertyValue(Ticket ticket, string propertyName)
        {
            return propertyName switch
            {
                "Id" => ticket.Id,
                "Title" => ticket.Title,
                "Category" => ticket.Category,
                "Type" => ticket.Type,
                "Priority" => ticket.Priority,
                "Status" => ticket.Status,
                "CreatedDate" => ticket.CreatedDate,
                "ModifiedDate" => ticket.ModifiedDate,
                "DueDate" => ticket.DueDate,
                "PendingSubTasksCount" => ticket.PendingSubTasksCount,
                _ => throw new ArgumentException($"Unknown property: {propertyName}")
            };
        }
        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create regular backups
            _databaseBackupService.CreateBackup(
                dbPath: _appSettings.Database.DbPath,
                destinationPath: _appSettings.Database.BackupDirectory,
                backupCount: _appSettings.Database.BackupCount
            );
        }
        private async void btnCreateTicket_Click(object sender, EventArgs e)
        {
            var detailForm = new TicketDetailForm(_ticketService);
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                await LoadTickets(); // Refresh the list
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Pass the current category when opening the dialog
            var filterDialog = new FilterDialog(_ticketService, _currentFilter);

            if (filterDialog.ShowDialog() == DialogResult.OK)
            {
                // Update the stored category
                _currentFilter.Category = filterDialog.ResultFilter.Category;
                _currentFilter.Type = filterDialog.ResultFilter.Type;
                _currentFilter.Status = filterDialog.ResultFilter.Status;
                _currentFilter.CreatedFromDate = filterDialog.ResultFilter.CreatedFromDate;
                _currentFilter.CreatedToDate = filterDialog.ResultFilter.CreatedToDate;
                _currentFilter.ModifiedFromDate = filterDialog.ResultFilter.ModifiedFromDate;
                _currentFilter.ModifiedToDate = filterDialog.ResultFilter.ModifiedToDate;

                var filteredTickets = _ticketService.FilterTickets(
                    _currentFilter.Status,
                    _currentFilter.CreatedFromDate,
                    _currentFilter.CreatedToDate,
                    _currentFilter.ModifiedFromDate,
                    _currentFilter.ModifiedToDate,
                    _currentFilter.Type,
                    _currentFilter.Category // Use the updated value
                );

                _ticketsBindingSource.DataSource = filteredTickets;
            }
            UpdateTicketCount();
            UpdateDashboard();
        }
        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            // Reset to default state — same as initial app load
            txtSearch.Text = "";

            var defaultStatuses = await _ticketRepo.GetAllStatusesAsync();
            var defaultStatusFilter = defaultStatuses
                .Where(s => s.IsDefault == true)
                .Select(s => s.Description)
                .ToList();

            _currentFilter.Status = defaultStatusFilter;
            _currentFilter.Category = null;
            _currentFilter.Type = null;
            _currentFilter.CreatedFromDate = null;
            _currentFilter.CreatedToDate = null;
            _currentFilter.ModifiedFromDate = null;
            _currentFilter.ModifiedToDate = null;

            var tickets = _ticketService.FilterTickets(defaultStatusFilter, null, null, null, null, null, null);
            _ticketsBindingSource.DataSource = tickets;
            UpdateTicketCount();
            UpdateDashboard();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Get the search term and trim whitespace
            string searchTerm = txtSearch.Text.Trim().ToLower();
            var filteredTickets = _ticketService.FilterTickets(
                _currentFilter.Status,
                _currentFilter.CreatedFromDate,
                _currentFilter.CreatedToDate,
                _currentFilter.ModifiedFromDate,
                _currentFilter.ModifiedToDate,
                _currentFilter.Type,
                _currentFilter.Category
            );


            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredTickets = filteredTickets
                    .Where(t => t.Title.ToLower().Contains(searchTerm) ||
                                (!string.IsNullOrEmpty(t.Description) && t.Description.ToLower().Contains(searchTerm)))
                    .ToList();
            }
            _excelExportService.ExportTicketsToFile(
                filteredTickets,
                Path.Combine(_appSettings.ExportPath, _appSettings.ExportFileName)
            );

            OpenFileExplorerToLocation(_appSettings.ExportPath);
            MessageBox.Show("Excel Export Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Opens File Explorer to the specified directory path.
        /// </summary>
        /// <param name="path">The path to the directory to open.</param>
        private void OpenFileExplorerToLocation(string path)
        {
            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else if (File.Exists(path))
            {
                // If the path is a file, open File Explorer to its containing directory
                // and select the file.
                string argument = "/select,\"" + path + "\"";
                Process.Start("explorer.exe", argument);
            }
            else
            {
                // Handle the case where the path does not exist.
                // You might want to throw an exception, log an error, or inform the user.
                System.Console.WriteLine($"Error: The path '{path}' does not exist.");
            }
        }

        // Double-click event for ticket selection
        private async void dgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedTicket = (Ticket)_ticketsBindingSource[e.RowIndex];
                var detailForm = new TicketDetailForm(_ticketService, selectedTicket);

                var result = detailForm.ShowDialog();

                // Refresh if the ticket was saved (OK) or deleted (Abort)
                if (result == DialogResult.OK || result == DialogResult.Abort)
                {
                    await LoadTickets(); // Refresh the list

                    // If the ticket was deleted, clear the selection
                    if (result == DialogResult.Abort)
                    {
                        dgvTickets.ClearSelection();
                    }

                    txtSearch.Text = "";
                }
            }
        }
        private void dgvTickets_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var ticket = (Ticket)_ticketsBindingSource[e.RowIndex];
            string columnPropertyName = dgvTickets.Columns[e.ColumnIndex].DataPropertyName;

            // Check if this is the DueDate column
            if (columnPropertyName == "DueDate")
            {
                // Only proceed if DueDate has a value
                if (ticket.DueDate.HasValue)
                {
                    DateTime dueDate = ticket.DueDate.Value;
                    DateTime currentDate = DateTime.Now;

                    // Calculate the difference in days
                    double daysDifference = (dueDate - currentDate).TotalDays;

                    // Apply formatting if due date is within 4 days (including past due)
                    if (daysDifference <= _appSettings.CellFormatting.DueDateWarningThresholdDays && daysDifference >= 0)
                    {
                        // Due within 4 days
                        e.CellStyle.BackColor = Color.SkyBlue;
                        e.CellStyle.SelectionBackColor = Color.LightBlue;
                        e.CellStyle.SelectionForeColor = Color.Black;
                    }
                    else if (daysDifference < 0)
                    {
                        // Past due
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.SelectionBackColor = Color.IndianRed;
                    }
                }
            }
            // Check if this is the ModifiedDate column
            else if (columnPropertyName == "ModifiedDate")
            {
                DateTime modifiedDate = ticket.ModifiedDate;
                DateTime currentDate = DateTime.Now;

                // Calculate the difference in days
                double daysDifference = (currentDate - modifiedDate).TotalDays;

                if (daysDifference >= _appSettings.CellFormatting.ModifiedDateStaleThresholdDays)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Orange;
                }
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            // Restart the timer on each key press
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();

            // Get the search term and trim whitespace
            string searchTerm = txtSearch.Text.Trim().ToLower();

            // Get the current filtered tickets
            var currentTickets = _ticketService.FilterTickets(
                _currentFilter.Status,
                _currentFilter.CreatedFromDate,
                _currentFilter.CreatedToDate,
                _currentFilter.ModifiedFromDate,
                _currentFilter.ModifiedToDate,
                _currentFilter.Type,
                _currentFilter.Category
            );

            // If search term is empty, show all filtered tickets
            if (string.IsNullOrEmpty(searchTerm))
            {
                _ticketsBindingSource.DataSource = currentTickets;
            }
            else
            {
                // Filter tickets by title or description containing the search term
                var filteredTickets = currentTickets
                    .Where(t => t.Title.ToLower().Contains(searchTerm) ||
                                (!string.IsNullOrEmpty(t.Description) && t.Description.ToLower().Contains(searchTerm)))
                    .ToList();

                _ticketsBindingSource.DataSource = filteredTickets;
            }

            UpdateTicketCount();
            UpdateDashboard();
        }
        #endregion
    }
}