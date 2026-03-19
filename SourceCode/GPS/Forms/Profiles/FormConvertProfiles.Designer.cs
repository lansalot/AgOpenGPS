namespace AgOpenGPS.Forms.Profiles
{
    partial class FormConvertProfiles
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
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.labelStep2 = new System.Windows.Forms.Label();
            this.panelEnv = new System.Windows.Forms.Panel();
            this.textBoxEnvName = new System.Windows.Forms.TextBox();
            this.labelEnvName = new System.Windows.Forms.Label();
            this.btnToggleEnv = new System.Windows.Forms.Button();
            this.panelTool = new System.Windows.Forms.Panel();
            this.textBoxToolName = new System.Windows.Forms.TextBox();
            this.labelToolName = new System.Windows.Forms.Label();
            this.panelVehicle = new System.Windows.Forms.Panel();
            this.textBoxVehicleName = new System.Windows.Forms.TextBox();
            this.labelVehicleName = new System.Windows.Forms.Label();
            this.btnToggleVehicle = new System.Windows.Forms.Button();
            this.labelStep1 = new System.Windows.Forms.Label();
            this.labelExplanation = new System.Windows.Forms.Label();
            this.panelDetails.SuspendLayout();
            this.panelEnv.SuspendLayout();
            this.panelTool.SuspendLayout();
            this.panelVehicle.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewFiles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName});
            this.listViewFiles.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.GridLines = true;
            this.listViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.LabelWrap = false;
            this.listViewFiles.Location = new System.Drawing.Point(20, 130);
            this.listViewFiles.Margin = new System.Windows.Forms.Padding(0);
            this.listViewFiles.MultiSelect = false;
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(430, 380);
            this.listViewFiles.TabIndex = 1;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "File Name";
            this.columnHeaderName.Width = 280;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(860, 35);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Convert Old Profile Files to New Format";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic);
            this.labelStatus.Location = new System.Drawing.Point(20, 520);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(400, 30);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Enabled = false;
            this.buttonConvert.FlatAppearance.BorderSize = 0;
            this.buttonConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConvert.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.buttonConvert.Image = global::AgOpenGPS.Properties.Resources.Play;
            this.buttonConvert.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonConvert.Location = new System.Drawing.Point(741, 548);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(120, 90);
            this.buttonConvert.TabIndex = 4;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Tahoma", 14F);
            this.buttonClose.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClose.Location = new System.Drawing.Point(905, 539);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(73, 99);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panelDetails
            // 
            this.panelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetails.Controls.Add(this.labelStep2);
            this.panelDetails.Controls.Add(this.panelEnv);
            this.panelDetails.Controls.Add(this.panelTool);
            this.panelDetails.Controls.Add(this.panelVehicle);
            this.panelDetails.Enabled = false;
            this.panelDetails.Location = new System.Drawing.Point(468, 130);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(520, 380);
            this.panelDetails.TabIndex = 2;
            // 
            // labelStep2
            // 
            this.labelStep2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelStep2.Location = new System.Drawing.Point(10, 5);
            this.labelStep2.Name = "labelStep2";
            this.labelStep2.Size = new System.Drawing.Size(500, 25);
            this.labelStep2.TabIndex = 8;
            this.labelStep2.Text = "Step 2: Vehicle and Environment are optional:";
            // 
            // panelEnv
            // 
            this.panelEnv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEnv.Controls.Add(this.textBoxEnvName);
            this.panelEnv.Controls.Add(this.labelEnvName);
            this.panelEnv.Controls.Add(this.btnToggleEnv);
            this.panelEnv.Location = new System.Drawing.Point(10, 302);
            this.panelEnv.Name = "panelEnv";
            this.panelEnv.Size = new System.Drawing.Size(500, 75);
            this.panelEnv.TabIndex = 7;
            // 
            // textBoxEnvName
            // 
            this.textBoxEnvName.Enabled = false;
            this.textBoxEnvName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnvName.Location = new System.Drawing.Point(145, 38);
            this.textBoxEnvName.Name = "textBoxEnvName";
            this.textBoxEnvName.Size = new System.Drawing.Size(345, 36);
            this.textBoxEnvName.TabIndex = 2;
            this.textBoxEnvName.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxEnvName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelEnvName
            // 
            this.labelEnvName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelEnvName.Location = new System.Drawing.Point(145, 8);
            this.labelEnvName.Name = "labelEnvName";
            this.labelEnvName.Size = new System.Drawing.Size(345, 25);
            this.labelEnvName.TabIndex = 1;
            this.labelEnvName.Text = "Environment profile name:";
            // 
            // btnToggleEnv
            // 
            this.btnToggleEnv.BackColor = System.Drawing.Color.LightGray;
            this.btnToggleEnv.FlatAppearance.BorderSize = 0;
            this.btnToggleEnv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleEnv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleEnv.ForeColor = System.Drawing.Color.Black;
            this.btnToggleEnv.Location = new System.Drawing.Point(10, 10);
            this.btnToggleEnv.Name = "btnToggleEnv";
            this.btnToggleEnv.Size = new System.Drawing.Size(125, 55);
            this.btnToggleEnv.TabIndex = 0;
            this.btnToggleEnv.Text = "Environment: OFF";
            this.btnToggleEnv.UseVisualStyleBackColor = false;
            this.btnToggleEnv.Click += new System.EventHandler(this.btnToggleEnv_Click);
            // 
            // panelTool
            // 
            this.panelTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTool.Controls.Add(this.textBoxToolName);
            this.panelTool.Controls.Add(this.labelToolName);
            this.panelTool.Location = new System.Drawing.Point(10, 33);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(500, 80);
            this.panelTool.TabIndex = 6;
            // 
            // textBoxToolName
            // 
            this.textBoxToolName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxToolName.Location = new System.Drawing.Point(15, 38);
            this.textBoxToolName.Name = "textBoxToolName";
            this.textBoxToolName.Size = new System.Drawing.Size(475, 36);
            this.textBoxToolName.TabIndex = 2;
            this.textBoxToolName.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxToolName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelToolName
            // 
            this.labelToolName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelToolName.Location = new System.Drawing.Point(15, 10);
            this.labelToolName.Name = "labelToolName";
            this.labelToolName.Size = new System.Drawing.Size(475, 25);
            this.labelToolName.TabIndex = 1;
            this.labelToolName.Text = "Tool profile name (always exported):";
            // 
            // panelVehicle
            // 
            this.panelVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVehicle.Controls.Add(this.textBoxVehicleName);
            this.panelVehicle.Controls.Add(this.labelVehicleName);
            this.panelVehicle.Controls.Add(this.btnToggleVehicle);
            this.panelVehicle.Location = new System.Drawing.Point(10, 139);
            this.panelVehicle.Name = "panelVehicle";
            this.panelVehicle.Size = new System.Drawing.Size(500, 100);
            this.panelVehicle.TabIndex = 5;
            // 
            // textBoxVehicleName
            // 
            this.textBoxVehicleName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVehicleName.Location = new System.Drawing.Point(145, 48);
            this.textBoxVehicleName.Name = "textBoxVehicleName";
            this.textBoxVehicleName.Size = new System.Drawing.Size(345, 36);
            this.textBoxVehicleName.TabIndex = 2;
            this.textBoxVehicleName.Click += new System.EventHandler(this.TextBox_Click);
            this.textBoxVehicleName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelVehicleName
            // 
            this.labelVehicleName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelVehicleName.Location = new System.Drawing.Point(145, 10);
            this.labelVehicleName.Name = "labelVehicleName";
            this.labelVehicleName.Size = new System.Drawing.Size(345, 30);
            this.labelVehicleName.TabIndex = 1;
            this.labelVehicleName.Text = "Vehicle profile name:";
            // 
            // btnToggleVehicle
            // 
            this.btnToggleVehicle.BackColor = System.Drawing.Color.LightGreen;
            this.btnToggleVehicle.FlatAppearance.BorderSize = 0;
            this.btnToggleVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleVehicle.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnToggleVehicle.ForeColor = System.Drawing.Color.Black;
            this.btnToggleVehicle.Location = new System.Drawing.Point(10, 10);
            this.btnToggleVehicle.Name = "btnToggleVehicle";
            this.btnToggleVehicle.Size = new System.Drawing.Size(125, 80);
            this.btnToggleVehicle.TabIndex = 0;
            this.btnToggleVehicle.Text = "Vehicle ✓ ON";
            this.btnToggleVehicle.UseVisualStyleBackColor = false;
            this.btnToggleVehicle.Click += new System.EventHandler(this.btnToggleVehicle_Click);
            // 
            // labelStep1
            // 
            this.labelStep1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelStep1.Location = new System.Drawing.Point(20, 100);
            this.labelStep1.Name = "labelStep1";
            this.labelStep1.Size = new System.Drawing.Size(320, 25);
            this.labelStep1.TabIndex = 20;
            this.labelStep1.Text = "Step 1: Select an old profile file:";
            // 
            // labelExplanation
            // 
            this.labelExplanation.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelExplanation.Location = new System.Drawing.Point(20, 55);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new System.Drawing.Size(860, 40);
            this.labelExplanation.TabIndex = 21;
            this.labelExplanation.Text = "Old profiles contained all settings in one file. New format separates Vehicle, To" +
    "ol, and Environment. Select what you want to extract.";
            // 
            // FormConvertProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1008, 650);
            this.ControlBox = false;
            this.Controls.Add(this.labelExplanation);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.labelStep1);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "FormConvertProfiles";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert Old Profiles";
            this.Load += new System.EventHandler(this.FormConvertProfiles_Load);
            this.panelDetails.ResumeLayout(false);
            this.panelEnv.ResumeLayout(false);
            this.panelEnv.PerformLayout();
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.panelVehicle.ResumeLayout(false);
            this.panelVehicle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Button btnToggleVehicle;
        private System.Windows.Forms.Button btnToggleEnv;
        private System.Windows.Forms.TextBox textBoxVehicleName;
        private System.Windows.Forms.TextBox textBoxToolName;
        private System.Windows.Forms.TextBox textBoxEnvName;
        private System.Windows.Forms.Label labelStep1;
        private System.Windows.Forms.Label labelStep2;
        private System.Windows.Forms.Label labelVehicleName;
        private System.Windows.Forms.Label labelToolName;
        private System.Windows.Forms.Label labelEnvName;
        private System.Windows.Forms.Label labelExplanation;
        private System.Windows.Forms.Panel panelVehicle;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Panel panelEnv;

        // Toggle states
        private bool vehicleEnabled = true;
        private bool environmentEnabled = false;
    }
}
