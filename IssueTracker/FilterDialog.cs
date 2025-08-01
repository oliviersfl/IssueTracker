using IssueTracker.Models;
using IssueTracker.Services;

namespace IssueTracker
{
    public partial class FilterDialog : Form
    {
        private ITicketService _ticketService;
        // To keep track of past filter selected
        private readonly TicketFilter _currentFilter;
        public TicketFilter ResultFilter { get; private set; }
        public List<string> SelectedStatuses { get; private set; } = new List<string>();
        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public FilterDialog(
            ITicketService ticketService,
            TicketFilter currentFilter = null
        )
        {
            _ticketService = ticketService;
            ResultFilter = new TicketFilter();
            _currentFilter = currentFilter ?? new TicketFilter();
            InitializeComponent();

            this.Load += async (sender, e) =>
            {
                await SetupControls();
            };
        }

        private async Task SetupControls()
        {
            // Initialize status checkboxes
            string[] ticketStatuses = ["To Do", "In Progress", "On Hold", "Done", "Waiting on client", "Call Scheduled", "Status FilterDialog Test harcdoded"];
            foreach (string status in ticketStatuses)
            {
                clbStatus.Items.Add(status, true); // Default all checked
            }

            // Initialize other controls
            cmbType.Items.Add("All");
            cmbType.SelectedIndex = 0;

            await InitializeCategories();
            await InitializeTypes();

            #region Local Methods
            async Task InitializeCategories()
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All");

                var categories = await _ticketService.GetTicketCategories();
                int selectedIndex = 0; // Default to "All"

                for (int i = 0; i < categories.Count; i++)
                {
                    cmbCategory.Items.Add(categories[i].Description);

                    if (categories[i].Description == _currentFilter.Category)
                    {
                        selectedIndex = i + 1; // because "All" is index 0
                    }
                    else if (categories[i].IsDefault && _currentFilter.Category == null)
                    {
                        selectedIndex = i + 1;
                    }
                    else if (_currentFilter.Category == null)
                    {
                        selectedIndex = 0;
                    }
                }
                cmbCategory.SelectedIndex = selectedIndex;
            }
            async Task InitializeTypes()
            {
                cmbType.Items.Clear();
                cmbType.Items.Add("All");

                var types = await _ticketService.GetTicketTypes();
                int selectedIndex = 0; // Default to "All"

                for (int i = 0; i < types.Count; i++)
                {
                    cmbType.Items.Add(types[i].Description);

                    if (types[i].Description == _currentFilter.Type)
                    {
                        selectedIndex = i + 1; // because "All" is index 0
                    }
                    else if (types[i].IsDefault && _currentFilter.Type == null)
                    {
                        selectedIndex = i + 1;
                    }
                    else if (_currentFilter.Type == null)
                    {
                        selectedIndex = 0;
                    }
                }
                cmbType.SelectedIndex = selectedIndex;
            }
            #endregion
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save filter for next time
            ResultFilter = new TicketFilter
            {
                Category = cmbCategory.SelectedIndex == 0 ? null : cmbCategory.SelectedItem.ToString(),
                Type = cmbType.SelectedIndex == 0 ? null : cmbType.SelectedItem.ToString()
            };

            SelectedStatuses.Clear();

            // Get all checked statuses
            foreach (var item in clbStatus.CheckedItems)
            {
                SelectedStatuses.Add(item.ToString());
            }

            // If none selected, treat as all selected
            if (SelectedStatuses.Count == 0)
            {
                string[] ticketStatuses = ["To Do", "In Progress", "On Hold", "Done", "Waiting on client", "Call Scheduled", "Status FilterDialog Test harcdoded"];
                SelectedStatuses.AddRange(ticketStatuses);
            }

            FromDate = chkFromDate.Checked ? dtpFromDate.Value : (DateTime?)null;
            ToDate = chkToDate.Checked ? dtpToDate.Value : (DateTime?)null;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkFromDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Enabled = chkFromDate.Checked;
        }

        private void chkToDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpToDate.Enabled = chkToDate.Checked;
        }
    }
}
