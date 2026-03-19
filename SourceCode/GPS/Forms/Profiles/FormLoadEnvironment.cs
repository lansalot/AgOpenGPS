using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AgLibrary.Logging;
using AgLibrary.Settings;
using AgOpenGPS.Controls;
using AgOpenGPS.Core.Translations;
using AgOpenGPS.Properties;

namespace AgOpenGPS.Forms.Profiles
{
    public partial class FormLoadEnvironment : Form
    {
        private static readonly Regex InvalidFileRegex = new Regex(string.Format("[{0}]", Regex.Escape(@"<>:""/\|?*")));
        private readonly FormGPS _formGPS;
        private string _selectedName = null;

        public FormLoadEnvironment(FormGPS formGPS)
        {
            _formGPS = formGPS;
            InitializeComponent();
        }

        private void FormLoadEnvironment_Load(object sender, EventArgs e)
        {
            Text = "Environment Profiles";
            RefreshProfileList();
            ClearSelection();
        }

        private void RefreshProfileList()
        {
            listViewProfiles.Items.Clear();

            foreach (string name in GetProfiles())
            {
                var item = new ListViewItem(name);
                item.Name = name;

                // Highlight current profile
                if (name == RegistrySettings.environmentFileName)
                {
                    item.BackColor = Color.Orange;
                    item.Font = new Font(listViewProfiles.Font, FontStyle.Bold);
                }

                listViewProfiles.Items.Add(item);
            }

            UpdateCurrentLabel();
        }

        private void ClearSelection()
        {
            _selectedName = null;
            ClearPreview();
            UpdateSelectedLabel();
            UpdateButtonStates();
        }

        private void ClearPreview()
        {
            lblPreviewHeader.Text = "Select a profile";
            lblPreview1.Text = "";
            lblPreview2.Text = "";
            lblPreview3.Text = "";
            lblPreview4.Text = "";
            lblPreview5.Text = "";
        }

        private IEnumerable<string> GetProfiles()
        {
            if (!Directory.Exists(RegistrySettings.environmentDirectory))
                return Enumerable.Empty<string>();

            return new DirectoryInfo(RegistrySettings.environmentDirectory)
                .GetFiles("*.xml")
                .Select(f => Path.GetFileNameWithoutExtension(f.Name))
                .OrderBy(n => n);
        }

        private void listViewProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset all non-current items back to default
            foreach (ListViewItem li in listViewProfiles.Items)
            {
                if (li.BackColor != Color.Orange)
                    li.BackColor = listViewProfiles.BackColor;
            }

            if (listViewProfiles.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewProfiles.SelectedItems[0];
                _selectedName = item.Text;

                // Color selected item green (unless it's current, keep orange)
                if (item.BackColor != Color.Orange)
                {
                    item.BackColor = Color.LightGreen;
                }

                LoadPreview(_selectedName);
            }
            else
            {
                ClearSelection();
            }

            UpdateSelectedLabel();
            UpdateButtonStates();
        }

        private void LoadPreview(string name)
        {
            var preview = new Settings();
            string path = Path.Combine(RegistrySettings.environmentDirectory, name + ".xml");
            if (File.Exists(path))
                XmlSettingsHandler.LoadXMLFile(path, preview);

            lblPreviewHeader.Text = $"Environment: {name}";
            lblPreview1.Text = $"Units: {(preview.setMenu_isMetric ? "Metric" : "Imperial")}";
            lblPreview2.Text = $"Day Mode: {preview.setDisplay_isDayMode}";
            lblPreview3.Text = $"Full Screen: {preview.setDisplay_isStartFullScreen}";
            lblPreview4.Text = $"Grid On: {preview.setMenu_isGridOn}";
            lblPreview5.Text = $"Camera Zoom: {preview.setDisplay_camZoom:F1}";
        }

        private void UpdateCurrentLabel()
        {
            lblCurrent.Text = !string.IsNullOrEmpty(RegistrySettings.environmentFileName)
                ? $"Current Environment: {RegistrySettings.environmentFileName}"
                : "Current Environment: (none)";
        }

        private void UpdateSelectedLabel()
        {
            if (!string.IsNullOrEmpty(_selectedName))
                lblSelected.Text = $"Selected: {_selectedName}";
            else
                lblSelected.Text = "Selected: -";
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = !string.IsNullOrEmpty(_selectedName);
            buttonDelete.Enabled = hasSelection;
            buttonRename.Enabled = hasSelection;
            buttonLoad.Enabled = hasSelection && _selectedName != RegistrySettings.environmentFileName;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            string name = PromptForName("New Environment", "Enter environment profile name:", "NewEnvironment");
            if (string.IsNullOrEmpty(name)) return;

            string path = Path.Combine(RegistrySettings.environmentDirectory, name + ".xml");

            if (File.Exists(path))
            {
                FormDialog.Show("Exists", $"Environment '{name}' already exists", DialogSeverity.Error);
                return;
            }

            // Ask what to copy from
            var result = FormDialog.ShowQuestion("Copy from current?",
                "Create from current settings?\n\nNo = Create empty profile (factory settings)",
                DialogSeverity.Info);

            if (result == DialogResult.OK)
            {
                // Copy from current
                XmlSettingsHandler.SaveXMLFile(path, Settings.Default);
                Log.EventWriter($"New environment created (from current): {name}");
            }
            else
            {
                // Create empty/factory settings
                var fresh = new Settings();
                XmlSettingsHandler.SaveXMLFile(path, fresh);
                Log.EventWriter($"New environment created (factory settings): {name}");
            }

            RefreshProfileList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_formGPS.isJobStarted || string.IsNullOrEmpty(_selectedName)) return;

