using IssueTracker.Models;
using IssueTracker.Services;

namespace IssueTracker
{
    public partial class TicketDetailForm : Form
    {
        private readonly ITicketService _ticketService;
        private Ticket _currentTicket;
        private bool _isEditMode;

        public TicketDetailForm(ITicketService ticketService, Ticket ticket = null)
        {
            _ticketService = ticketService;
            _currentTicket = ticket;
            _isEditMode = ticket != null;

            InitializeComponent();
            InitializeForm();
        }

        private async void InitializeForm()
        {
            List<TicketPriority> ticketPriorities = await _ticketService.GetTicketPriorities();
            List<TicketType> ticketTypes = await _ticketService.GetTicketTypes();
            List<TicketCategory> ticketCategories = await _ticketService.GetTicketCategories();
            List<TicketStatus> ticketStatuses = await _ticketService.GetTicketStatuses();

            cmbCategory.DataSource = ticketCategories.Select(x => x.Description).ToList();
            cmbPriority.DataSource = ticketPriorities.Select(x => x.Description).ToList();
            cmbStatus.DataSource = ticketStatuses.Select(x => x.Description).ToList();
            cmbType.DataSource = ticketTypes.Select(x => x.Description).ToList();

            // Show delete button only for existing tickets
            btnDelete.Visible = _isEditMode;

            if (_isEditMode)
            {
                List<SubTask> subTasks = await _ticketService.GetTicketSubTasksByTicketId(_currentTicket.Id);
                List<Comment> comments = await _ticketService.GetTicketCommentsByTicketId(_currentTicket.Id);

                // Bind existing ticket data
                txtTitle.Text = _currentTicket.Title;
                txtDescription.Text = _currentTicket.Description.Replace("\n", Environment.NewLine);
                cmbCategory.SelectedItem = _currentTicket.Category;
                cmbPriority.SelectedItem = _currentTicket.Priority;
                cmbType.SelectedItem = _currentTicket.Type;
                cmbStatus.SelectedItem = _currentTicket.Status;

                // Handle dates
                lblCreated.Text = _currentTicket.CreatedDate.ToString("g");
                lblModified.Text = _currentTicket.ModifiedDate.ToString("g");

                if (_currentTicket.DueDate.HasValue)
                {
                    chkDueDate.Checked = true;
                    dtpDueDate.Value = _currentTicket.DueDate.Value;
                }

                // Load subtasks
                _currentTicket.SubTasks = subTasks;
                foreach (var subTask in _currentTicket.SubTasks)
                {
                    var item = new ListViewItem(subTask.Title);
                    item.SubItems.Add(subTask.IsCompleted ? "Yes" : "No");
                    item.Tag = subTask;
                    lvSubtasks.Items.Add(item);
                }

                // Load comments
                _currentTicket.Comments = comments;
                foreach (var comment in _currentTicket.Comments)
                {
                    var item = new ListViewItem(comment.Author);
                    item.SubItems.Add(comment.Text);
                    item.SubItems.Add(comment.CreatedDate.ToString("g"));
                    item.Tag = comment;
                    lvComments.Items.Add(item);
                }
            }
            else
            {
                // Set up a new ticket with default values
                lblTitle.Text = "Create New Ticket";
                lblCreated.Text = DateTime.Now.ToString("g");
                lblModified.Text = DateTime.Now.ToString("g");

                // Set default values for dropdowns
                cmbCategory.SelectedItem = ticketCategories.Where(x => x.IsDefault == true).Select(x => x.Description).FirstOrDefault();
                cmbPriority.SelectedItem = ticketPriorities.Where(x => x.IsDefault == true).Select(x => x.Description).FirstOrDefault();
                cmbType.SelectedItem = ticketTypes.Where(x => x.IsDefault == true).Select(x => x.Description).FirstOrDefault();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var ticket = _isEditMode ? _currentTicket : new Ticket();

                // Map form fields to ticket properties
                ticket.Title = txtTitle.Text;
                ticket.Description = txtDescription.Text;
                ticket.Category = cmbCategory.SelectedValue.ToString();
                ticket.Priority = cmbPriority.SelectedValue.ToString();
                ticket.Type = cmbType.SelectedValue.ToString();
                ticket.DueDate = chkDueDate.Checked ? dtpDueDate.Value : (DateTime?)null;
                ticket.Status = cmbStatus.SelectedValue.ToString();

                // Update subtasks
                ticket.SubTasks = new List<SubTask>();
                foreach (ListViewItem item in lvSubtasks.Items)
                {
                    ticket.SubTasks.Add(new SubTask
                    {
                        Id = item.Tag != null ? ((SubTask)item.Tag).Id : 0,
                        Title = item.Text,
                        IsCompleted = item.SubItems[1].Text == "Yes"
                    });
                }

                // Update comments
                ticket.Comments = new List<Comment>();
                foreach (ListViewItem item in lvComments.Items)
                {
                    ticket.Comments.Add(new Comment
                    {
                        Id = item.Tag != null ? ((Comment)item.Tag).Id : 0,
                        Author = item.Text,
                        Text = item.SubItems[1].Text,
                        CreatedDate = DateTime.Parse(item.SubItems[2].Text)
                    });
                }

                if (_isEditMode)
                {
                    ticket.ModifiedDate = DateTime.Now;
                    _ticketService.UpdateTicket(ticket); // Uncomment when service is ready
                }
                else
                {
                    ticket.CreatedDate = DateTime.Now;
                    ticket.ModifiedDate = DateTime.Now;
                    _ticketService.AddTicket(ticket); // Uncomment when service is ready
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentTicket != null && _currentTicket.Id > 0)
            {
                var result = MessageBox.Show(
                    "Are you sure you want to delete this ticket? This action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await _ticketService.DeleteTicket(_currentTicket.Id);
                        this.DialogResult = DialogResult.Abort; // Special result to indicate delete
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting ticket: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAddSubTask_Click(object sender, EventArgs e)
        {
            var subTaskForm = new SimpleInputForm("Add Subtask", "Subtask title:");
            if (subTaskForm.ShowDialog() == DialogResult.OK)
            {
                var item = new ListViewItem(subTaskForm.InputText);
                item.SubItems.Add("No");
                lvSubtasks.Items.Add(item);
            }
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Please enter a comment", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = new ListViewItem("Current User"); // Would normally get current user
            item.SubItems.Add(txtComment.Text);
            item.SubItems.Add(DateTime.Now.ToString("g"));
            lvComments.Items.Add(item);

            txtComment.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkDueDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDueDate.Enabled = chkDueDate.Checked;
        }

        private void btnToggleComplete_Click(object sender, EventArgs e)
        {
            if (lvSubtasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a subtask to toggle", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = lvSubtasks.SelectedItems[0];
            selectedItem.SubItems[1].Text = selectedItem.SubItems[1].Text == "Yes" ? "No" : "Yes";
        }

        private void btnDeleteSubTask_Click(object sender, EventArgs e)
        {
            if (lvSubtasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a subtask to delete", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this subtask?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lvSubtasks.SelectedItems[0].Remove();
            }
        }
        private void btnEditComment_Click(object sender, EventArgs e)
        {
            if (lvComments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a comment to edit", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = lvComments.SelectedItems[0];
            var editForm = new SimpleInputForm("Edit Comment", "Comment text:", selectedItem.SubItems[1].Text);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedItem.SubItems[1].Text = editForm.InputText;
                selectedItem.SubItems[2].Text = DateTime.Now.ToString("g"); // Update modified time
            }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (lvComments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a comment to delete", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this comment?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lvComments.SelectedItems[0].Remove();
            }
        }
        private void TxtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the ding sound
                btnAddComment.PerformClick(); // Trigger the add comment button click
            }
        }
    }
}