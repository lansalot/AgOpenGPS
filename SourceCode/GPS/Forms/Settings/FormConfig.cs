//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Forms;


namespace AgOpenGPS
{
    public partial class FormConfig : Form
    {
        //class variables
        CANBUSIDs _CANBUSIDs = new CANBUSIDs(Application.StartupPath + "\\CANBUSIDS.csv");
        private readonly FormGPS mf = null;

        bool isClosing = false;

        //constructor
        public FormConfig(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            tab1.Appearance = TabAppearance.FlatButtons;
            tab1.ItemSize = new Size(0, 1);
            tab1.SizeMode = TabSizeMode.Fixed;

            HideSubMenu();

            cbCANManufacturer.Items.Clear();
            // This list should match exactly with the one in the INO. Watch the code if it goes into double-digits
            cbCANManufacturer.DataSource = new[] {
                new {Value = "X", Name = "No CANBUS!"},
                new {Value = "0", Name = "Claas" },
                new {Value = "1", Name = "Valtra / Massey" },
                new {Value = "2", Name = "CaseIH / New Holland" },
                new {Value = "3", Name = "Fendt SCR, S4, Gen6" },
                new {Value = "4", Name = "JCB" },
                new {Value = "5", Name = "FendtOne" },
                new {Value = "6", Name = "Lindner" },
                new {Value = "7", Name = "AgOpenGPS" },
                new {Value = "8", Name = "Challenger MT" }

            };

            cbCANManufacturer.DisplayMember = "Name";
            cbCANManufacturer.ValueMember = "Value";

            nudTrailingHitchLength.Controls[0].Enabled = false;
            nudDrawbarLength.Controls[0].Enabled = false;
            nudTankHitch.Controls[0].Enabled = false;

            nudLookAhead.Controls[0].Enabled = false;
            nudLookAheadOff.Controls[0].Enabled = false;
            nudTurnOffDelay.Controls[0].Enabled = false;
            nudOffset.Controls[0].Enabled = false;
            nudOverlap.Controls[0].Enabled = false;
            nudCutoffSpeed.Controls[0].Enabled = false;

            nudMinTurnRadius.Controls[0].Enabled = false;
            nudAntennaHeight.Controls[0].Enabled = false;
            nudAntennaOffset.Controls[0].Enabled = false;
            nudAntennaPivot.Controls[0].Enabled = false;
            nudLightbarCmPerPixel.Controls[0].Enabled = false;
            nudVehicleTrack.Controls[0].Enabled = false;
            nudSnapDistance.Controls[0].Enabled = false;
            nudABLength.Controls[0].Enabled = false;
            nudWheelbase.Controls[0].Enabled = false;
            nudLineWidth.Controls[0].Enabled = false;

            nudMinCoverage.Controls[0].Enabled = false;
            nudDefaultSectionWidth.Controls[0].Enabled = false;

            nudSection1.Controls[0].Enabled = false;
            nudSection2.Controls[0].Enabled = false;
            nudSection3.Controls[0].Enabled = false;
            nudSection4.Controls[0].Enabled = false;
            nudSection5.Controls[0].Enabled = false;
            nudSection6.Controls[0].Enabled = false;
            nudSection7.Controls[0].Enabled = false;
            nudSection8.Controls[0].Enabled = false;
            nudSection9.Controls[0].Enabled = false;
            nudSection10.Controls[0].Enabled = false;
            nudSection11.Controls[0].Enabled = false;
            nudSection12.Controls[0].Enabled = false;
            nudSection13.Controls[0].Enabled = false;
            nudSection14.Controls[0].Enabled = false;
            nudSection15.Controls[0].Enabled = false;
            nudSection16.Controls[0].Enabled = false;
            nudNumberOfSections.Controls[0].Enabled = false;

            nudMinFixStepDistance.Controls[0].Enabled = false;
            nudStartSpeed.Controls[0].Enabled = false;

            nudZone1To.Controls[0].Enabled = false;
            nudZone2To.Controls[0].Enabled = false;
            nudZone3To.Controls[0].Enabled = false;
            nudZone4To.Controls[0].Enabled = false;
            nudZone5To.Controls[0].Enabled = false;
            nudZone6To.Controls[0].Enabled = false;

            nudRaiseTime.Controls[0].Enabled = false;
            nudLowerTime.Controls[0].Enabled = false;

            nudUser1.Controls[0].Enabled = false;
            nudUser2.Controls[0].Enabled = false;
            nudUser3.Controls[0].Enabled = false;
            nudUser4.Controls[0].Enabled = false;

            nudTramWidth.Controls[0].Enabled = false;

            nudGuidanceLookAhead.Controls[0].Enabled = false;

            nudDualHeadingOffset.Controls[0].Enabled = false;
            dgCANBUSIDs.MouseDown += dgCANBUSIDs_MouseDown;
            lblCANBUSSteerCode.DragEnter += lblCANBUSSteerCode_DragEnter;
            lblCANBUSSteerCode.DragDrop += lblCANBUSSteerCode_DragDrop;
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            //seince we rest, save current state
            mf.SaveFormGPSWindowSettings();

            if (mf.isMetric)
            {
                lblInchesCm.Text = gStr.gsCentimeters;
                lblInchCm2.Text = gStr.gsCentimeters;
                lblFeetMeters.Text = gStr.gsMeters;
                lblSecTotalWidthFeet.Visible = false;
                lblSecTotalWidthInches.Visible = false;
                lblSecTotalWidthMeters.Visible = true;
            }
            else
            {
                lblInchesCm.Text = gStr.gsInches;
                lblInchCm2.Text = gStr.gsInches;
                lblFeetMeters.Text = "Feet";
                lblSecTotalWidthFeet.Visible = true;
                lblSecTotalWidthInches.Visible = true;
                lblSecTotalWidthMeters.Visible = false;

                //metric or imp on spinners min/maxes
                FixMinMaxSpinners();
            }

            //update the first child form summary data items
            UpdateSummary();

            //the pick a saved vehicle box
            UpdateVehicleListView();

            //the tool size in bottom panel
            if (mf.isMetric)
            {
                lblSecTotalWidthMeters.Text = (mf.tool.width * 100) + " cm";
            }
            else
            {
                double toFeet = mf.tool.width * 100 * 0.0328084;
                lblSecTotalWidthFeet.Text = Convert.ToString((int)toFeet) + "'";
                double temp = Math.Round((toFeet - Math.Truncate(toFeet)) * 12, 0);
                lblSecTotalWidthInches.Text = Convert.ToString(temp) + '"';
            }

            chkDisplaySky.Checked = mf.isSkyOn;
            chkDisplayBrightness.Checked = mf.isBrightnessOn;
            chkDisplayFloor.Checked = mf.isTextureOn;
            chkDisplayGrid.Checked = mf.isGridOn;
            chkDisplaySpeedo.Checked = mf.isSpeedoOn;
            chkDisplayDayNight.Checked = mf.isAutoDayNight;
            chkDisplayStartFullScreen.Checked = Properties.Settings.Default.setDisplay_isStartFullScreen;
            chkDisplayExtraGuides.Checked = mf.isSideGuideLines;
            chkDisplayLogNMEA.Checked = mf.isLogNMEA;
            chkDisplayPolygons.Checked = mf.isDrawPolygons;
            chkDisplayLightbar.Checked = mf.isLightbarOn;
            chkDisplayKeyboard.Checked = mf.isKeyboardOn;

            if (mf.isMetric) rbtnDisplayMetric.Checked = true;
            else rbtnDisplayImperial.Checked = true;

            tab1.SelectedTab = tabSummary;
            tboxVehicleNameSave.Focus();
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                e.Cancel = true;
                return;
            }
            SaveDisplaySettings();

