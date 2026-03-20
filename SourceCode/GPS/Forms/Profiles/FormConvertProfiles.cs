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

            // Tool is always enabled
            textBoxToolName.Enabled = true;
        }

        private void UpdateConvertButton()
        {
            buttonConvert.Enabled = listViewFiles.SelectedItems.Count > 0
                && (!vehicleEnabled || !string.IsNullOrWhiteSpace(textBoxVehicleName.Text))
                && !string.IsNullOrWhiteSpace(textBoxToolName.Text); // Tool is always required
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
            string toolName = textBoxToolName.Text.Trim(); // Tool is always exported

            // Validate
            if (string.IsNullOrEmpty(toolName)) return;
            if (exportVehicle && string.IsNullOrEmpty(vehicleName)) return;

            // Check for existing files
            var overwrites = new List<string>();

            if (exportVehicle)
            {
                string vehiclePath = Path.Combine(RegistrySettings.vehiclesDirectory, vehicleName + ".xml");
                if (File.Exists(vehiclePath) && CSettingsMigration.IsSettingsType(vehiclePath, "VehicleSettings"))
                    overwrites.Add($"Vehicle: {vehicleName}");
            }

            string toolPath = Path.Combine(RegistrySettings.toolsDirectory, toolName + ".xml");
            if (File.Exists(toolPath) && CSettingsMigration.IsSettingsType(toolPath, "ToolSettings"))
                overwrites.Add($"Tool: {toolName}");

            string confirmMsg = $"Convert '{sourceFile}':\n\n";
            if (exportVehicle)
                confirmMsg += $"  Vehicle: {vehicleName}\n";
            confirmMsg += $"  Tool: {toolName}\n"; // Tool is always shown

            confirmMsg += "\nThe original file will be marked as converted.";

            if (overwrites.Count > 0)
                confirmMsg += $"\n\nWARNING: This will overwrite:\n{string.Join("\n", overwrites)}";

            var confirm = FormDialog.ShowQuestion("Confirm Conversion", confirmMsg);
            if (confirm != DialogResult.OK) return;

            var errors = new List<string>();

            // Convert Tool FIRST
            var tSettings = new ToolSettings();
            var tResult = CSettingsMigration.MigrateTool(sourceFile, toolName, tSettings);
            if (tResult != LoadResult.Ok)
                errors.Add($"Tool: {tResult}");

            // Convert Vehicle (optional)
            if (exportVehicle)
            {
                var vSettings = new VehicleSettings();
                var vResult = CSettingsMigration.MigrateVehicle(sourceFile, vehicleName, vSettings);
                if (vResult != LoadResult.Ok)
                    errors.Add($"Vehicle: {vResult}");
            }

            if (errors.Count == 0)
            {
                // Mark old file as converted
                CSettingsMigration.MarkAsConverted(sourceFile);

                Log.EventWriter($"Converted '{sourceFile}' -> " +
                    (exportVehicle ? $"Vehicle:'{vehicleName}', " : "") +
                    $"Tool:'{toolName}'");

                FormDialog.Show("Conversion Complete",
                    $"'{sourceFile}' converted successfully!", DialogSeverity.Info);

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
