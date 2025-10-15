using IssueReportSystem.Models;
using IssueReportSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueReportSystem
{
    public partial class MainMenu : Form
    {
        /// <summary>
        /// Constructor initializes the MainMenu form and sets its properties.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();

            // Makes the form resizable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            // Start the form centered on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set minimum size to prevent layout issues
            this.MinimumSize = new Size(420, 580);
        }

        /// <summary>
        /// Opens the ReportIssue form as a modal dialog.
        /// Hides MainMenu while the ReportIssue form is open.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            ReportIssue reportForm = new ReportIssue();
            this.Hide();                  // Hide MainMenu
            reportForm.ShowDialog();      // Open ReportIssue as modal
            this.Show();                  // Show MainMenu after ReportIssue closes
        }

        /// <summary>
        /// Placeholder button click indicating feature not yet available.
        /// Shows a message box to the user.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is coming soon!", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e){}

        private void MainMenu_Load(object sender, EventArgs e){}

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e){}

        /// <summary>
        /// Opens the LocalEventsForm as a modal dialog.
        /// Hides MainMenu while LocalEventsForm is open.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            LocalEventsForm localEventsForm = new LocalEventsForm();
            this.Hide();                     // Hide MainMenu
            localEventsForm.ShowDialog();    // Open LocalEventsForm as modal
            this.Show();                     // Show MainMenu after LocalEventsForm closes
        }


        private void pictureBox1_Click(object sender, EventArgs e){}

        /// <summary>
        /// Opens the ViewReportsForm as a modal dialog.
        /// Hides MainMenu while ViewReportsForm is open.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            ViewReportsForm viewReportsForm = new ViewReportsForm();
            this.Hide();                     // Hide MainMenu
            viewReportsForm.ShowDialog();    // Open ViewReportsForm as modal
            this.Show();                     // Show MainMenu after ViewReportsForm closes
        }
    }
}