            //reload all the settings from default and user.config
            mf.LoadSettings();

            //save current vehicle
            SettingsIO.ExportAll(mf.vehiclesDirectory + mf.vehicleFileName + ".XML");
        }

        private void FixMinMaxSpinners()
        {
            nudTankHitch.Maximum = (Math.Round(nudTankHitch.Maximum / 2.54M));
            nudTankHitch.Minimum = Math.Round(nudTankHitch.Minimum / 2.54M);

            nudDrawbarLength.Maximum = Math.Round(nudDrawbarLength.Maximum / 2.54M);
            nudDrawbarLength.Minimum = Math.Round(nudDrawbarLength.Minimum / 2.54M);

            nudTrailingHitchLength.Maximum = Math.Round(nudTrailingHitchLength.Maximum / 2.54M);
            nudTrailingHitchLength.Minimum = Math.Round(nudTrailingHitchLength.Minimum / 2.54M);

            nudSnapDistance.Maximum = Math.Round(nudSnapDistance.Maximum / 2.54M);
            nudSnapDistance.Minimum = Math.Round(nudSnapDistance.Minimum / 2.54M);

            nudLightbarCmPerPixel.Maximum = Math.Round(nudLightbarCmPerPixel.Maximum / 2.54M);
            nudLightbarCmPerPixel.Minimum = Math.Round(nudLightbarCmPerPixel.Minimum / 2.54M);

            nudVehicleTrack.Maximum = Math.Round(nudVehicleTrack.Maximum / 2.54M);
            nudVehicleTrack.Minimum = Math.Round(nudVehicleTrack.Minimum / 2.54M);

            nudWheelbase.Maximum = Math.Round(nudWheelbase.Maximum / 2.54M);
            nudWheelbase.Minimum = Math.Round(nudWheelbase.Minimum / 2.54M);

            nudMinTurnRadius.Maximum = Math.Round(nudMinTurnRadius.Maximum / 2.54M);
            nudMinTurnRadius.Minimum = Math.Round(nudMinTurnRadius.Minimum / 2.54M);

            nudOverlap.Maximum = Math.Round(nudOverlap.Maximum / 2.54M);
            nudOverlap.Minimum = Math.Round(nudOverlap.Minimum / 2.54M);

            nudOffset.Maximum = Math.Round(nudOffset.Maximum / 2.54M);
            nudOffset.Minimum = Math.Round(nudOffset.Minimum / 2.54M);

            nudDefaultSectionWidth.Maximum = Math.Round(nudDefaultSectionWidth.Maximum / 2.54M);
            nudDefaultSectionWidth.Minimum = Math.Round(nudDefaultSectionWidth.Minimum / 3.0M);

            nudSection1.Maximum = Math.Round(nudSection1.Maximum / 2.54M);
            nudSection1.Minimum = Math.Round(nudSection1.Minimum / 2.54M);
            nudSection2.Maximum = Math.Round(nudSection2.Maximum / 2.54M);
            nudSection2.Minimum = Math.Round(nudSection2.Minimum / 2.54M);
            nudSection3.Maximum = Math.Round(nudSection3.Maximum / 2.54M);
            nudSection3.Minimum = Math.Round(nudSection3.Minimum / 2.54M);
            nudSection4.Maximum = Math.Round(nudSection4.Maximum / 2.54M);
            nudSection4.Minimum = Math.Round(nudSection4.Minimum / 2.54M);
            nudSection5.Maximum = Math.Round(nudSection5.Maximum / 2.54M);
            nudSection5.Minimum = Math.Round(nudSection5.Minimum / 2.54M);
            nudSection6.Maximum = Math.Round(nudSection6.Maximum / 2.54M);
            nudSection6.Minimum = Math.Round(nudSection6.Minimum / 2.54M);
            nudSection7.Maximum = Math.Round(nudSection7.Maximum / 2.54M);
            nudSection7.Minimum = Math.Round(nudSection7.Minimum / 2.54M);
            nudSection8.Maximum = Math.Round(nudSection8.Maximum / 2.54M);
            nudSection8.Minimum = Math.Round(nudSection8.Minimum / 2.54M);
            nudSection9.Maximum = Math.Round(nudSection9.Maximum / 2.54M);
            nudSection9.Minimum = Math.Round(nudSection9.Minimum / 2.54M);
            nudSection10.Maximum = Math.Round(nudSection10.Maximum / 2.54M);
            nudSection10.Minimum = Math.Round(nudSection10.Minimum / 2.54M);
            nudSection11.Maximum = Math.Round(nudSection11.Maximum / 2.54M);
            nudSection11.Minimum = Math.Round(nudSection11.Minimum / 2.54M);
            nudSection12.Maximum = Math.Round(nudSection12.Maximum / 2.54M);
            nudSection12.Minimum = Math.Round(nudSection12.Minimum / 2.54M);
            nudSection13.Maximum = Math.Round(nudSection13.Maximum / 2.54M);
            nudSection13.Minimum = Math.Round(nudSection13.Minimum / 2.54M);
            nudSection14.Maximum = Math.Round(nudSection14.Maximum / 2.54M);
            nudSection14.Minimum = Math.Round(nudSection14.Minimum / 2.54M);
            nudSection15.Maximum = Math.Round(nudSection15.Maximum / 2.54M);
            nudSection15.Minimum = Math.Round(nudSection15.Minimum / 2.54M);
            nudSection16.Maximum = Math.Round(nudSection16.Maximum / 2.54M);
            nudSection16.Minimum = Math.Round(nudSection16.Minimum / 2.54M);

            nudTramWidth.Minimum = Math.Round(nudTramWidth.Minimum / 2.54M);
            nudTramWidth.Maximum = Math.Round(nudTramWidth.Maximum / 2.54M);

            nudSnapDistance.Minimum = Math.Round(nudSnapDistance.Minimum / 2.54M);
            nudSnapDistance.Maximum = Math.Round(nudSnapDistance.Maximum / 2.54M);

            nudLightbarCmPerPixel.Minimum = Math.Round(nudLightbarCmPerPixel.Minimum / 2.54M);
            nudLightbarCmPerPixel.Maximum = Math.Round(nudLightbarCmPerPixel.Maximum / 2.54M);

            //Meters to feet
            nudTurnDistanceFromBoundary.Minimum = Math.Round(nudTurnDistanceFromBoundary.Minimum * 3.28M);
            nudTurnDistanceFromBoundary.Maximum = Math.Round(nudTurnDistanceFromBoundary.Maximum * 3.28M);

            nudABLength.Minimum = Math.Round(nudABLength.Minimum * 3.28M);
            nudABLength.Maximum = Math.Round(nudABLength.Maximum * 3.28M);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isClosing = true;
            Close();
        }

