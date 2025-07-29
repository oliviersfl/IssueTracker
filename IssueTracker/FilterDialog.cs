using IssueTracker.Models.Enums;
using IssueTracker.Services;

namespace IssueTracker
{
    public partial class FilterDialog : Form
    {
        private ITicketService _ticketService;
        public List<string> SelectedStatuses { get; private set; } = new List<string>();
        public DateTime? FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public string SelectedType { get; private set; }
        public string SelectedCategory { get; private set; }
        public FilterDialog(ITicketService ticketService)
        {
            _ticketService = ticketService;
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
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

            cmbCategory.Items.Add("All");

            // TEST:
            string[] ticketCategories = ["Bug", "Feature", "Enhancement", "Documentation", "Support", "Ticket Categories Test FilterDialog Hardcoded"];
            foreach (string category in ticketCategories)
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0;
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
