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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.gbDates = new System.Windows.Forms.GroupBox();
            this.lblModified = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.gbPriority = new System.Windows.Forms.GroupBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSubtasks = new System.Windows.Forms.TabPage();
            this.btnAddSubTask = new System.Windows.Forms.Button();
            this.btnDeleteSubTask = new System.Windows.Forms.Button();
            this.btnToggleComplete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvSubtasks = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabPageComments = new System.Windows.Forms.TabPage();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lvComments = new System.Windows.Forms.ListView();
            this.btnEditComment = new System.Windows.Forms.Button();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.gbDates.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbPriority.SuspendLayout();
            this.gbCategory.SuspendLayout();
            this.tabPageSubtasks.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPageComments.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(114, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ticket Details";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 511);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 50);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Location = new System.Drawing.Point(597, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(516, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.Visible = false;  // Hidden by default, only shown for existing tickets
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDetails);
            this.tabControl1.Controls.Add(this.tabPageSubtasks);
            this.tabControl1.Controls.Add(this.tabPageComments);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 451);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.gbDates);
            this.tabPageDetails.Controls.Add(this.gbStatus);
            this.tabPageDetails.Controls.Add(this.gbType);
            this.tabPageDetails.Controls.Add(this.gbPriority);
            this.tabPageDetails.Controls.Add(this.gbCategory);
            this.tabPageDetails.Controls.Add(this.txtDescription);
            this.tabPageDetails.Controls.Add(this.label2);
            this.tabPageDetails.Controls.Add(this.txtTitle);
            this.tabPageDetails.Controls.Add(this.label1);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 24);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageDetails.Size = new System.Drawing.Size(676, 423);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // gbDates
            // 
            this.gbDates.Controls.Add(this.lblModified);
            this.gbDates.Controls.Add(this.label5);
            this.gbDates.Controls.Add(this.lblCreated);
            this.gbDates.Controls.Add(this.label3);
            this.gbDates.Controls.Add(this.dtpDueDate);
            this.gbDates.Controls.Add(this.chkDueDate);
            this.gbDates.Location = new System.Drawing.Point(350, 240);
            this.gbDates.Name = "gbDates";
            this.gbDates.Size = new System.Drawing.Size(300, 170);
            this.gbDates.TabIndex = 8;
            this.gbDates.TabStop = false;
            this.gbDates.Text = "Dates";
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(80, 85);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(38, 15);
            this.lblModified.TabIndex = 5;
            this.lblModified.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Modified:";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(80, 55);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(38, 15);
            this.lblCreated.TabIndex = 3;
            this.lblCreated.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Created:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(80, 20);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDueDate.TabIndex = 1;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.Location = new System.Drawing.Point(15, 25);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(59, 19);
            this.chkDueDate.TabIndex = 0;
            this.chkDueDate.Text = "Due on";
            this.chkDueDate.UseVisualStyleBackColor = true;
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.cmbStatus);
            this.gbStatus.Location = new System.Drawing.Point(350, 170);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(300, 60);
            this.gbStatus.TabIndex = 7;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(15, 25);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(270, 23);
            this.cmbStatus.TabIndex = 0;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.cmbType);
            this.gbType.Location = new System.Drawing.Point(350, 100);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(300, 60);
            this.gbType.TabIndex = 6;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(15, 25);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(270, 23);
            this.cmbType.TabIndex = 0;
            // 
            // gbPriority
            // 
            this.gbPriority.Controls.Add(this.cmbPriority);
            this.gbPriority.Location = new System.Drawing.Point(350, 30);
            this.gbPriority.Name = "gbPriority";
            this.gbPriority.Size = new System.Drawing.Size(300, 60);
            this.gbPriority.TabIndex = 5;
            this.gbPriority.TabStop = false;
            this.gbPriority.Text = "Priority";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(15, 25);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(270, 23);
            this.cmbPriority.TabIndex = 0;
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.cmbCategory);
            this.gbCategory.Location = new System.Drawing.Point(20, 170);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(300, 60);
            this.gbCategory.TabIndex = 4;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(15, 25);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(270, 23);
            this.cmbCategory.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(20, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(20, 30);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // tabPageSubtasks
            // 
            this.tabPageSubtasks.Controls.Add(this.btnAddSubTask);
            this.tabPageSubtasks.Controls.Add(this.panel3);
            this.tabPageSubtasks.Controls.Add(this.btnToggleComplete);
            this.tabPageSubtasks.Controls.Add(this.btnDeleteSubTask);
            this.tabPageSubtasks.Location = new System.Drawing.Point(4, 24);
            this.tabPageSubtasks.Name = "tabPageSubtasks";
            this.tabPageSubtasks.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageSubtasks.Size = new System.Drawing.Size(676, 423);
            this.tabPageSubtasks.TabIndex = 1;
            this.tabPageSubtasks.Text = "Subtasks";
            this.tabPageSubtasks.UseVisualStyleBackColor = true;

            this.btnToggleComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleComplete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnToggleComplete.FlatAppearance.BorderSize = 0;
            this.btnToggleComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleComplete.ForeColor = System.Drawing.Color.White;
            this.btnToggleComplete.Location = new System.Drawing.Point(395, 380);
            this.btnToggleComplete.Name = "btnToggleComplete";
            this.btnToggleComplete.Size = new System.Drawing.Size(120, 30);
            this.btnToggleComplete.TabIndex = 2;
            this.btnToggleComplete.Text = "Toggle Complete";
            this.btnToggleComplete.UseVisualStyleBackColor = false;
            this.btnToggleComplete.Click += new System.EventHandler(this.btnToggleComplete_Click);

            this.btnDeleteSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSubTask.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteSubTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteSubTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSubTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSubTask.Location = new System.Drawing.Point(269, 380);
            this.btnDeleteSubTask.Name = "btnDeleteSubTask";
            this.btnDeleteSubTask.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteSubTask.TabIndex = 3;
            this.btnDeleteSubTask.Text = "Delete Subtask";
            this.btnDeleteSubTask.UseVisualStyleBackColor = false;
            this.btnDeleteSubTask.Click += new System.EventHandler(this.btnDeleteSubTask_Click);
            // 
            // btnAddSubTask
            // 
            this.btnAddSubTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSubTask.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddSubTask.FlatAppearance.BorderSize = 0;
            this.btnAddSubTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubTask.ForeColor = System.Drawing.Color.White;
            this.btnAddSubTask.Location = new System.Drawing.Point(575, 380);
            this.btnAddSubTask.Name = "btnAddSubTask";
            this.btnAddSubTask.Size = new System.Drawing.Size(88, 30);
            this.btnAddSubTask.TabIndex = 1;
            this.btnAddSubTask.Text = "Add Subtask";
            this.btnAddSubTask.UseVisualStyleBackColor = false;
            this.btnAddSubTask.Click += new System.EventHandler(this.btnAddSubTask_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvSubtasks);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(656, 360);
            this.panel3.TabIndex = 0;
            // 
            // lvSubtasks
            // 
            this.lvSubtasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSubtasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubtasks.FullRowSelect = true;
            this.lvSubtasks.GridLines = true;
            this.lvSubtasks.Location = new System.Drawing.Point(0, 0);
            this.lvSubtasks.Name = "lvSubtasks";
            this.lvSubtasks.Size = new System.Drawing.Size(656, 360);
            this.lvSubtasks.TabIndex = 0;
            this.lvSubtasks.UseCompatibleStateImageBehavior = false;
            this.lvSubtasks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 500;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Completed";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // tabPageComments
            // 
            this.tabPageComments.Controls.Add(this.btnDeleteComment);
            this.tabPageComments.Controls.Add(this.btnEditComment);
            this.tabPageComments.Controls.Add(this.btnAddComment);
            this.tabPageComments.Controls.Add(this.txtComment);
            this.tabPageComments.Controls.Add(this.panel4);
            this.tabPageComments.Location = new System.Drawing.Point(4, 24);
            this.tabPageComments.Name = "tabPageComments";
            this.tabPageComments.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageComments.Size = new System.Drawing.Size(676, 423);
            this.tabPageComments.TabIndex = 2;
            this.tabPageComments.Text = "Comments";
            this.tabPageComments.UseVisualStyleBackColor = true;

            // 
            // btnEditComment
            // 
            this.btnEditComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditComment.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditComment.FlatAppearance.BorderSize = 0;
            this.btnEditComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditComment.ForeColor = System.Drawing.Color.White;
            this.btnEditComment.Location = new System.Drawing.Point(481, 380);
            this.btnEditComment.Name = "btnEditComment";
            this.btnEditComment.Size = new System.Drawing.Size(88, 30);
            this.btnEditComment.TabIndex = 3;
            this.btnEditComment.Text = "Edit";
            this.btnEditComment.UseVisualStyleBackColor = false;
            this.btnEditComment.Click += new System.EventHandler(this.btnEditComment_Click);
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteComment.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteComment.FlatAppearance.BorderSize = 0;
            this.btnDeleteComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteComment.ForeColor = System.Drawing.Color.White;
            this.btnDeleteComment.Location = new System.Drawing.Point(387, 380);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(88, 30);
            this.btnDeleteComment.TabIndex = 4;
            this.btnDeleteComment.Text = "Delete";
            this.btnDeleteComment.UseVisualStyleBackColor = false;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddComment.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddComment.FlatAppearance.BorderSize = 0;
            this.btnAddComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.Location = new System.Drawing.Point(575, 380);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(88, 30);
            this.btnAddComment.TabIndex = 2;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = false;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(10, 380);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(559, 30);
            this.txtComment.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lvComments);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(656, 360);
            this.panel4.TabIndex = 0;
            // 
            // lvComments
            // 
            this.lvComments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComments.FullRowSelect = true;
            this.lvComments.GridLines = true;
            this.lvComments.Location = new System.Drawing.Point(0, 0);
            this.lvComments.Name = "lvComments";
            this.lvComments.Size = new System.Drawing.Size(656, 360);
            this.lvComments.TabIndex = 0;
            this.lvComments.UseCompatibleStateImageBehavior = false;
            this.lvComments.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Author";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Comment";
            this.columnHeader4.Width = 350;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date";
            this.columnHeader5.Width = 150;
            // 
            // TicketDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "TicketDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ticket Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageDetails.PerformLayout();
            this.gbDates.ResumeLayout(false);
            this.gbDates.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.gbType.ResumeLayout(false);
            this.gbPriority.ResumeLayout(false);
            this.gbCategory.ResumeLayout(false);
            this.tabPageSubtasks.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPageComments.ResumeLayout(false);
            this.tabPageComments.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPageComments;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnEditComment;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lvComments;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnDeleteSubTask;
        private System.Windows.Forms.Button btnToggleComplete;
    }
}