        private void tabSummary_Enter(object sender, EventArgs e)
        {
            chkDisplaySky.Checked = mf.isSkyOn;
            chkDisplayBrightness.Checked = mf.isBrightnessOn;
            chkDisplayFloor.Checked = mf.isTextureOn;
            chkDisplayGrid.Checked = mf.isGridOn;
            chkDisplaySpeedo.Checked = mf.isSpeedoOn;
            chkDisplayDayNight.Checked = mf.isAutoDayNight;
            chkDisplayStartFullScreen.Checked = Properties.Settings.Default.setDisplay_isStartFullScreen;
            chkDisplayExtraGuides.Checked = mf.isSideGuideLines;
            chkDisplayLogNMEA.Checked = mf.isLogNMEA;
            chkDisplayPolygons.Checked = mf.isDrawPolygons;
            chkDisplayLightbar.Checked = mf.isLightbarOn;
            chkDisplayKeyboard.Checked = mf.isKeyboardOn;

            if (mf.isMetric) rbtnDisplayMetric.Checked = true;
            else rbtnDisplayImperial.Checked = true;
        }

        private void tabSummary_Leave(object sender, EventArgs e)
        {
            SaveDisplaySettings();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                btnVehicleSaveAs.Enabled = true;
                btnVehicleLoad.Enabled = true;
                btnVehicleDelete.Enabled = true;
            }
            else
            {
                btnVehicleSaveAs.Enabled = false;
                btnVehicleLoad.Enabled = false;
                btnVehicleDelete.Enabled = false;
            }

