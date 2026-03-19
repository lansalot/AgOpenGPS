namespace AgOpenGPS.Forms.Profiles
{
    partial class FormLoadEnvironment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadEnvironment));
            this.listViewProfiles = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.lblPreviewHeader = new System.Windows.Forms.Label();
            this.lblPreview1 = new System.Windows.Forms.Label();
            this.lblPreview2 = new System.Windows.Forms.Label();
            this.lblPreview3 = new System.Windows.Forms.Label();
            this.lblPreview4 = new System.Windows.Forms.Label();
            this.lblPreview5 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panelPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProfiles
            // 
            this.listViewProfiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listViewProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName});
            this.listViewProfiles.FullRowSelect = true;
            this.listViewProfiles.GridLines = true;
            this.listViewProfiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewProfiles.HideSelection = false;
            this.listViewProfiles.Location = new System.Drawing.Point(12, 35);
            this.listViewProfiles.MultiSelect = false;
            this.listViewProfiles.Name = "listViewProfiles";
            this.listViewProfiles.Size = new System.Drawing.Size(450, 380);
            this.listViewProfiles.TabIndex = 1;
            this.listViewProfiles.UseCompatibleStateImageBehavior = false;
            this.listViewProfiles.View = System.Windows.Forms.View.Details;
            this.listViewProfiles.SelectedIndexChanged += new System.EventHandler(this.listViewProfiles_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Profile Name";
            this.columnName.Width = 400;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrent.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrent.Location = new System.Drawing.Point(12, 8);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(450, 22);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "Current Environment: -";
            // 
            // lblSelected
            // 
            this.lblSelected.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Italic);
            this.lblSelected.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSelected.Location = new System.Drawing.Point(12, 420);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(450, 22);
            this.lblSelected.TabIndex = 2;
            this.lblSelected.Text = "Selected: -";
            // 
            // panelPreview
            // 
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Controls.Add(this.lblPreviewHeader);
            this.panelPreview.Controls.Add(this.lblPreview1);
            this.panelPreview.Controls.Add(this.lblPreview2);
            this.panelPreview.Controls.Add(this.lblPreview3);
            this.panelPreview.Controls.Add(this.lblPreview4);
            this.panelPreview.Controls.Add(this.lblPreview5);
            this.panelPreview.Location = new System.Drawing.Point(480, 35);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(518, 380);
            this.panelPreview.TabIndex = 3;
            // 
            // lblPreviewHeader
            // 
            this.lblPreviewHeader.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblPreviewHeader.Location = new System.Drawing.Point(10, 10);
            this.lblPreviewHeader.Name = "lblPreviewHeader";
            this.lblPreviewHeader.Size = new System.Drawing.Size(495, 28);
            this.lblPreviewHeader.TabIndex = 0;
            this.lblPreviewHeader.Text = "Select a profile";
            // 
            // lblPreview1
            // 
            this.lblPreview1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblPreview1.Location = new System.Drawing.Point(15, 50);
            this.lblPreview1.Name = "lblPreview1";
            this.lblPreview1.Size = new System.Drawing.Size(490, 22);
            this.lblPreview1.TabIndex = 1;
            // 
            // lblPreview2
            // 
            this.lblPreview2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblPreview2.Location = new System.Drawing.Point(15, 80);
            this.lblPreview2.Name = "lblPreview2";
            this.lblPreview2.Size = new System.Drawing.Size(490, 22);
            this.lblPreview2.TabIndex = 2;
            // 
            // lblPreview3
            // 
            this.lblPreview3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblPreview3.Location = new System.Drawing.Point(15, 110);
            this.lblPreview3.Name = "lblPreview3";
            this.lblPreview3.Size = new System.Drawing.Size(490, 22);
            this.lblPreview3.TabIndex = 3;
            // 
            // lblPreview4
            // 
            this.lblPreview4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblPreview4.Location = new System.Drawing.Point(15, 140);
            this.lblPreview4.Name = "lblPreview4";
            this.lblPreview4.Size = new System.Drawing.Size(490, 22);
            this.lblPreview4.TabIndex = 4;
            // 
            // lblPreview5
            // 
            this.lblPreview5.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblPreview5.Location = new System.Drawing.Point(15, 170);
            this.lblPreview5.Name = "lblPreview5";
            this.lblPreview5.Size = new System.Drawing.Size(490, 22);
            this.lblPreview5.TabIndex = 5;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Enabled = false;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.buttonLoad.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoad.Image")));
            this.buttonLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLoad.Location = new System.Drawing.Point(916, 460);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(80, 90);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(805, 460);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 90);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // buttonNew
            // 
            this.buttonNew.FlatAppearance.BorderSize = 0;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Font = new System.Drawing.Font("Tahoma", 9F);
            this.buttonNew.Image = ((System.Drawing.Image)(resources.GetObject("buttonNew.Image")));
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNew.Location = new System.Drawing.Point(12, 480);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(65, 70);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Tahoma", 9F);
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelete.Location = new System.Drawing.Point(83, 480);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(65, 70);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Enabled = false;
            this.buttonRename.FlatAppearance.BorderSize = 0;
            this.buttonRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRename.Font = new System.Drawing.Font("Tahoma", 9F);
            this.buttonRename.Image = ((System.Drawing.Image)(resources.GetObject("buttonRename.Image")));
            this.buttonRename.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRename.Location = new System.Drawing.Point(154, 480);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(65, 70);
            this.buttonRename.TabIndex = 6;
            this.buttonRename.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Tahoma", 9F);
            this.buttonReset.Image = ((System.Drawing.Image)(resources.GetObject("buttonReset.Image")));
            this.buttonReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReset.Location = new System.Drawing.Point(225, 480);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(65, 70);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormLoadEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 565);
            this.ControlBox = false;
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.listViewProfiles);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonLoad);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormLoadEnvironment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Environment Profiles";
            this.Load += new System.EventHandler(this.FormLoadEnvironment_Load);
            this.panelPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewProfiles;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label lblPreviewHeader;
        private System.Windows.Forms.Label lblPreview1;
        private System.Windows.Forms.Label lblPreview2;
        private System.Windows.Forms.Label lblPreview3;
        private System.Windows.Forms.Label lblPreview4;
        private System.Windows.Forms.Label lblPreview5;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonReset;
    }
}
