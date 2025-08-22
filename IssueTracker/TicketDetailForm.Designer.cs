namespace IssueTracker
{
    partial class TicketDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblTitle = new Label();
            panel2 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            tabControl1 = new TabControl();
            tabPageDetails = new TabPage();
            gbDates = new GroupBox();
            lblModified = new Label();
            label5 = new Label();
            lblCreated = new Label();
            label3 = new Label();
            dtpDueDate = new DateTimePicker();
            chkDueDate = new CheckBox();
            gbStatus = new GroupBox();
            cmbStatus = new ComboBox();
            gbType = new GroupBox();
            cmbType = new ComboBox();
            gbPriority = new GroupBox();
            cmbPriority = new ComboBox();
            gbCategory = new GroupBox();
            cmbCategory = new ComboBox();
            txtDescription = new TextBox();
            label2 = new Label();
            txtTitle = new TextBox();
            label1 = new Label();
            tabPageSubtasks = new TabPage();
            btnAddSubTask = new Button();
            panel3 = new Panel();
            lvSubtasks = new ListView();
            subTaskHeaderTitle = new ColumnHeader();
            subTaskHeaderIsComplete = new ColumnHeader();
            btnToggleComplete = new Button();
            btnDeleteSubTask = new Button();
            tabPageComments = new TabPage();
            btnDeleteComment = new Button();
            btnEditComment = new Button();
            btnAddComment = new Button();
            txtComment = new TextBox();
            panel4 = new Panel();
            lvComments = new ListView();
            commentHeaderAuthor = new ColumnHeader();
            commentHeaderComment = new ColumnHeader();
            commentHeaderDateCreated = new ColumnHeader();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageDetails.SuspendLayout();
            gbDates.SuspendLayout();
            gbStatus.SuspendLayout();
            gbType.SuspendLayout();
            gbPriority.SuspendLayout();
            gbCategory.SuspendLayout();
            tabPageSubtasks.SuspendLayout();
            panel3.SuspendLayout();
            tabPageComments.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(782, 80);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(14, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ticket Details";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnDelete);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 681);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(782, 67);
            panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.SteelBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.SteelBlue;
            btnCancel.Location = new Point(682, 13);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.SteelBlue;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(590, 13);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(23, 13);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Ticket";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDetails);
            tabControl1.Controls.Add(tabPageSubtasks);
            tabControl1.Controls.Add(tabPageComments);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 80);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(782, 601);
            tabControl1.TabIndex = 2;
            // 
            // tabPageDetails
            // 
            tabPageDetails.Controls.Add(gbDates);
            tabPageDetails.Controls.Add(gbStatus);
            tabPageDetails.Controls.Add(gbType);
            tabPageDetails.Controls.Add(gbPriority);
            tabPageDetails.Controls.Add(gbCategory);
            tabPageDetails.Controls.Add(txtDescription);
            tabPageDetails.Controls.Add(label2);
            tabPageDetails.Controls.Add(txtTitle);
            tabPageDetails.Controls.Add(label1);
            tabPageDetails.Location = new Point(4, 29);
            tabPageDetails.Margin = new Padding(3, 4, 3, 4);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Padding = new Padding(11, 13, 11, 13);
            tabPageDetails.Size = new Size(774, 568);
            tabPageDetails.TabIndex = 0;
            tabPageDetails.Text = "Details";
            tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // gbDates
            // 
            gbDates.Controls.Add(lblModified);
            gbDates.Controls.Add(label5);
            gbDates.Controls.Add(lblCreated);
            gbDates.Controls.Add(label3);
            gbDates.Controls.Add(dtpDueDate);
            gbDates.Controls.Add(chkDueDate);
            gbDates.Location = new Point(400, 413);
            gbDates.Margin = new Padding(3, 4, 3, 4);
            gbDates.Name = "gbDates";
            gbDates.Padding = new Padding(3, 4, 3, 4);
            gbDates.Size = new Size(343, 227);
            gbDates.TabIndex = 8;
            gbDates.TabStop = false;
            gbDates.Text = "Dates";
            // 
            // lblModified
            // 
            lblModified.AutoSize = true;
            lblModified.Location = new Point(91, 113);
            lblModified.Name = "lblModified";
            lblModified.Size = new Size(50, 20);
            lblModified.TabIndex = 5;
            lblModified.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 113);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 4;
            label5.Text = "Modified:";
            // 
            // lblCreated
            // 
            lblCreated.AutoSize = true;
            lblCreated.Location = new Point(91, 73);
            lblCreated.Name = "lblCreated";
            lblCreated.Size = new Size(50, 20);
            lblCreated.TabIndex = 3;
            lblCreated.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 73);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 2;
            label3.Text = "Created:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Enabled = false;
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(91, 27);
            dtpDueDate.Margin = new Padding(3, 4, 3, 4);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(228, 27);
            dtpDueDate.TabIndex = 1;
            // 
            // chkDueDate
            // 
            chkDueDate.AutoSize = true;
            chkDueDate.Location = new Point(17, 33);
            chkDueDate.Margin = new Padding(3, 4, 3, 4);
            chkDueDate.Name = "chkDueDate";
            chkDueDate.Size = new Size(79, 24);
            chkDueDate.TabIndex = 0;
            chkDueDate.Text = "Due on";
            chkDueDate.UseVisualStyleBackColor = true;
            chkDueDate.CheckedChanged += chkDueDate_CheckedChanged;
            // 
            // gbStatus
            // 
            gbStatus.Controls.Add(cmbStatus);
            gbStatus.Location = new Point(400, 320);
            gbStatus.Margin = new Padding(3, 4, 3, 4);
            gbStatus.Name = "gbStatus";
            gbStatus.Padding = new Padding(3, 4, 3, 4);
            gbStatus.Size = new Size(343, 80);
            gbStatus.TabIndex = 7;
            gbStatus.TabStop = false;
            gbStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(17, 33);
            cmbStatus.Margin = new Padding(3, 4, 3, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(308, 28);
            cmbStatus.TabIndex = 0;
            // 
            // gbType
            // 
            gbType.Controls.Add(cmbType);
            gbType.Location = new Point(400, 133);
            gbType.Margin = new Padding(3, 4, 3, 4);
            gbType.Name = "gbType";
            gbType.Padding = new Padding(3, 4, 3, 4);
            gbType.Size = new Size(343, 80);
            gbType.TabIndex = 6;
            gbType.TabStop = false;
            gbType.Text = "Type";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(17, 33);
            cmbType.Margin = new Padding(3, 4, 3, 4);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(308, 28);
            cmbType.TabIndex = 0;
            // 
            // gbPriority
            // 
            gbPriority.Controls.Add(cmbPriority);
            gbPriority.Location = new Point(400, 40);
            gbPriority.Margin = new Padding(3, 4, 3, 4);
            gbPriority.Name = "gbPriority";
            gbPriority.Padding = new Padding(3, 4, 3, 4);
            gbPriority.Size = new Size(343, 80);
            gbPriority.TabIndex = 5;
            gbPriority.TabStop = false;
            gbPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(17, 33);
            cmbPriority.Margin = new Padding(3, 4, 3, 4);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(308, 28);
            cmbPriority.TabIndex = 0;
            // 
            // gbCategory
            // 
            gbCategory.Controls.Add(cmbCategory);
            gbCategory.Location = new Point(23, 320);  // Changed from 227 to 320
            gbCategory.Margin = new Padding(3, 4, 3, 4);
            gbCategory.Name = "gbCategory";
            gbCategory.Padding = new Padding(3, 4, 3, 4);
            gbCategory.Size = new Size(343, 80);
            gbCategory.TabIndex = 4;
            gbCategory.TabStop = false;
            gbCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(17, 33);
            cmbCategory.Margin = new Padding(3, 4, 3, 4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(308, 28);
            cmbCategory.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(23, 107);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(342, 200);
            txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 80);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 2;
            label2.Text = "Description:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(23, 40);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(342, 27);
            txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 13);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            // 
            // tabPageSubtasks
            // 
            tabPageSubtasks.Controls.Add(btnAddSubTask);
            tabPageSubtasks.Controls.Add(panel3);
            tabPageSubtasks.Controls.Add(btnToggleComplete);
            tabPageSubtasks.Controls.Add(btnDeleteSubTask);
            tabPageSubtasks.Location = new Point(4, 29);
            tabPageSubtasks.Margin = new Padding(3, 4, 3, 4);
            tabPageSubtasks.Name = "tabPageSubtasks";
            tabPageSubtasks.Padding = new Padding(11, 13, 11, 13);
            tabPageSubtasks.Size = new Size(774, 568);
            tabPageSubtasks.TabIndex = 1;
            tabPageSubtasks.Text = "Subtasks";
            tabPageSubtasks.UseVisualStyleBackColor = true;
            // 
            // btnAddSubTask
            // 
            btnAddSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddSubTask.BackColor = Color.SteelBlue;
            btnAddSubTask.FlatAppearance.BorderSize = 0;
            btnAddSubTask.FlatStyle = FlatStyle.Flat;
            btnAddSubTask.ForeColor = Color.White;
            btnAddSubTask.Location = new Point(657, 507);
            btnAddSubTask.Margin = new Padding(3, 4, 3, 4);
            btnAddSubTask.Name = "btnAddSubTask";
            btnAddSubTask.Size = new Size(101, 40);
            btnAddSubTask.TabIndex = 1;
            btnAddSubTask.Text = "Add Subtask";
            btnAddSubTask.UseVisualStyleBackColor = false;
            btnAddSubTask.Click += btnAddSubTask_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(lvSubtasks);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(11, 13);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(752, 480);
            panel3.TabIndex = 0;
            // 
            // lvSubtasks
            // 
            lvSubtasks.Columns.AddRange(new ColumnHeader[] { subTaskHeaderTitle, subTaskHeaderIsComplete });
            lvSubtasks.Dock = DockStyle.Fill;
            lvSubtasks.FullRowSelect = true;
            lvSubtasks.GridLines = true;
            lvSubtasks.Location = new Point(0, 0);
            lvSubtasks.Margin = new Padding(3, 4, 3, 4);
            lvSubtasks.Name = "lvSubtasks";
            lvSubtasks.Size = new Size(752, 480);
            lvSubtasks.TabIndex = 0;
            lvSubtasks.UseCompatibleStateImageBehavior = false;
            lvSubtasks.View = View.Details;
            // 
            // columnHeader1
            // 
            subTaskHeaderTitle.Text = "Title";
            subTaskHeaderTitle.Width = 500;
            // 
            // columnHeader2
            // 
            subTaskHeaderIsComplete.Text = "Completed";
            subTaskHeaderIsComplete.TextAlign = HorizontalAlignment.Center;
            subTaskHeaderIsComplete.Width = 120;
            // 
            // btnToggleComplete
            // 
            btnToggleComplete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnToggleComplete.BackColor = Color.SteelBlue;
            btnToggleComplete.FlatAppearance.BorderSize = 0;
            btnToggleComplete.FlatStyle = FlatStyle.Flat;
            btnToggleComplete.ForeColor = Color.White;
            btnToggleComplete.Location = new Point(451, 507);
            btnToggleComplete.Margin = new Padding(3, 4, 3, 4);
            btnToggleComplete.Name = "btnToggleComplete";
            btnToggleComplete.Size = new Size(137, 40);
            btnToggleComplete.TabIndex = 2;
            btnToggleComplete.Text = "Toggle Complete";
            btnToggleComplete.UseVisualStyleBackColor = false;
            btnToggleComplete.Click += btnToggleComplete_Click;
            // 
            // btnDeleteSubTask
            // 
            btnDeleteSubTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeleteSubTask.BackColor = Color.IndianRed;
            btnDeleteSubTask.FlatAppearance.BorderSize = 0;
            btnDeleteSubTask.FlatStyle = FlatStyle.Flat;
            btnDeleteSubTask.ForeColor = Color.White;
            btnDeleteSubTask.Location = new Point(307, 507);
            btnDeleteSubTask.Margin = new Padding(3, 4, 3, 4);
            btnDeleteSubTask.Name = "btnDeleteSubTask";
            btnDeleteSubTask.Size = new Size(137, 40);
            btnDeleteSubTask.TabIndex = 3;
            btnDeleteSubTask.Text = "Delete Subtask";
            btnDeleteSubTask.UseVisualStyleBackColor = false;
            btnDeleteSubTask.Click += btnDeleteSubTask_Click;
            // 
            // tabPageComments
            // 
            tabPageComments.Controls.Add(btnDeleteComment);
            tabPageComments.Controls.Add(btnEditComment);
            tabPageComments.Controls.Add(btnAddComment);
            tabPageComments.Controls.Add(txtComment);
            tabPageComments.Controls.Add(panel4);
            tabPageComments.Location = new Point(4, 29);
            tabPageComments.Margin = new Padding(3, 4, 3, 4);
            tabPageComments.Name = "tabPageComments";
            tabPageComments.Padding = new Padding(11, 13, 11, 13);
            tabPageComments.Size = new Size(774, 568);
            tabPageComments.TabIndex = 2;
            tabPageComments.Text = "Comments";
            tabPageComments.UseVisualStyleBackColor = true;
            // 
            // btnDeleteComment
            // 
            btnDeleteComment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeleteComment.BackColor = Color.IndianRed;
            btnDeleteComment.FlatAppearance.BorderSize = 0;
            btnDeleteComment.FlatStyle = FlatStyle.Flat;
            btnDeleteComment.ForeColor = Color.White;
            btnDeleteComment.Location = new Point(442, 507);
            btnDeleteComment.Margin = new Padding(3, 4, 3, 4);
            btnDeleteComment.Name = "btnDeleteComment";
            btnDeleteComment.Size = new Size(101, 40);
            btnDeleteComment.TabIndex = 4;
            btnDeleteComment.Text = "Delete";
            btnDeleteComment.UseVisualStyleBackColor = false;
            btnDeleteComment.Click += btnDeleteComment_Click;
            // 
            // btnEditComment
            // 
            btnEditComment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditComment.BackColor = Color.SteelBlue;
            btnEditComment.FlatAppearance.BorderSize = 0;
            btnEditComment.FlatStyle = FlatStyle.Flat;
            btnEditComment.ForeColor = Color.White;
            btnEditComment.Location = new Point(550, 507);
            btnEditComment.Margin = new Padding(3, 4, 3, 4);
            btnEditComment.Name = "btnEditComment";
            btnEditComment.Size = new Size(101, 40);
            btnEditComment.TabIndex = 3;
            btnEditComment.Text = "Edit";
            btnEditComment.UseVisualStyleBackColor = false;
            btnEditComment.Click += btnEditComment_Click;
            // 
            // btnAddComment
            // 
            btnAddComment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddComment.BackColor = Color.SteelBlue;
            btnAddComment.FlatAppearance.BorderSize = 0;
            btnAddComment.FlatStyle = FlatStyle.Flat;
            btnAddComment.ForeColor = Color.White;
            btnAddComment.Location = new Point(657, 507);
            btnAddComment.Margin = new Padding(3, 4, 3, 4);
            btnAddComment.Name = "btnAddComment";
            btnAddComment.Size = new Size(101, 40);
            btnAddComment.TabIndex = 2;
            btnAddComment.Text = "Add Comment";
            btnAddComment.UseVisualStyleBackColor = false;
            btnAddComment.Click += btnAddComment_Click;
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.Location = new Point(11, 507);
            txtComment.Margin = new Padding(3, 4, 3, 4);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(425, 39);
            txtComment.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(lvComments);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(11, 13);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(752, 480);
            panel4.TabIndex = 0;
            // 
            // lvComments
            // 
            lvComments.ShowItemToolTips = true;
            lvComments.Columns.AddRange(new ColumnHeader[] { commentHeaderAuthor, commentHeaderComment, commentHeaderDateCreated });
            lvComments.Dock = DockStyle.Fill;
            lvComments.FullRowSelect = true;
            lvComments.GridLines = true;
            lvComments.Location = new Point(0, 0);
            lvComments.Margin = new Padding(3, 4, 3, 4);
            lvComments.Name = "lvComments";
            lvComments.Size = new Size(752, 480);
            lvComments.TabIndex = 0;
            lvComments.UseCompatibleStateImageBehavior = false;
            lvComments.View = View.Details;
            // 
            // columnHeader3
            // 
            commentHeaderAuthor.Text = "Author";
            commentHeaderAuthor.Width = 150;
            // 
            // columnHeader4
            // 
            commentHeaderComment.Text = "Comment";
            commentHeaderComment.Width = 350;
            // 
            // columnHeader5
            // 
            commentHeaderDateCreated.Text = "Date Created";
            commentHeaderDateCreated.Width = 150;
            // 
            // TicketDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 850);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(797, 784);
            Name = "TicketDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ticket Details";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageDetails.ResumeLayout(false);
            tabPageDetails.PerformLayout();
            gbDates.ResumeLayout(false);
            gbDates.PerformLayout();
            gbStatus.ResumeLayout(false);
            gbType.ResumeLayout(false);
            gbPriority.ResumeLayout(false);
            gbCategory.ResumeLayout(false);
            tabPageSubtasks.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabPageComments.ResumeLayout(false);
            tabPageComments.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.GroupBox gbDates;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox gbPriority;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageSubtasks;
        private System.Windows.Forms.Button btnAddSubTask;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvSubtasks;
        private System.Windows.Forms.ColumnHeader subTaskHeaderTitle;
        private System.Windows.Forms.ColumnHeader subTaskHeaderIsComplete;
        private System.Windows.Forms.TabPage tabPageComments;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnEditComment;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lvComments;
        private System.Windows.Forms.ColumnHeader commentHeaderAuthor;
        private System.Windows.Forms.ColumnHeader commentHeaderComment;
        private System.Windows.Forms.ColumnHeader commentHeaderDateCreated;
        private System.Windows.Forms.Button btnDeleteSubTask;
        private System.Windows.Forms.Button btnToggleComplete;
    }
}