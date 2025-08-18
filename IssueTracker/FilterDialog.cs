using IssueTracker.Models;
using IssueTracker.Services;
using System.Windows.Forms;

namespace IssueTracker
{
    public partial class FilterDialog : Form
    {
        #region Properties
        private ITicketService _ticketService;
        // To keep track of past filter selected
        private readonly TicketFilter _currentFilter;
        public TicketFilter ResultFilter { get; private set; }
        #endregion
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
            // Initialize other controls

            await InitializeCategories();
            await InitializeTypes();
            await InitializeStatuses();
            InitializeCreatedDates();

            #region Local Methods
            // Ticket Categories
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
            // Ticket Type
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
            // Ticket Statuses
            async Task InitializeStatuses()
            {
                clbStatus.Items.Clear();

                var statuses = await _ticketService.GetTicketStatuses();

                for (int i = 0; i < statuses.Count; i++)
                {
                    clbStatus.Items.Add(statuses[i].Description);

                    // Set checked state based on current filter
                    bool shouldCheck = true; // Default to checked

                    if (_currentFilter.Status != null)
                    {
                        // If filter has specific statuses, check if this status is in the filter
                        shouldCheck = _currentFilter.Status.Contains(statuses[i].Description);
                    }
                    else if (!statuses[i].IsDefault)
                    {
                        // If no filter, check all by default (except when there's a default status logic)
                        shouldCheck = false;
                    }

                    clbStatus.SetItemChecked(i, shouldCheck);
                }

                // If no statuses in filter and no items are checked, check all as fallback
                if (_currentFilter.Status == null && clbStatus.CheckedItems.Count == 0 && clbStatus.Items.Count > 0)
                {
                    for (int i = 0; i < clbStatus.Items.Count; i++)
                    {
                        clbStatus.SetItemChecked(i, true);
                    }
                }
            }
            // Ticket Created Date Range
            void InitializeCreatedDates()
            {
                // From
                if (_currentFilter.CreatedFromDate.HasValue)
                {
                    chkFromDate.Checked = true;
                    dtpFromDate.Value = _currentFilter.CreatedFromDate.Value;
                }
                else
                {
                    chkFromDate.Checked = false;
                    dtpFromDate.Value = DateTime.Now;
                }
                // To
                if (_currentFilter.CreatedToDate.HasValue)
                {
                    chkToDate.Checked = true;
                    dtpToDate.Value = _currentFilter.CreatedToDate.Value;
                }
                else
                {
                    chkToDate.Checked = false;
                    dtpToDate.Value = DateTime.Now;
                }
            }
            #endregion
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save filter for next time
            ResultFilter = new TicketFilter
            {
                Category = cmbCategory.SelectedIndex == 0 ? null : cmbCategory.SelectedItem.ToString(),
                Type = cmbType.SelectedIndex == 0 ? null : cmbType.SelectedItem.ToString(),
                Status = new List<string>(),
                CreatedFromDate = chkFromDate.Checked ? dtpFromDate.Value : null,
                CreatedToDate = chkToDate.Checked ? dtpToDate.Value : null
            };

            // Get all checked statuses
            foreach (var item in clbStatus.CheckedItems)
            {
                ResultFilter.Status.Add(item.ToString());
            }

            // If none selected, treat as all selected (Status = null)
            if (ResultFilter.Status.Count == 0)
            {
                ResultFilter.Status = null; // This matches the pattern in InitializeStatuses
            }

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
