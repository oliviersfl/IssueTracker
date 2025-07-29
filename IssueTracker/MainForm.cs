using IssueTracker.Models;
using IssueTracker.Models.Enums;
using IssueTracker.Services;
using IssueTracker.Services.Database.Repository.Interfaces;

namespace IssueTracker
{
    public partial class MainForm : Form
    {
        private readonly ITicketService _ticketService;
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
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

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

        private void LoadTickets()
        {
            // For testing, we'll use the hardcoded list with different timestamps
            var tickets = new List<Ticket>()
            {
                new Ticket()
                {
                    Id = 1,
                    Title = "Some bug",
                    Description = "Can't read file\nCan you please help",
                    Category = "Bug",
                    Priority = "Medium",
                    Type = "Data Bridge",
                    CreatedDate = DateTime.Now.AddHours(-2),
                    ModifiedDate = DateTime.Now.AddMinutes(-30),
                    DueDate = DateTime.Now.AddDays(3),
                    Status = "Done"
                },
                new Ticket()
                {
                    Id = 2,
                    Title = "Interface - New Client",
                    Description = "Inbound",
                    Category = "Feature",
                    Priority = "Low",
                    Type = "Custom Interface",
                    CreatedDate = DateTime.Now.AddDays(-1),
                    ModifiedDate = DateTime.Now.AddHours(-3),
                    DueDate = DateTime.Now.AddDays(7),
                    Status = "To Do"
                },
                new Ticket()
                {
                    Id = 3,
                    Title = "API Activation - Urgent",
                    Description = "New API for XYZ Company",
                    Category = "Feature",
                    Priority = "High",
                    Type = "API Activation",
                    CreatedDate = DateTime.Now.AddHours(-2),
                    ModifiedDate = DateTime.Now.AddMinutes(-30),
                    DueDate = DateTime.Now.AddDays(3),
                    Status = "Waiting for client"
                },
                new Ticket()
                {
                    Id = 4,
                    Title = "Databridge Issue - For ABC Company",
                    Description = "Identifier not found issue",
                    Category = "Bug",
                    Priority = "Critical",
                    Type = "Data Bridge",
                    CreatedDate = DateTime.Now.AddHours(-2),
                    ModifiedDate = DateTime.Now.AddMinutes(-30),
                    DueDate = DateTime.Now.AddDays(3),
                    Status = "In Progress"
                },
                new Ticket()
                {
                    Id = 5,
                    Title = "SFTP Error",
                    Description = "Unable to connect to SFTP",
                    Category = "Feature",
                    Priority = "High",
                    Type = "Support",
                    CreatedDate = DateTime.Now.AddHours(-2),
                    ModifiedDate = DateTime.Now.AddMinutes(-30),
                    DueDate = DateTime.Now.AddDays(3),
                    Status = "Waiting on internal team"
                },
            };

            foreach (var ticket in tickets)
            {
                _ticketService.AddTicket(ticket);
            }

            _ticketsBindingSource.DataSource = tickets;
            UpdateTicketCount();

            // In your final version, you'll use the service:
            // var tickets = _ticketService.GetAllTickets();
            // _ticketsBindingSource.DataSource = tickets;
        }

        private void UpdateTicketCount()
        {
            lblTicketCount.Text = _ticketsBindingSource.Count.ToString();
        }
        public void ApplyDefaultFilters()
        {
            var statusesToInclude = new List<string>() { "To Do", "In Progress", "Waiting for client", "Call scheduled", "On Hold", "Done" };

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

        private void btnCreateTicket_Click(object sender, EventArgs e)
        {
            var detailForm = new TicketDetailForm(_ticketService);
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadTickets(); // Refresh the list
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var filterDialog = new FilterDialog(_ticketService);  // Pass the service here
            if (filterDialog.ShowDialog() == DialogResult.OK)
            {
                var filteredTickets = _ticketService.FilterTickets(
                    filterDialog.SelectedStatuses,
                    filterDialog.FromDate,
                    filterDialog.ToDate,
                    filterDialog.SelectedType,
                    filterDialog.SelectedCategory
                );

                _ticketsBindingSource.DataSource = filteredTickets;
            }

            UpdateTicketCount();
        }
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            // Reload all tickets without any filters
            var allTickets = _ticketService.GetAllTickets();
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
                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTickets(); // Refresh the list
                }
            }
        }
    }
}