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
            this.btnStatusSelectNone = new System.Windows.Forms.Button();
            this.btnStatusSelectAll = new System.Windows.Forms.Button();
            this.clbStatus = new System.Windows.Forms.CheckedListBox();
            this.gbCreatedDateRange = new System.Windows.Forms.GroupBox();
            this.dtpToCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.lblToCreatedDate = new System.Windows.Forms.Label();
            this.chkToCreatedDate = new System.Windows.Forms.CheckBox();
            this.dtpFromCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromCreatedDate = new System.Windows.Forms.Label();
            this.chkFromCreatedDate = new System.Windows.Forms.CheckBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.btnTypeSelectNone = new System.Windows.Forms.Button();
            this.btnTypeSelectAll = new System.Windows.Forms.Button();
            this.clbType = new System.Windows.Forms.CheckedListBox();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.btnCategorySelectNone = new System.Windows.Forms.Button();
            this.btnCategorySelectAll = new System.Windows.Forms.Button();
            this.clbCategory = new System.Windows.Forms.CheckedListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbModifiedDateRange = new System.Windows.Forms.GroupBox();
            this.dtpToModifiedDate = new System.Windows.Forms.DateTimePicker();
            this.lblToModifiedDate = new System.Windows.Forms.Label();
            this.chkToModifiedDate = new System.Windows.Forms.CheckBox();
            this.dtpFromModifiedDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromModifiedDate = new System.Windows.Forms.Label();
            this.chkFromModifiedDate = new System.Windows.Forms.CheckBox();
            this.gbStatus.SuspendLayout();
            this.gbCreatedDateRange.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbCategory.SuspendLayout();
            this.gbModifiedDateRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.btnStatusSelectNone);
            this.gbStatus.Controls.Add(this.btnStatusSelectAll);
            this.gbStatus.Controls.Add(this.clbStatus);
            this.gbStatus.Location = new System.Drawing.Point(15, 15);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(395, 170);
            this.gbStatus.TabIndex = 0;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status (Select multiple)";
            // 
            // btnStatusSelectNone
            // 
            this.btnStatusSelectNone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStatusSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnStatusSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusSelectNone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusSelectNone.Location = new System.Drawing.Point(98, 142);
            this.btnStatusSelectNone.Name = "btnStatusSelectNone";
            this.btnStatusSelectNone.Size = new System.Drawing.Size(85, 25);
            this.btnStatusSelectNone.TabIndex = 2;
            this.btnStatusSelectNone.Text = "None";
            this.btnStatusSelectNone.UseVisualStyleBackColor = false;
            this.btnStatusSelectNone.Click += new System.EventHandler(this.btnStatusSelectNone_Click);
            // 
            // btnStatusSelectAll
            // 
            this.btnStatusSelectAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStatusSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnStatusSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusSelectAll.Location = new System.Drawing.Point(7, 142);
            this.btnStatusSelectAll.Name = "btnStatusSelectAll";
            this.btnStatusSelectAll.Size = new System.Drawing.Size(85, 25);
            this.btnStatusSelectAll.TabIndex = 1;
            this.btnStatusSelectAll.Text = "Select All";
            this.btnStatusSelectAll.UseVisualStyleBackColor = false;
            this.btnStatusSelectAll.Click += new System.EventHandler(this.btnStatusSelectAll_Click);
            // 
            // clbStatus
            // 
            this.clbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbStatus.CheckOnClick = true;
            this.clbStatus.FormattingEnabled = true;
            this.clbStatus.Location = new System.Drawing.Point(6, 19);
            this.clbStatus.Name = "clbStatus";
            this.clbStatus.ScrollAlwaysVisible = true;
            this.clbStatus.Size = new System.Drawing.Size(383, 118);
            this.clbStatus.TabIndex = 0;
            // 
            // gbCreatedDateRange
            // 
            this.gbCreatedDateRange.Controls.Add(this.dtpToCreatedDate);
            this.gbCreatedDateRange.Controls.Add(this.lblToCreatedDate);
            this.gbCreatedDateRange.Controls.Add(this.chkToCreatedDate);
            this.gbCreatedDateRange.Controls.Add(this.dtpFromCreatedDate);
            this.gbCreatedDateRange.Controls.Add(this.lblFromCreatedDate);
            this.gbCreatedDateRange.Controls.Add(this.chkFromCreatedDate);
            this.gbCreatedDateRange.Location = new System.Drawing.Point(15, 196);
            this.gbCreatedDateRange.Name = "gbCreatedDateRange";
            this.gbCreatedDateRange.Size = new System.Drawing.Size(395, 120);
            this.gbCreatedDateRange.TabIndex = 1;
            this.gbCreatedDateRange.TabStop = false;
            this.gbCreatedDateRange.Text = "Date Range (Created)";
            // 
            // dtpToCreatedDate
            // 
            this.dtpToCreatedDate.Enabled = false;
            this.dtpToCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToCreatedDate.Location = new System.Drawing.Point(140, 80);
            this.dtpToCreatedDate.Name = "dtpToCreatedDate";
            this.dtpToCreatedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpToCreatedDate.TabIndex = 5;
            // 
            // lblToCreatedDate
            // 
            this.lblToCreatedDate.AutoSize = true;
            this.lblToCreatedDate.Location = new System.Drawing.Point(105, 85);
            this.lblToCreatedDate.Name = "lblToCreatedDate";
            this.lblToCreatedDate.Size = new System.Drawing.Size(19, 15);
            this.lblToCreatedDate.TabIndex = 4;
            this.lblToCreatedDate.Text = "To";
            // 
            // chkToCreatedDate
            // 
            this.chkToCreatedDate.AutoSize = true;
            this.chkToCreatedDate.Location = new System.Drawing.Point(15, 85);
            this.chkToCreatedDate.Name = "chkToCreatedDate";
            this.chkToCreatedDate.Size = new System.Drawing.Size(15, 14);
            this.chkToCreatedDate.TabIndex = 3;
            this.chkToCreatedDate.UseVisualStyleBackColor = true;
            this.chkToCreatedDate.CheckedChanged += new System.EventHandler(this.chkToCreatedDate_CheckedChanged);
            // 
            // dtpFromCreatedDate
            // 
            this.dtpFromCreatedDate.Enabled = false;
            this.dtpFromCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromCreatedDate.Location = new System.Drawing.Point(140, 40);
            this.dtpFromCreatedDate.Name = "dtpFromCreatedDate";
            this.dtpFromCreatedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpFromCreatedDate.TabIndex = 2;
            // 
            // lblFromCreatedDate
            // 
            this.lblFromCreatedDate.AutoSize = true;
            this.lblFromCreatedDate.Location = new System.Drawing.Point(95, 45);
            this.lblFromCreatedDate.Name = "lblFromCreatedDate";
            this.lblFromCreatedDate.Size = new System.Drawing.Size(35, 15);
            this.lblFromCreatedDate.TabIndex = 1;
            this.lblFromCreatedDate.Text = "From";
            // 
            // chkFromCreatedDate
            // 
            this.chkFromCreatedDate.AutoSize = true;
            this.chkFromCreatedDate.Location = new System.Drawing.Point(15, 45);
            this.chkFromCreatedDate.Name = "chkFromCreatedDate";
            this.chkFromCreatedDate.Size = new System.Drawing.Size(15, 14);
            this.chkFromCreatedDate.TabIndex = 0;
            this.chkFromCreatedDate.UseVisualStyleBackColor = true;
            this.chkFromCreatedDate.CheckedChanged += new System.EventHandler(this.chkFromCreatedDate_CheckedChanged);
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.btnTypeSelectNone);
            this.gbType.Controls.Add(this.btnTypeSelectAll);
            this.gbType.Controls.Add(this.clbType);
            this.gbType.Location = new System.Drawing.Point(15, 490);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(195, 170);
            this.gbType.TabIndex = 2;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type (Select multiple)";
            //
            // btnTypeSelectAll
            //
            this.btnTypeSelectAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTypeSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTypeSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTypeSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeSelectAll.Location = new System.Drawing.Point(12, 142);
            this.btnTypeSelectAll.Name = "btnTypeSelectAll";
            this.btnTypeSelectAll.Size = new System.Drawing.Size(85, 25);
            this.btnTypeSelectAll.TabIndex = 1;
            this.btnTypeSelectAll.Text = "Select All";
            this.btnTypeSelectAll.UseVisualStyleBackColor = false;
            this.btnTypeSelectAll.Click += new System.EventHandler(this.btnTypeSelectAll_Click);
            //
            // btnTypeSelectNone
            //
            this.btnTypeSelectNone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTypeSelectNone.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnTypeSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTypeSelectNone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeSelectNone.Location = new System.Drawing.Point(103, 142);
            this.btnTypeSelectNone.Name = "btnTypeSelectNone";
            this.btnTypeSelectNone.Size = new System.Drawing.Size(85, 25);
            this.btnTypeSelectNone.TabIndex = 2;
            this.btnTypeSelectNone.Text = "None";
            this.btnTypeSelectNone.UseVisualStyleBackColor = false;
            this.btnTypeSelectNone.Click += new System.EventHandler(this.btnTypeSelectNone_Click);
            // 
            // clbType
            // 
            this.clbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbType.CheckOnClick = true;
            this.clbType.FormattingEnabled = true;
            this.clbType.Location = new System.Drawing.Point(6, 19);
            this.clbType.Name = "clbType";
            this.clbType.ScrollAlwaysVisible = true;
            this.clbType.Size = new System.Drawing.Size(183, 118);
            this.clbType.TabIndex = 0;
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.btnCategorySelectNone);
            this.gbCategory.Controls.Add(this.btnCategorySelectAll);
            this.gbCategory.Controls.Add(this.clbCategory);
            this.gbCategory.Location = new System.Drawing.Point(215, 490);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(195, 170);
            this.gbCategory.TabIndex = 5;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Category (Select multiple)";
            //
            // btnCategorySelectAll styling
            //
            this.btnCategorySelectAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCategorySelectAll.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCategorySelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorySelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorySelectAll.Location = new System.Drawing.Point(12, 142);
            this.btnCategorySelectAll.Name = "btnCategorySelectAll";
            this.btnCategorySelectAll.Size = new System.Drawing.Size(85, 25);
            this.btnCategorySelectAll.TabIndex = 1;
            this.btnCategorySelectAll.Text = "Select All";
            this.btnCategorySelectAll.UseVisualStyleBackColor = false;
            this.btnCategorySelectAll.Click += new System.EventHandler(this.btnCategorySelectAll_Click);
            //
            // btnCategorySelectNone styling
            //
            this.btnCategorySelectNone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCategorySelectNone.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCategorySelectNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorySelectNone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorySelectNone.Location = new System.Drawing.Point(103, 142);
            this.btnCategorySelectNone.Name = "btnCategorySelectNone";
            this.btnCategorySelectNone.Size = new System.Drawing.Size(85, 25);
            this.btnCategorySelectNone.TabIndex = 2;
            this.btnCategorySelectNone.Text = "None";
            this.btnCategorySelectNone.UseVisualStyleBackColor = false;
            this.btnCategorySelectNone.Click += new System.EventHandler(this.btnCategorySelectNone_Click);
            // 
            // clbCategory
            // 
            this.clbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCategory.CheckOnClick = true;
            this.clbCategory.FormattingEnabled = true;
            this.clbCategory.Location = new System.Drawing.Point(6, 19);
            this.clbCategory.Name = "clbCategory";
            this.clbCategory.ScrollAlwaysVisible = true;
            this.clbCategory.Size = new System.Drawing.Size(183, 118);
            this.clbCategory.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(220, 675);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(90, 35);
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
            this.btnCancel.Location = new System.Drawing.Point(320, 675);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbModifiedDateRange
            // 
            this.gbModifiedDateRange.Controls.Add(this.dtpToModifiedDate);
            this.gbModifiedDateRange.Controls.Add(this.lblToModifiedDate);
            this.gbModifiedDateRange.Controls.Add(this.chkToModifiedDate);
            this.gbModifiedDateRange.Controls.Add(this.dtpFromModifiedDate);
            this.gbModifiedDateRange.Controls.Add(this.lblFromModifiedDate);
            this.gbModifiedDateRange.Controls.Add(this.chkFromModifiedDate);
            this.gbModifiedDateRange.Location = new System.Drawing.Point(15, 332);
            this.gbModifiedDateRange.Name = "gbModifiedDateRange";
            this.gbModifiedDateRange.Size = new System.Drawing.Size(395, 120);
            this.gbModifiedDateRange.TabIndex = 6;
            this.gbModifiedDateRange.TabStop = false;
            this.gbModifiedDateRange.Text = "Date Range (Modified)";
            // 
            // dtpToModifiedDate
            // 
            this.dtpToModifiedDate.Enabled = false;
            this.dtpToModifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToModifiedDate.Location = new System.Drawing.Point(140, 80);
            this.dtpToModifiedDate.Name = "dtpToModifiedDate";
            this.dtpToModifiedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpToModifiedDate.TabIndex = 5;
            // 
            // lblToModifiedDate
            // 
            this.lblToModifiedDate.AutoSize = true;
            this.lblToModifiedDate.Location = new System.Drawing.Point(105, 85);
            this.lblToModifiedDate.Name = "lblToModifiedDate";
            this.lblToModifiedDate.Size = new System.Drawing.Size(19, 15);
            this.lblToModifiedDate.TabIndex = 4;
            this.lblToModifiedDate.Text = "To";
            // 
            // chkToModifiedDate
            // 
            this.chkToModifiedDate.AutoSize = true;
            this.chkToModifiedDate.Location = new System.Drawing.Point(15, 85);
            this.chkToModifiedDate.Name = "chkToModifiedDate";
            this.chkToModifiedDate.Size = new System.Drawing.Size(15, 14);
            this.chkToModifiedDate.TabIndex = 3;
            this.chkToModifiedDate.UseVisualStyleBackColor = true;
            this.chkToModifiedDate.CheckedChanged += new System.EventHandler(this.chkToModifiedDate_CheckedChanged);
            // 
            // dtpFromModifiedDate
            // 
            this.dtpFromModifiedDate.Enabled = false;
            this.dtpFromModifiedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromModifiedDate.Location = new System.Drawing.Point(140, 40);
            this.dtpFromModifiedDate.Name = "dtpFromModifiedDate";
            this.dtpFromModifiedDate.Size = new System.Drawing.Size(200, 23);
            this.dtpFromModifiedDate.TabIndex = 2;
            // 
            // lblFromModifiedDate
            // 
            this.lblFromModifiedDate.AutoSize = true;
            this.lblFromModifiedDate.Location = new System.Drawing.Point(95, 45);
            this.lblFromModifiedDate.Name = "lblFromModifiedDate";
            this.lblFromModifiedDate.Size = new System.Drawing.Size(35, 15);
            this.lblFromModifiedDate.TabIndex = 1;
            this.lblFromModifiedDate.Text = "From";
            // 
            // chkFromModifiedDate
            // 
            this.chkFromModifiedDate.AutoSize = true;
            this.chkFromModifiedDate.Location = new System.Drawing.Point(15, 45);
            this.chkFromModifiedDate.Name = "chkFromModifiedDate";
            this.chkFromModifiedDate.Size = new System.Drawing.Size(15, 14);
            this.chkFromModifiedDate.TabIndex = 0;
            this.chkFromModifiedDate.UseVisualStyleBackColor = true;
            this.chkFromModifiedDate.CheckedChanged += new System.EventHandler(this.chkFromModifiedDate_CheckedChanged);
            // 
            // FilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 725);
            this.Controls.Add(this.gbModifiedDateRange);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.gbCreatedDateRange);
            this.Controls.Add(this.gbStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Tickets";
            this.gbStatus.ResumeLayout(false);
            this.gbCreatedDateRange.ResumeLayout(false);
            this.gbCreatedDateRange.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbCategory.ResumeLayout(false);
            this.gbModifiedDateRange.ResumeLayout(false);
            this.gbModifiedDateRange.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.CheckedListBox clbStatus;
        private System.Windows.Forms.GroupBox gbCreatedDateRange;
        private System.Windows.Forms.DateTimePicker dtpFromCreatedDate;
        private System.Windows.Forms.DateTimePicker dtpToCreatedDate;
        private System.Windows.Forms.Label lblToCreatedDate;
        private System.Windows.Forms.CheckBox chkToCreatedDate;
        private System.Windows.Forms.Label lblFromCreatedDate;
        private System.Windows.Forms.CheckBox chkFromCreatedDate;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbCategory;
        private System.Windows.Forms.CheckedListBox clbType;
        private System.Windows.Forms.CheckedListBox clbCategory;
        private System.Windows.Forms.GroupBox gbModifiedDateRange;
        private System.Windows.Forms.DateTimePicker dtpToModifiedDate;
        private System.Windows.Forms.Label lblToModifiedDate;
        private System.Windows.Forms.CheckBox chkToModifiedDate;
        private System.Windows.Forms.DateTimePicker dtpFromModifiedDate;
        private System.Windows.Forms.Label lblFromModifiedDate;
        private System.Windows.Forms.CheckBox chkFromModifiedDate;

        private System.Windows.Forms.Button btnStatusSelectAll;
        private System.Windows.Forms.Button btnStatusSelectNone;
        private System.Windows.Forms.Button btnTypeSelectAll;
        private System.Windows.Forms.Button btnTypeSelectNone;
        private System.Windows.Forms.Button btnCategorySelectAll;
        private System.Windows.Forms.Button btnCategorySelectNone;
    }
}