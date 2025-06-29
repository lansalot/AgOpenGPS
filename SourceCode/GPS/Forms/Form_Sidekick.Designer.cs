namespace AgOpenGPS.Forms
{
    partial class Form_Sidekick
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblskDisplay = new System.Windows.Forms.Label();
            this.lblskEXE = new System.Windows.Forms.Label();
            this.lblskInterval = new System.Windows.Forms.Label();
            this.ckskAutoRestart = new System.Windows.Forms.CheckBox();
            this.ckskStartHidden = new System.Windows.Forms.CheckBox();
            this.ckskNotification = new System.Windows.Forms.CheckBox();
            this.txtskInterval = new System.Windows.Forms.TextBox();
            this.txtskExecutable = new System.Windows.Forms.TextBox();
            this.txtskDisplayName = new System.Windows.Forms.TextBox();
            this.btnskChooseExec = new System.Windows.Forms.Button();
            this.btnRemoveSidekick = new System.Windows.Forms.Button();
            this.btnAddSidekick = new System.Windows.Forms.Button();
            this.labelDisagree = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.sidekickBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sidekickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formSidekickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.displayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restartDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notificationDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hiddenDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.intervalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidekickBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidekickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formSidekickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.displayNameDataGridViewTextBoxColumn,
            this.restartDataGridViewCheckBoxColumn,
            this.notificationDataGridViewCheckBoxColumn,
            this.hiddenDataGridViewCheckBoxColumn,
            this.intervalDataGridViewTextBoxColumn,
            this.programNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sidekickBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(17, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(771, 295);
            this.dataGridView1.TabIndex = 199;
            // 
            // lblskDisplay
            // 
            this.lblskDisplay.AutoSize = true;
            this.lblskDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblskDisplay.Location = new System.Drawing.Point(12, 407);
            this.lblskDisplay.Name = "lblskDisplay";
            this.lblskDisplay.Size = new System.Drawing.Size(92, 29);
            this.lblskDisplay.TabIndex = 202;
            this.lblskDisplay.Text = "Display";
            // 
            // lblskEXE
            // 
            this.lblskEXE.AutoSize = true;
            this.lblskEXE.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblskEXE.Location = new System.Drawing.Point(12, 451);
            this.lblskEXE.Name = "lblskEXE";
            this.lblskEXE.Size = new System.Drawing.Size(132, 29);
            this.lblskEXE.TabIndex = 203;
            this.lblskEXE.Text = "Executable";
            // 
            // lblskInterval
            // 
            this.lblskInterval.AutoSize = true;
            this.lblskInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblskInterval.Location = new System.Drawing.Point(12, 495);
            this.lblskInterval.Name = "lblskInterval";
            this.lblskInterval.Size = new System.Drawing.Size(150, 29);
            this.lblskInterval.TabIndex = 205;
            this.lblskInterval.Text = "Interval (sec)";
            // 
            // ckskAutoRestart
            // 
            this.ckskAutoRestart.AutoSize = true;
            this.ckskAutoRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckskAutoRestart.Location = new System.Drawing.Point(494, 494);
            this.ckskAutoRestart.Name = "ckskAutoRestart";
            this.ckskAutoRestart.Size = new System.Drawing.Size(111, 33);
            this.ckskAutoRestart.TabIndex = 207;
            this.ckskAutoRestart.Text = "Restart";
            this.ckskAutoRestart.UseVisualStyleBackColor = true;
            // 
            // ckskStartHidden
            // 
            this.ckskStartHidden.AutoSize = true;
            this.ckskStartHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckskStartHidden.Location = new System.Drawing.Point(306, 494);
            this.ckskStartHidden.Name = "ckskStartHidden";
            this.ckskStartHidden.Size = new System.Drawing.Size(168, 33);
            this.ckskStartHidden.TabIndex = 208;
            this.ckskStartHidden.Text = "Start Hidden";
            this.ckskStartHidden.UseVisualStyleBackColor = true;
            // 
            // ckskNotification
            // 
            this.ckskNotification.AutoSize = true;
            this.ckskNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckskNotification.Location = new System.Drawing.Point(632, 495);
            this.ckskNotification.Name = "ckskNotification";
            this.ckskNotification.Size = new System.Drawing.Size(155, 33);
            this.ckskNotification.TabIndex = 209;
            this.ckskNotification.Text = "Notification";
            this.ckskNotification.UseVisualStyleBackColor = true;
            // 
            // txtskInterval
            // 
            this.txtskInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtskInterval.Location = new System.Drawing.Point(168, 493);
            this.txtskInterval.Name = "txtskInterval";
            this.txtskInterval.Size = new System.Drawing.Size(86, 34);
            this.txtskInterval.TabIndex = 210;
            this.txtskInterval.Text = "5";
            this.txtskInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtskExecutable
            // 
            this.txtskExecutable.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtskExecutable.Location = new System.Drawing.Point(168, 448);
            this.txtskExecutable.Name = "txtskExecutable";
            this.txtskExecutable.Size = new System.Drawing.Size(541, 34);
            this.txtskExecutable.TabIndex = 211;
            // 
            // txtskDisplayName
            // 
            this.txtskDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtskDisplayName.Location = new System.Drawing.Point(168, 400);
            this.txtskDisplayName.Name = "txtskDisplayName";
            this.txtskDisplayName.Size = new System.Drawing.Size(619, 34);
            this.txtskDisplayName.TabIndex = 212;
            // 
            // btnskChooseExec
            // 
            this.btnskChooseExec.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnskChooseExec.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnskChooseExec.Location = new System.Drawing.Point(715, 448);
            this.btnskChooseExec.Name = "btnskChooseExec";
            this.btnskChooseExec.Size = new System.Drawing.Size(75, 34);
            this.btnskChooseExec.TabIndex = 213;
            this.btnskChooseExec.Text = "...";
            this.btnskChooseExec.UseVisualStyleBackColor = true;
            this.btnskChooseExec.Click += new System.EventHandler(this.btnskChooseExec_Click);
            // 
            // btnRemoveSidekick
            // 
            this.btnRemoveSidekick.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRemoveSidekick.FlatAppearance.BorderSize = 0;
            this.btnRemoveSidekick.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSidekick.Image = global::AgOpenGPS.Properties.Resources.Trash;
            this.btnRemoveSidekick.Location = new System.Drawing.Point(119, 314);
            this.btnRemoveSidekick.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveSidekick.Name = "btnRemoveSidekick";
            this.btnRemoveSidekick.Size = new System.Drawing.Size(80, 80);
            this.btnRemoveSidekick.TabIndex = 201;
            this.btnRemoveSidekick.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveSidekick.UseVisualStyleBackColor = true;
            this.btnRemoveSidekick.Click += new System.EventHandler(this.btnRemoveSidekick_Click);
            // 
            // btnAddSidekick
            // 
            this.btnAddSidekick.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddSidekick.FlatAppearance.BorderSize = 0;
            this.btnAddSidekick.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSidekick.Image = global::AgOpenGPS.Properties.Resources.AddNew;
            this.btnAddSidekick.Location = new System.Drawing.Point(16, 314);
            this.btnAddSidekick.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSidekick.Name = "btnAddSidekick";
            this.btnAddSidekick.Size = new System.Drawing.Size(80, 80);
            this.btnAddSidekick.TabIndex = 200;
            this.btnAddSidekick.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddSidekick.UseVisualStyleBackColor = true;
            this.btnAddSidekick.Click += new System.EventHandler(this.btnAddSidekick_Click);
            // 
            // labelDisagree
            // 
            this.labelDisagree.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.labelDisagree.FlatAppearance.BorderSize = 0;
            this.labelDisagree.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisagree.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.labelDisagree.Location = new System.Drawing.Point(601, 313);
            this.labelDisagree.Margin = new System.Windows.Forms.Padding(4);
            this.labelDisagree.Name = "labelDisagree";
            this.labelDisagree.Size = new System.Drawing.Size(80, 80);
            this.labelDisagree.TabIndex = 198;
            this.labelDisagree.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelDisagree.UseVisualStyleBackColor = true;
            this.labelDisagree.Click += new System.EventHandler(this.labelDisagree_Click);
            // 
            // bntOK
            // 
            this.bntOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(707, 313);
            this.bntOK.Margin = new System.Windows.Forms.Padding(4);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(80, 80);
            this.bntOK.TabIndex = 197;
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // sidekickBindingSource1
            // 
            this.sidekickBindingSource1.DataSource = typeof(AgOpenGPS.Forms.Sidekick);
            // 
            // sidekickBindingSource
            // 
            this.sidekickBindingSource.DataSource = typeof(AgOpenGPS.Forms.Sidekick);
            // 
            // formSidekickBindingSource
            // 
            this.formSidekickBindingSource.DataSource = typeof(AgOpenGPS.Forms.Form_Sidekick);
            // 
            // displayNameDataGridViewTextBoxColumn
            // 
            this.displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            this.displayNameDataGridViewTextBoxColumn.HeaderText = "DisplayName";
            this.displayNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            this.displayNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // restartDataGridViewCheckBoxColumn
            // 
            this.restartDataGridViewCheckBoxColumn.DataPropertyName = "Restart";
            this.restartDataGridViewCheckBoxColumn.HeaderText = "Restart";
            this.restartDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.restartDataGridViewCheckBoxColumn.Name = "restartDataGridViewCheckBoxColumn";
            this.restartDataGridViewCheckBoxColumn.Width = 70;
            // 
            // notificationDataGridViewCheckBoxColumn
            // 
            this.notificationDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.notificationDataGridViewCheckBoxColumn.DataPropertyName = "Notification";
            this.notificationDataGridViewCheckBoxColumn.HeaderText = "Notification";
            this.notificationDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.notificationDataGridViewCheckBoxColumn.Name = "notificationDataGridViewCheckBoxColumn";
            this.notificationDataGridViewCheckBoxColumn.Width = 79;
            // 
            // Hidden
            // 
            this.hiddenDataGridViewCheckBoxColumn.DataPropertyName = "Hidden";
            this.hiddenDataGridViewCheckBoxColumn.HeaderText = "Hidden";
            this.hiddenDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.hiddenDataGridViewCheckBoxColumn.Name = "Hidden";
            this.hiddenDataGridViewCheckBoxColumn.Width = 70;
            // 
            // intervalDataGridViewTextBoxColumn
            // 
            this.intervalDataGridViewTextBoxColumn.DataPropertyName = "Interval";
            this.intervalDataGridViewTextBoxColumn.HeaderText = "Interval";
            this.intervalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.intervalDataGridViewTextBoxColumn.Name = "intervalDataGridViewTextBoxColumn";
            this.intervalDataGridViewTextBoxColumn.Width = 70;
            // 
            // programNameDataGridViewTextBoxColumn
            // 
            this.programNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.programNameDataGridViewTextBoxColumn.DataPropertyName = "ProgramName";
            this.programNameDataGridViewTextBoxColumn.HeaderText = "ProgramName";
            this.programNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.programNameDataGridViewTextBoxColumn.Name = "programNameDataGridViewTextBoxColumn";
            // 
            // Form_Sidekick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.btnskChooseExec);
            this.Controls.Add(this.txtskDisplayName);
            this.Controls.Add(this.txtskExecutable);
            this.Controls.Add(this.txtskInterval);
            this.Controls.Add(this.ckskNotification);
            this.Controls.Add(this.ckskStartHidden);
            this.Controls.Add(this.ckskAutoRestart);
            this.Controls.Add(this.lblskInterval);
            this.Controls.Add(this.lblskEXE);
            this.Controls.Add(this.lblskDisplay);
            this.Controls.Add(this.btnRemoveSidekick);
            this.Controls.Add(this.btnAddSidekick);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelDisagree);
            this.Controls.Add(this.bntOK);
            this.Name = "Form_Sidekick";
            this.Text = "Sidekick Manager";
            this.Load += new System.EventHandler(this.frmLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidekickBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidekickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formSidekickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.Button labelDisagree;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource formSidekickBindingSource;
        private System.Windows.Forms.Button btnAddSidekick;
        private System.Windows.Forms.Button btnRemoveSidekick;
        private System.Windows.Forms.Label lblskDisplay;
        private System.Windows.Forms.Label lblskEXE;
        private System.Windows.Forms.Label lblskInterval;
        private System.Windows.Forms.CheckBox ckskAutoRestart;
        private System.Windows.Forms.CheckBox ckskStartHidden;
        private System.Windows.Forms.CheckBox ckskNotification;
        private System.Windows.Forms.TextBox txtskInterval;
        private System.Windows.Forms.TextBox txtskExecutable;
        private System.Windows.Forms.TextBox txtskDisplayName;
        private System.Windows.Forms.Button btnskChooseExec;
        private System.Windows.Forms.BindingSource sidekickBindingSource;
        private System.Windows.Forms.BindingSource sidekickBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn restartDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn notificationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hiddenDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn programNameDataGridViewTextBoxColumn;

    }
}