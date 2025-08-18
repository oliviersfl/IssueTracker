using IssueTracker.Models;
using IssueTracker.Services;
using IssueTracker.Services.Database.Repository.Interfaces;

namespace IssueTracker
{
    public partial class MainForm : Form
    {
        private readonly ITicketService _ticketService;
        private readonly TicketFilter _currentFilter = new TicketFilter();
        private BindingSource _ticketsBindingSource = new BindingSource();

        private ITicketRepository _ticketRepo;

        public MainForm(ITicketService ticketService, ITicketRepository ticketRepository)
        {
            _ticketService = ticketService;
            _ticketRepo = ticketRepository;

            InitializeComponent();
            ConfigureUI();
            LoadTickets();
            ApplyDefaultFilters();
        }
        private void ConfigureUI()
        {
            // Configure DataGridView
            dgvTickets.AutoGenerateColumns = false;
            dgvTickets.DataSource = _ticketsBindingSource;

            // Clear existing columns if any
            dgvTickets.Columns.Clear();

            // Add columns

            dgvTickets.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Width = 200
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

            // Add the new date columns
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
            // For testing, we'll use the hardcoded list with different timestamps
            _ticketService.ClearTickets();

            var test = await _ticketService.GetAllTickets();
            _ticketsBindingSource.DataSource = await _ticketService.GetAllTickets();
            UpdateTicketCount();
        }

        private void UpdateTicketCount()
        {
            lblTicketCount.Text = _ticketsBindingSource.Count.ToString();
        }
        public async Task ApplyDefaultFilters()
        {
            var filters = await _ticketRepo.GetAllStatusesAsync();

            var statusesToInclude = filters.Where(s => s.IsDefault == true).Select(s => s.Description).ToList();

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

        private async void btnCreateTicket_Click(object sender, EventArgs e)
        {
            var detailForm = new TicketDetailForm(_ticketService);
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                await LoadTickets(); // Refresh the list
                await ApplyDefaultFilters();
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

                var filteredTickets = _ticketService.FilterTickets(
                    _currentFilter.Status,
                    filterDialog.FromDate,
                    filterDialog.ToDate,
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
            UpdateTicketCount();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialization if needed
        }

        // Double-click event for ticket selection
        private void dgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedTicket = (Ticket)_ticketsBindingSource[e.RowIndex];
                var detailForm = new TicketDetailForm(_ticketService, selectedTicket);

                var result = detailForm.ShowDialog();

                // Refresh if the ticket was saved (OK) or deleted (Abort)
                if (result == DialogResult.OK || result == DialogResult.Abort)
                {
                    LoadTickets(); // Refresh the list

                    // If the ticket was deleted, clear the selection
                    if (result == DialogResult.Abort)
                    {
                        dgvTickets.ClearSelection();
                    }
                }
            }
        }
    }
}