using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AgLibrary.Logging;
using AgLibrary.Settings;
using AgOpenGPS;
using AgOpenGPS.Controls;
using AgOpenGPS.Properties;

namespace AgOpenGPS.Forms.Profiles
{
    public partial class FormConvertProfiles : Form
    {
        private readonly FormGPS _formGPS;

        // Toggle states
        private bool vehicleEnabled = true;
        private bool toolEnabled = true;

        public FormConvertProfiles(FormGPS formGPS)
        {
            _formGPS = formGPS;
            InitializeComponent();
        }

        private void FormConvertProfiles_Load(object sender, EventArgs e)
        {
            RefreshFileList();
            ClearDetails();
            UpdateToggleButtons();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (_formGPS?.isKeyboardOn == true)
            {
                ((TextBox)sender).ShowKeyboard(this);
                buttonConvert.Focus();
            }
        }

        private void RefreshFileList()
        {
            RefreshFileList(clearDetails: true);
        }

        private void RefreshFileList(bool clearDetails)
        {
            // Remember current selection
            string selectedName = null;
            if (listViewFiles.SelectedItems.Count > 0)
            {
                selectedName = listViewFiles.SelectedItems[0].Text;
            }

            listViewFiles.Items.Clear();

            string[] files = CSettingsMigration.GetConvertibleFiles();
            int convertedCount = 0;

            foreach (string name in files.OrderBy(n => n))
            {
                var item = new ListViewItem(name) { Name = name };
                // Color converted files green
                if (CSettingsMigration.IsConverted(name))
                {
                    item.BackColor = Color.LightGreen;
                    convertedCount++;
                }
                listViewFiles.Items.Add(item);
            }

            if (listViewFiles.Items.Count == 0)
            {
                labelStatus.Text = "No old format files found.";
            }
            else
            {
                int unconverted = listViewFiles.Items.Count - convertedCount;
                labelStatus.Text = $"{listViewFiles.Items.Count} old file(s): {convertedCount} converted, {unconverted} to convert.";
            }

            if (clearDetails)
            {
                ClearDetails();
            }
            else if (selectedName != null)
            {
                // Restore selection if item still exists
                foreach (ListViewItem item in listViewFiles.Items)
                {
                    if (item.Name == selectedName)
                    {
                        item.Selected = true;
                        item.Focused = true;
                        break;
                    }
                }
            }
        }

        private void ClearDetails()
        {
            textBoxVehicleName.Text = "";
            textBoxToolName.Text = "";
            vehicleEnabled = true;
            toolEnabled = true;
            panelDetails.Enabled = false;
            buttonConvert.Enabled = false;
            UpdateToggleButtons();
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                string selected = listViewFiles.SelectedItems[0].Text;
                textBoxVehicleName.Text = selected;
                textBoxToolName.Text = selected;
                vehicleEnabled = true;
                toolEnabled = true;
                panelDetails.Enabled = true;
                UpdateToggleButtons();
            }
            else
            {
                ClearDetails();
            }
        }

        private void btnToggleVehicle_Click(object sender, EventArgs e)
        {
            vehicleEnabled = !vehicleEnabled;
            UpdateToggleButtons();
            UpdateConvertButton();
        }

        private void btnToggleTool_Click(object sender, EventArgs e)
        {
            toolEnabled = !toolEnabled;
            UpdateToggleButtons();
            UpdateConvertButton();
        }

        private void UpdateToggleButtons()
        {
            // Vehicle button
            if (vehicleEnabled)
            {
                btnToggleVehicle.Text = "Import Vehicle";
                btnToggleVehicle.BackColor = Color.LightGreen;
                textBoxVehicleName.Enabled = true;
            }
            else
            {
                btnToggleVehicle.Text = "No Import";
                btnToggleVehicle.BackColor = Color.LightGray;
                textBoxVehicleName.Enabled = false;
            }

            // Tool button
            if (toolEnabled)
            {
                btnToggleTool.Text = "Import Tool";
                btnToggleTool.BackColor = Color.LightGreen;
                textBoxToolName.Enabled = true;
            }
            else
            {
                btnToggleTool.Text = "No Import";
                btnToggleTool.BackColor = Color.LightGray;
                textBoxToolName.Enabled = false;
            }
        }

