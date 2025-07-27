using IssueTracker.Models;
using IssueTracker.Services;

namespace IssueTracker
{
    public partial class MainForm : Form
    {
        private readonly ITicketService _ticketService;
        private BindingSource _ticketsBindingSource = new BindingSource();

        public MainForm(ITicketService ticketService)
        {
            _ticketService = ticketService;
            InitializeComponent();
            ConfigureUI();
            LoadTickets();
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
                    Category = Models.Enums.TicketCategory.Bug,
                    Priority = Models.Enums.Priority.Medium,
                    Type = "Data Bridge",
                    CreatedDate = DateTime.Now.AddHours(-2),
                    ModifiedDate = DateTime.Now.AddMinutes(-30),
                    DueDate = DateTime.Now.AddDays(3),
                    Status = Models.Enums.Status.InProgress
                },
                new Ticket()
                {
                    Id = 2,
                    Title = "Interface - New Client",
                    Description = "Inbound",
                    Category = Models.Enums.TicketCategory.Feature,
                    Priority = Models.Enums.Priority.Low,
                    Type = "Custom Interface",
                    CreatedDate = DateTime.Now.AddDays(-1),
                    ModifiedDate = DateTime.Now.AddHours(-3),
                    DueDate = DateTime.Now.AddDays(7),
                    Status = Models.Enums.Status.ToDo
                }
            };
            _ticketService.AddTicket(tickets[0]);
            _ticketService.AddTicket(tickets[1]);

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
        public void dgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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