using System;
using System.IO;
using System.Windows.Forms;
using AgLibrary.Logging;

namespace AgOpenGPS
{
    public partial class FormEventViewer : Form
    {
        //class variables
        string filename;

        public FormEventViewer(string _filename)
        {
            //get copy of the calling main form
            InitializeComponent();
            filename = _filename;
        }

        private void FormEventViewer_Load(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void LoadLog()
        {
            string fileContent = "";
            try
            {
                fileContent = File.ReadAllText(filename);
            }
            catch (Exception ex)
            {
                fileContent = "Catch -> error loading logfile" + ex.ToString();
            }

            rtbLogViewer.SuspendLayout();
            rtbLogViewer.Text = fileContent
                + "\r\n **** Current Session Below *****\r\n\r\n"
                + Log.sbEvents.ToString();
            rtbLogViewer.ResumeLayout();
        }
    }
}