        private void UpdateConvertButton()
        {
            // At least one of Vehicle or Tool must be selected
            bool hasSelection = listViewFiles.SelectedItems.Count > 0;
            bool vehicleValid = !vehicleEnabled || !string.IsNullOrWhiteSpace(textBoxVehicleName.Text);
            bool toolValid = !toolEnabled || !string.IsNullOrWhiteSpace(textBoxToolName.Text);
            bool atLeastOne = vehicleEnabled || toolEnabled;

            buttonConvert.Enabled = hasSelection && vehicleValid && toolValid && atLeastOne;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var pos = tb.SelectionStart;
            tb.Text = Regex.Replace(tb.Text, glm.fileRegex, "");
            tb.SelectionStart = pos;

            UpdateConvertButton();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;

            string sourceFile = listViewFiles.SelectedItems[0].Text;
            bool exportVehicle = vehicleEnabled;
            string vehicleName = exportVehicle ? textBoxVehicleName.Text.Trim() : null;
            bool exportTool = toolEnabled;
            string toolName = exportTool ? textBoxToolName.Text.Trim() : null;

            // Validate
            if (exportVehicle && string.IsNullOrEmpty(vehicleName)) return;
            if (exportTool && string.IsNullOrEmpty(toolName)) return;

            // Check for existing files - block duplicate names
            if (exportVehicle)
            {
                string vehiclePath = Path.Combine(RegistrySettings.vehiclesDirectory, vehicleName + ".xml");
                if (File.Exists(vehiclePath))
                {
                    FormDialog.Show("Exists", $"Vehicle '{vehicleName}' already exists", DialogSeverity.Error);
                    return;
                }
            }

            if (exportTool)
            {
                string toolPath = Path.Combine(RegistrySettings.toolsDirectory, toolName + ".xml");
                if (File.Exists(toolPath))
                {
                    FormDialog.Show("Exists", $"Tool '{toolName}' already exists", DialogSeverity.Error);
                    return;
                }
            }

            string confirmMsg = $"Convert '{sourceFile}':\n\n";
            if (exportVehicle)
                confirmMsg += $"  Vehicle: {vehicleName}\n";
            if (exportTool)
                confirmMsg += $"  Tool: {toolName}\n";

            var confirm = FormDialog.ShowQuestion("Confirm Conversion", confirmMsg);
            if (confirm != DialogResult.OK) return;

            var errors = new List<string>();

            // Convert Vehicle (optional)
            if (exportVehicle)
            {
                var vSettings = new VehicleSettings();
                var vResult = CSettingsMigration.MigrateVehicle(sourceFile, vehicleName, vSettings);
                if (vResult != LoadResult.Ok)
                    errors.Add($"Vehicle: {vResult}");
            }

            // Convert Tool (optional)
            if (exportTool)
            {
                var tSettings = new ToolSettings();
                var tResult = CSettingsMigration.MigrateTool(sourceFile, toolName, tSettings);
                if (tResult != LoadResult.Ok)
                    errors.Add($"Tool: {tResult}");
            }

            // One-time environment migration (if environment.xml doesn't exist yet)
            bool migratedEnvironment = false;
            string envPath = Path.Combine(RegistrySettings.environmentDirectory, "environment.xml");
            if (!File.Exists(envPath))
            {
                var eResult = CSettingsMigration.MigrateEnvironment(sourceFile, "environment");
                if (eResult == LoadResult.Ok)
                {
                    migratedEnvironment = true;
                    Log.EventWriter($"Environment migrated from '{sourceFile}'");
                }
                else
                {
                    errors.Add($"Environment: {eResult}");
                }
            }

            if (errors.Count == 0)
            {
                // Mark old file as converted
                CSettingsMigration.MarkAsConverted(sourceFile);

                string logMsg = $"Converted '{sourceFile}' -> " +
                    (exportVehicle ? $"Vehicle:'{vehicleName}', " : "") +
                    (exportTool ? $"Tool:'{toolName}'" : "");
                if (migratedEnvironment)
                    logMsg += ", Environment: 'environment.xml' (one-time)";
                Log.EventWriter(logMsg);

                // If Environment was migrated, load it immediately
                if (migratedEnvironment)
                {
                    var loadResult = Properties.Settings.Default.Load();
                    if (loadResult == LoadResult.Ok)
                    {
                        _formGPS.LoadSettings();
                        Log.EventWriter("Environment settings loaded after migration");
                    }
                }

                string successMsg = $"'{sourceFile}' converted successfully!";
                if (migratedEnvironment)
                    successMsg += "\n\nEnvironment settings have been imported and loaded.";

                FormDialog.Show("Conversion Complete", successMsg, DialogSeverity.Info);

                // Refresh list to show converted file in green, keep form open for next conversion
                RefreshFileList(clearDetails: false);
            }
            else
            {
                Log.EventWriter($"Errors converting '{sourceFile}': {string.Join(", ", errors)}");
                FormDialog.Show("Conversion Errors",
                    $"Errors occurred:\n\n" + string.Join("\n", errors), DialogSeverity.Warning);
            }
        }
    }
}
