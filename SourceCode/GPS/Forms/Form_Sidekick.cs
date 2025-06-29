using OpenTK.Platform.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS.Forms
{

    public partial class Form_Sidekick : Form
    {
        private readonly FormGPS mf = null;

        public Form_Sidekick(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void GenerateDataGridView() => dataGridView1.DataSource = mf.Sidekicks;
        private void frmLoad(object sender, EventArgs e)
        {
            // Attempt to load Sidekicks.xml and bind to DataGridView
            string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sidekicks.xml");
            if (System.IO.File.Exists(xmlPath))
            {
                var dt = new DataTable();
                try
                {
                    dt.ReadXml(xmlPath);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load Sidekicks.xml: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GenerateDataGridView();
                }
            }
            else
            {
                GenerateDataGridView();
            }
        }

        private void labelDisagree_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            var dt = new DataTable("Sidekicks");
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dt.Columns.Add(col.HeaderText, typeof(string));
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var values = new object[dataGridView1.Columns.Count];
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        values[i] = row.Cells[i].Value?.ToString() ?? string.Empty;
                    }
                    dt.Rows.Add(values);
                }
            }

            string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sidekicks.xml");
            dt.WriteXml(xmlPath, XmlWriteMode.WriteSchema);
            this.Close();
        }


        private void btnAddSidekick_Click(object sender, EventArgs e)
        {
            string displayName = txtskDisplayName.Text.Trim();
            string programName = txtskExecutable.Text.Trim();
            bool restart = ckskAutoRestart.Checked;
            bool hidden = ckskStartHidden.Checked;
            bool notification = ckskNotification.Checked;
            int interval = 0;
            int.TryParse(txtskInterval.Text.Trim(), out interval);

            var dgv = dataGridView1;
            if (dgv.DataSource is DataTable dt)
            {
                DataRow newRow = dt.NewRow();
                newRow["DisplayName"] = displayName;
                newRow["ProgramName"] = programName;
                newRow["Restart"] = restart.ToString();
                newRow["Hidden"] = hidden.ToString();
                newRow["Notification"] = notification.ToString();
                newRow["Interval"] = interval.ToString();
                dt.Rows.Add(newRow);
            }
            txtskDisplayName.Clear();
            txtskExecutable.Clear();
            ckskAutoRestart.Checked = false;
            ckskNotification.Checked = false;
            txtskInterval.Clear();
        }

        private void btnskChooseExec_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*",
                Title = "Select Sidekick Executable"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtskExecutable.Text = openFileDialog.FileName;
            }
        }

        private void btnRemoveSidekick_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }
    }
    // Represents a single Sidekick entry matching the Sidekicks.xml schema
    public class Sidekick
    {
        public string DisplayName { get; set; }
        public string ProgramName { get; set; }
        public bool Restart { get; set; }
        public bool Notification { get; set; }
        public bool Hidden { get; set; }
        public int Interval { get; set; }
    }
}
