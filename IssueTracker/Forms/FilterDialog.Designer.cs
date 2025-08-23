namespace IssueTracker
{
    partial class FilterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterDialog));
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.clbStatus = new System.Windows.Forms.CheckedListBox();
            this.gbDateRange = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkToDate = new System.Windows.Forms.CheckBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkFromDate = new System.Windows.Forms.CheckBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.clbType = new System.Windows.Forms.CheckedListBox();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.clbCategory = new System.Windows.Forms.CheckedListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbStatus.SuspendLayout();
            this.gbDateRange.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.clbStatus);
            this.gbStatus.Location = new System.Drawing.Point(15, 15);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(360, 140);
            this.gbStatus.TabIndex = 0;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status (Select multiple)";
            // 
            // clbStatus
            // 
            this.clbStatus.CheckOnClick = true;
            this.clbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbStatus.FormattingEnabled = true;
            this.clbStatus.Location = new System.Drawing.Point(3, 19);
            this.clbStatus.Name = "clbStatus";
            this.clbStatus.ScrollAlwaysVisible = true;
            this.clbStatus.Size = new System.Drawing.Size(354, 118);
            this.clbStatus.TabIndex = 0;
            // 
            // gbDateRange
            // 
            this.gbDateRange.Controls.Add(this.dtpToDate);
            this.gbDateRange.Controls.Add(this.label2);
            this.gbDateRange.Controls.Add(this.chkToDate);
            this.gbDateRange.Controls.Add(this.dtpFromDate);
            this.gbDateRange.Controls.Add(this.label1);
            this.gbDateRange.Controls.Add(this.chkFromDate);
            this.gbDateRange.Location = new System.Drawing.Point(15, 161);
            this.gbDateRange.Name = "gbDateRange";
            this.gbDateRange.Size = new System.Drawing.Size(360, 120);
            this.gbDateRange.TabIndex = 1;
            this.gbDateRange.TabStop = false;
            this.gbDateRange.Text = "Date Range (Created)";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(120, 80);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(180, 23);
            this.dtpToDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // chkToDate
            // 
            this.chkToDate.AutoSize = true;
            this.chkToDate.Location = new System.Drawing.Point(15, 85);
            this.chkToDate.Name = "chkToDate";
            this.chkToDate.Size = new System.Drawing.Size(15, 14);
            this.chkToDate.TabIndex = 3;
            this.chkToDate.UseVisualStyleBackColor = true;
            this.chkToDate.CheckedChanged += new System.EventHandler(this.chkToDate_CheckedChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Enabled = false;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 40);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(180, 23);
            this.dtpFromDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // chkFromDate
            // 
            this.chkFromDate.AutoSize = true;
            this.chkFromDate.Location = new System.Drawing.Point(15, 45);
            this.chkFromDate.Name = "chkFromDate";
            this.chkFromDate.Size = new System.Drawing.Size(15, 14);
            this.chkFromDate.TabIndex = 0;
            this.chkFromDate.UseVisualStyleBackColor = true;
            this.chkFromDate.CheckedChanged += new System.EventHandler(this.chkFromDate_CheckedChanged);
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.clbType);
            this.gbType.Location = new System.Drawing.Point(15, 287);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(175, 140);
            this.gbType.TabIndex = 2;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type (Select multiple)";
            // 
            // clbType
            // 
            this.clbType.CheckOnClick = true;
            this.clbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbType.FormattingEnabled = true;
            this.clbType.Location = new System.Drawing.Point(3, 19);
            this.clbType.Name = "clbType";
            this.clbType.ScrollAlwaysVisible = true;
            this.clbType.Size = new System.Drawing.Size(169, 118);
            this.clbType.TabIndex = 0;
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.clbCategory);
            this.gbCategory.Location = new System.Drawing.Point(200, 287);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(175, 140);
            this.gbCategory.TabIndex = 5;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Category (Select multiple)";
            // 
            // clbCategory
            // 
            this.clbCategory.CheckOnClick = true;
            this.clbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCategory.FormattingEnabled = true;
            this.clbCategory.Location = new System.Drawing.Point(3, 19);
            this.clbCategory.Name = "clbCategory";
            this.clbCategory.ScrollAlwaysVisible = true;
            this.clbCategory.Size = new System.Drawing.Size(169, 118);
            this.clbCategory.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(200, 440);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 35);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Location = new System.Drawing.Point(290, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 487);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.gbDateRange);
            this.Controls.Add(this.gbStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Tickets";
            this.gbStatus.ResumeLayout(false);
            this.gbDateRange.ResumeLayout(false);
            this.gbDateRange.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbCategory.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.CheckedListBox clbStatus;
        private System.Windows.Forms.GroupBox gbDateRange;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFromDate;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.CheckedListBox clbType;
        private System.Windows.Forms.CheckedListBox clbCategory;
    }
}