            // this isn't often enough, timer runs every second. move it to its own, and ensure timer only runs when tab is visible
            if (mf.InterFormMessage != null)
            {
                if (mf.InterFormMessage.StartsWith("BRAND: "))
                {
                    int index = -1;
                    int.TryParse(mf.InterFormMessage.Substring(7, mf.InterFormMessage.Length - 7), out index);
                    index++;
                    cbCANManufacturer.SelectedIndex = index;
                    Console.WriteLine(mf.InterFormMessage);

                }
                mf.InterFormMessage = null;
            }
        }

        private void btnCANBUSSupport_Click(object sender, EventArgs e)
        {
            byte[] MachineConfigPacket = new byte[] { 0x80, 0x81, 0x7f, 0xAA, 1, (byte)mf.vehicle.CANBUSBrand, 0, 0xCC };
            mf.SendPgnToLoop(MachineConfigPacket);
            mf.TimedMessageBox(2000, "Updating Teensy CANBUS manunfacturer", "Please wait, signal will return soon");
        }

        private void btnShowCAN_Click(object sender, EventArgs e)
        {
            tab1.SelectedTab = tabCANBUS;
        }

        private void btnQueryBrand_Click(object sender, EventArgs e)
        {
            byte[] MachineConfigPacket = new byte[] { 0x80, 0x81, 0x7f, 0xAB, 1, 1, 0xCC };
            mf.SendPgnToLoop(MachineConfigPacket);
        }

        private void btnSetBrand_Click(object sender, EventArgs e)
        {
            byte[] MachineConfigPacket = new byte[] { 0x80, 0x81, 0x7f, 0xAA, 1, 1, 0xCC };
            mf.SendPgnToLoop(MachineConfigPacket);
        }

        private void btnReadCANConfigs_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/lansalot/AgOpenGPS/CANBUS/CANBUSIDS.csv");
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();
                Console.Write(content);
                File.WriteAllText(Application.StartupPath + "\\CANBUSIDS.csv", content);
                mf.TimedMessageBox(2000, "Updated!", "Latest file downloaded, local copy refreshed");
                // refresh the form with new data

                UpdateCANBUSGrid();
            }
            catch (Exception downloadError)
            {
                mf.TimedMessageBox(2000, "Oops!!", "Sorry, failed to download latest copy\n" + downloadError.Message);
            }
        }

        private void UpdateCANBUSGrid()
        {
            dgCANBUSIDs.AutoGenerateColumns = false;
            dgCANBUSIDs.Visible = true;
            try
            {
                if (cbCANManufacturer.SelectedValue.ToString() != "X")
                {
                    //dgCANBUSIDs.Visible = true;
                    _CANBUSIDs.FilterByBrand(cbCANManufacturer.SelectedValue.ToString());
                    dgCANBUSIDs.DataSource = _CANBUSIDs.FilteredVehicleData;
                }
                else
                {
                    dgCANBUSIDs.Visible = true;
                    dgCANBUSIDs.DataSource = _CANBUSIDs.VehicleData;

                }
            }
            catch (Exception gridFail)
            {
                mf.TimedMessageBox(2000, "Oops!!", "Sorry, failed to update grid\n" + gridFail.Message);
            }

        }
        private void cbCANManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCANBUSGrid();
        }

        private void dgCANBUSIDs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hitTestInfo = dgCANBUSIDs.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.RowHeader)
                {
                    // Start the drag operation
                    dgCANBUSIDs.DoDragDrop(dgCANBUSIDs.Rows[hitTestInfo.RowIndex], DragDropEffects.Copy);
                }
            }
        }

        private void lblCANBUSSteerCode_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void lblCANBUSSteerCode_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                DataGridViewRow row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                lblCANBUSSteerCode.Text = row.Cells[2].Value.ToString();
            }
        }
        //private void btnCANRecord_Click(object sender, EventArgs e)
        //{
        //    if (btnCANRecord.Text == "Record")
        //    {
        //        btnCANRecord.Text = "Stop";
        //        byte[] MachineConfigPacket = new byte[] { 0x80, 0x81, 0x7f, 0xAC, 1, 2, 0xCC }; // 2 = enable diags and disable filters
        //        mf.SendPgnToLoop(MachineConfigPacket);
        //        mf.TimedMessageBox(2000, "Recording", "Press button of interest and Stop as soon as possible");
        //    }
        //    else
        //    {
        //        btnCANRecord.Text = "Record";
        //        byte[] MachineConfigPacket = new byte[] { 0x80, 0x81, 0x7f, 0xAC, 1, 3, 0xCC }; // 3 = disable diags and re-enable filters
        //        mf.SendPgnToLoop(MachineConfigPacket);
        //        mf.TimedMessageBox(2000, "Stopped recording", "Filters are now back in place");

        //    }

        //}
    }
}