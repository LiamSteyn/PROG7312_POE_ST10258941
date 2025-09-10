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

        public MainMenu()
        {
            InitializeComponent();

            // Makes the form resizable
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(420, 580);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportIssue reportForm = new ReportIssue();
            this.Hide(); // hide MainMenu
            reportForm.ShowDialog(); // open ReportIssue as a modal dialog
            this.Show(); // when ReportIssue closes, show MainMenu again
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Show a simple message indicating that this feature is not yet available
            MessageBox.Show("This feature is coming soon!", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show a simple message indicating that this feature is not yet available
            MessageBox.Show("This feature is coming soon!", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewReportsForm viewReportsForm = new ViewReportsForm();
            this.Hide(); // hide MainMenu
            viewReportsForm.ShowDialog(); // open ViewReportsForm as a modal dialog
            this.Show(); // when ViewReportsForm closes, show MainMenu again
        }
    }
}
