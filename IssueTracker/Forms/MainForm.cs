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

                if (_ticketsBindingSource.DataSource is List<Ticket> tickets)
                {
                    var sortedTickets = column.HeaderCell.SortGlyphDirection == SortOrder.Ascending
                        ? tickets.OrderByDescending(t => GetPropertyValue(t, column.DataPropertyName)).ToList()
                        : tickets.OrderBy(t => GetPropertyValue(t, column.DataPropertyName)).ToList();

                    _ticketsBindingSource.DataSource = sortedTickets;

                    // Update sort glyph
                    column.HeaderCell.SortGlyphDirection =
                        column.HeaderCell.SortGlyphDirection == SortOrder.Ascending
                            ? SortOrder.Descending
                            : SortOrder.Ascending;

                    // Clear other sort glyphs
                    foreach (DataGridViewColumn col in dgvTickets.Columns)
                    {
                        if (col != column) col.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
            };
            #endregion
        }

        public async Task LoadTickets()
        {
            _ticketService.ClearTickets();

            await _ticketService.GetAllTickets();

            var filteredTickets = _ticketService.FilterTickets(
                    _currentFilter.Status,
                    _currentFilter.CreatedFromDate,
                    _currentFilter.CreatedToDate,
                    _currentFilter.Type,
                    _currentFilter.Category
                );

            _ticketsBindingSource.DataSource = filteredTickets;
            UpdateTicketCount();

            dgvTickets.Refresh();
        }

        private void UpdateTicketCount()
        {
            lblTicketCount.Text = _ticketsBindingSource.Count.ToString();
        }
        public async Task ApplyDefaultFilters()
        {
            var filters = await _ticketRepo.GetAllStatusesAsync();

            var statusesToInclude = filters.Where(s => s.IsDefault == true).Select(s => s.Description).ToList();
            _currentFilter.Status = statusesToInclude;

            List<Ticket> tickets = _ticketService.FilterTickets(statusesToInclude, null, null, null, null);

            _ticketsBindingSource.DataSource = tickets;

            UpdateTicketCount();
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

                var filteredTickets = _ticketService.FilterTickets(
                    _currentFilter.Status,
                    _currentFilter.CreatedFromDate,
                    _currentFilter.CreatedToDate,
                    _currentFilter.Type,
                    _currentFilter.Category // Use the updated value
                );

                _ticketsBindingSource.DataSource = filteredTickets;
            }
            UpdateTicketCount();
        }
        private async void btnClearFilter_Click(object sender, EventArgs e)
        {
            // Reload all tickets without any filters
            var allTickets = await _ticketService.GetAllTickets();
            _ticketsBindingSource.DataSource = allTickets;
            txtSearch.Text = "";
            UpdateTicketCount();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Get the search term and trim whitespace
            string searchTerm = txtSearch.Text.Trim().ToLower();
                var filteredTickets = _ticketService.FilterTickets(
                    _currentFilter.Status,
                    _currentFilter.CreatedFromDate,
                    _currentFilter.CreatedToDate,
                    _currentFilter.Type,
                    _currentFilter.Category
                );


            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredTickets = filteredTickets
                    .Where(t => t.Title.ToLower().Contains(searchTerm))
                    .ToList();
            }
            _excelExportService.ExportTicketsToFile(
                filteredTickets,
                Path.Combine(_appSettings.ExportPath, _appSettings.ExportFileName)
            );

            MessageBox.Show("Excel Export Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Filter tickets by title containing the search term
                var filteredTickets = currentTickets
                    .Where(t => t.Title.ToLower().Contains(searchTerm))
                    .ToList();

                _ticketsBindingSource.DataSource = filteredTickets;
            }

            UpdateTicketCount();
        }
        #endregion
    }
}