            if (_selectedName == RegistrySettings.environmentFileName)
            {
                FormDialog.Show("Profile in use", "Cannot delete the active environment", DialogSeverity.Error);
                return;
            }

            var result = FormDialog.ShowQuestion("Delete environment",
                $"Delete environment '{_selectedName}'?");

            if (result == DialogResult.OK)
            {
                string path = Path.Combine(RegistrySettings.environmentDirectory, _selectedName + ".xml");
                if (File.Exists(path)) File.Delete(path);
                Log.EventWriter($"Environment deleted: {_selectedName}");
                RefreshProfileList();
                ClearSelection();
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedName)) return;

            string oldName = _selectedName;
            string newName = PromptForName("Rename Environment", "Enter new environment name:", oldName);
            if (string.IsNullOrEmpty(newName) || newName == oldName) return;

            string oldPath = Path.Combine(RegistrySettings.environmentDirectory, oldName + ".xml");
            string newPath = Path.Combine(RegistrySettings.environmentDirectory, newName + ".xml");

            if (File.Exists(newPath))
            {
                FormDialog.Show("Exists", $"Environment '{newName}' already exists", DialogSeverity.Error);
                return;
            }

            File.Move(oldPath, newPath);
            Log.EventWriter($"Environment renamed: {oldName} -> {newName}");

            // If we renamed the active profile, update registry
            if (oldName == RegistrySettings.environmentFileName)
            {
                RegistrySettings.Save(RegKeys.environmentFileName, newName);
            }

            RefreshProfileList();
            ClearSelection();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            var result = FormDialog.ShowQuestion("Create Default Profile",
                "Create a 'Default' profile with factory settings?\n\nThis will create and load the new profile.",
                DialogSeverity.Info);
            if (result != DialogResult.OK) return;

            string defaultName = "Default";
            string path = Path.Combine(RegistrySettings.environmentDirectory, defaultName + ".xml");

            if (File.Exists(path))
            {
                var overwrite = FormDialog.ShowQuestion("Overwrite?",
                    $"Profile '{defaultName}' already exists. Overwrite?", DialogSeverity.Warning);
                if (overwrite != DialogResult.OK) return;
            }

            var fresh = new Settings();
            XmlSettingsHandler.SaveXMLFile(path, fresh);
            Log.EventWriter($"Default environment profile created: {defaultName}");

            // Load the Default profile
            RegistrySettings.Save(RegKeys.environmentFileName, defaultName);
            var loadResult = Settings.Default.Load();
            if (loadResult != LoadResult.Ok)
            {
                Log.EventWriter($"Error loading environment {defaultName}.xml ({loadResult})");
                FormDialog.Show("Error",
                    $"Error loading environment {defaultName}.xml\n\nResult: {loadResult}",
                    DialogSeverity.Error);
                RefreshProfileList();
                return;
            }

            Log.EventWriter($"Environment loaded: {defaultName}");
            _formGPS.LoadSettings();

            RefreshProfileList();
            _formGPS.TimedMessageBox(2500, "Loaded", "Default environment loaded");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedName)) return;
            if (_formGPS.isJobStarted)
            {
                _formGPS.TimedMessageBox(2000, "Field is open", "Close field first");
                return;
            }

            string name = _selectedName;
            if (name == RegistrySettings.environmentFileName) return;

            // First update registry, then load (Settings.Load() reads from registry)
            RegistrySettings.Save(RegKeys.environmentFileName, name);

            var result = Settings.Default.Load();
            if (result != LoadResult.Ok)
            {
                Log.EventWriter($"Error loading environment {name}.xml ({result})");
                FormDialog.Show("Error",
                    $"Error loading environment {name}.xml\n\nResult: {result}",
                    DialogSeverity.Error);
                return;
            }

            Log.EventWriter($"Environment loaded: {name}");

            _formGPS.LoadSettings();

            _formGPS.TimedMessageBox(2500, "Loaded", $"Environment: {name}");
            Close();
        }

        private string PromptForName(string title, string prompt)
        {
            return AgOpenGPS.Forms.FormInputDialog.ShowInput(title, prompt, _formGPS);
        }

        private string PromptForName(string title, string prompt, string defaultValue)
        {
            return AgOpenGPS.Forms.FormInputDialog.ShowInput(title, prompt, _formGPS, defaultValue);
        }

        private static string SanitizeFileName(string fileName)
        {
            return InvalidFileRegex.Replace(fileName, string.Empty);
        }
    }
}
