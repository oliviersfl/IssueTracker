using IssueTracker.Models;
using IssueTracker.Services.Interfaces;

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
                clbCategory.Items.Clear();

                var categories = await _ticketService.GetTicketCategories();

                for (int i = 0; i < categories.Count; i++)
                {
                    clbCategory.Items.Add(categories[i].Description);

                    // Set checked state based on current filter
                    bool shouldCheck = true; // Default to checked

                    if (_currentFilter.Category != null)
                    {
                        // If filter has specific categories, check if this category is in the filter
                        shouldCheck = _currentFilter.Category.Contains(categories[i].Description);
                    }

                    clbCategory.SetItemChecked(i, shouldCheck);
                }

                // If no categories in filter and no items are checked, check all as fallback
                if ((_currentFilter.Category == null || _currentFilter.Category.Count == 0) && clbCategory.CheckedItems.Count == 0 && clbCategory.Items.Count > 0)
                {
                    for (int i = 0; i < clbCategory.Items.Count; i++)
                    {
                        clbCategory.SetItemChecked(i, true);
                    }
                }
            }

            // Ticket Type
            async Task InitializeTypes()
            {
                clbType.Items.Clear();

                var types = await _ticketService.GetTicketTypes();

                for (int i = 0; i < types.Count; i++)
                {
                    clbType.Items.Add(types[i].Description);

                    // Set checked state based on current filter
                    bool shouldCheck = true; // Default to checked

                    if (_currentFilter.Type != null)
                    {
                        // If filter has specific types, check if this type is in the filter
                        shouldCheck = _currentFilter.Type.Contains(types[i].Description);
                    }

                    clbType.SetItemChecked(i, shouldCheck);
                }

                // If no types in filter and no items are checked, check all as fallback
                if ((_currentFilter.Type == null || _currentFilter.Type.Count == 0) && clbType.CheckedItems.Count == 0 && clbType.Items.Count > 0)
                {
                    for (int i = 0; i < clbType.Items.Count; i++)
                    {
                        clbType.SetItemChecked(i, true);
                    }
                }
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
                // Created From
                if (_currentFilter.CreatedFromDate.HasValue)
                {
                    chkFromCreatedDate.Checked = true;
                    dtpFromCreatedDate.Value = _currentFilter.CreatedFromDate.Value;
                }
                else
                {
                    chkFromCreatedDate.Checked = false;
                    dtpFromCreatedDate.Value = DateTime.Now;
                }
                // Created To
                if (_currentFilter.CreatedToDate.HasValue)
                {
                    chkToCreatedDate.Checked = true;
                    dtpToCreatedDate.Value = _currentFilter.CreatedToDate.Value;
                }
                else
                {
                    chkToCreatedDate.Checked = false;
                    dtpToCreatedDate.Value = DateTime.Now;
                }
                // Modified From
                if (_currentFilter.ModifiedFromDate.HasValue)
                {
                    chkFromModifiedDate.Checked = true;
                    dtpFromModifiedDate.Value = _currentFilter.ModifiedFromDate.Value;
                }
                else
                {
                    chkFromModifiedDate.Checked = false;
                    dtpFromModifiedDate.Value = DateTime.Now;
                }
                // Modified To
                if (_currentFilter.ModifiedToDate.HasValue)
                {
                    chkToModifiedDate.Checked = true;
                    dtpToModifiedDate.Value = _currentFilter.ModifiedToDate.Value;
                }
                else
                {
                    chkToModifiedDate.Checked = false;
                    dtpToModifiedDate.Value = DateTime.Now;
                }
            }
            #endregion
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save filter for next time
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };

            // Get all checked categories
            foreach (var item in clbCategory.CheckedItems)
            {
                ResultFilter.Category.Add(item.ToString());
            }

            // Get all checked types
            foreach (var item in clbType.CheckedItems)
            {
                ResultFilter.Type.Add(item.ToString());
            }

            // Get all checked statuses
            foreach (var item in clbStatus.CheckedItems)
            {
                ResultFilter.Status.Add(item.ToString());
            }

            // If none selected for Category, treat as all selected (Category = null)
            if (ResultFilter.Category.Count == 0)
            {
                ResultFilter.Category = null;
            }

            // If none selected for Type, treat as all selected (Type = null)
            if (ResultFilter.Type.Count == 0)
            {
                ResultFilter.Type = null;
            }

            // If none selected for Status, treat as all selected (Status = null)
            if (ResultFilter.Status.Count == 0)
            {
                ResultFilter.Status = null;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkFromCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromCreatedDate.Enabled = chkFromCreatedDate.Checked;
        }

        private void chkToCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpToCreatedDate.Enabled = chkToCreatedDate.Checked;
        }
        private void chkFromModifiedDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromModifiedDate.Enabled = chkFromModifiedDate.Checked;
        }
        private void chkToModifiedDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpToModifiedDate.Enabled = chkToModifiedDate.Checked;
        }

        #region Select All/None methods
        /// <summary>
        /// Event handler for Status Select All button click.
        /// </summary>
        private void btnStatusSelectAll_Click(object sender, EventArgs e)
        {
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };
            for (int i = 0; i < clbStatus.Items.Count; i++)
            {
                ResultFilter.Status.Add(clbStatus.Items[i].ToString());
                clbStatus.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Event handler for Status Select None button click.
        /// </summary>
        private void btnStatusSelectNone_Click(object sender, EventArgs e)
        {
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };
            for (int i = 0; i < clbStatus.Items.Count; i++)
            {
                ResultFilter.Status.Clear();
                clbStatus.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Event handler for Type Select All button click.
        /// </summary>
        private void btnTypeSelectAll_Click(object sender, EventArgs e)
        {
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };
            for (int i = 0; i < clbType.Items.Count; i++)
            {
                ResultFilter.Type.Add(clbType.Items[i].ToString());
                clbType.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Event handler for Type Select None button click.
        /// </summary>
        private void btnTypeSelectNone_Click(object sender, EventArgs e)
        {
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };
            for (int i = 0; i < clbType.Items.Count; i++)
            {
                ResultFilter.Status.Clear();
                clbType.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Event handler for Category Select All button click.
        /// </summary>
        private void btnCategorySelectAll_Click(object sender, EventArgs e)
        {
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };
            for (int i = 0; i < clbType.Items.Count; i++)
            {
                ResultFilter.Category.Add(clbCategory.Items[i].ToString());
                clbCategory.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Event handler for Category Select None button click.
        /// </summary>
        private void btnCategorySelectNone_Click(object sender, EventArgs e)
        {
            ResultFilter = new TicketFilter
            {
                Category = new List<string>(),
                Type = new List<string>(),
                Status = new List<string>(),
                CreatedFromDate = chkFromCreatedDate.Checked ? dtpFromCreatedDate.Value : null,
                CreatedToDate = chkToCreatedDate.Checked ? dtpToCreatedDate.Value : null,
                ModifiedFromDate = chkFromModifiedDate.Checked ? dtpFromModifiedDate.Value : null,
                ModifiedToDate = chkToModifiedDate.Checked ? dtpToModifiedDate.Value : null
            };
            for (int i = 0; i < clbCategory.Items.Count; i++)
            {
                ResultFilter.Status.Clear();
                clbCategory.SetItemChecked(i, false);
            }
        }
        #endregion
    }
}
