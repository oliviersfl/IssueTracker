using IssueTracker.Models;
using IssueTracker.Services;

namespace IssueTracker
{
    public partial class FilterDialog : Form
    {
        private ITicketService _ticketService;
        // To keep track of past filter selected
        private string _currentCategory;
        public List<string> SelectedStatuses { get; private set; } = new List<string>();
        public string SelectedType { get; private set; }
        public string SelectedCategory { get; private set; }
        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public FilterDialog(
            ITicketService ticketService,
            string currentCategory
        )
        {
            _ticketService = ticketService;
            _currentCategory = currentCategory;
            InitializeComponent();
            SetupControls();
        }

        private async void SetupControls()
        {
            // Initialize status checkboxes
            string[] ticketStatuses = ["To Do", "In Progress", "On Hold", "Done", "Waiting on client", "Call Scheduled", "Status FilterDialog Test harcdoded"];
            foreach (string status in ticketStatuses)
            {
                clbStatus.Items.Add(status, true); // Default all checked
            }

            // Initialize other controls
            cmbType.Items.Add("All");
            cmbType.Items.AddRange(_ticketService.GetTicketTypes().ToArray());
            cmbType.SelectedIndex = 0;

            // Initialize category combo
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All");

            List<TicketCategory> tickCat = await _ticketService.GetTicketCategories();
            int defaultIndex = 0; // Default to "All"

            for (int i = 0; i < tickCat.Count; i++)
            {
                cmbCategory.Items.Add(tickCat[i].Description);

                // If a stored category matches, select it
                if (_currentCategory != null && tickCat[i].Description == _currentCategory)
                {
                    defaultIndex = i + 1; // +1 because "All" is index 0
                }
                // Otherwise, fall back to default category if specified
                else if (tickCat[i].IsDefault && _currentCategory == null)
                {
                    defaultIndex = i + 1;
                }
            }

            cmbCategory.SelectedIndex = defaultIndex; // Apply selection
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
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

            SelectedCategory = cmbCategory.SelectedIndex == 0 ? null : cmbCategory.SelectedItem.ToString();

            FromDate = chkFromDate.Checked ? dtpFromDate.Value : (DateTime?)null;
            ToDate = chkToDate.Checked ? dtpToDate.Value : (DateTime?)null;
            SelectedType = cmbType.SelectedIndex == 0 ? null : cmbType.SelectedItem.ToString();

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
