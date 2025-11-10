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
    /// <summary>
    /// Form that allows a user to submit a municipal issue report.
    /// Implements user engagement features such as a progress bar and validation messages.
    /// </summary>
    public partial class ReportIssue : Form
    {
        // List to hold file paths for attached images or documents
        private List<string> attachedFilePaths = new List<string>();

        /// <summary>
        /// Constructor initializes the form and sets default properties.
        /// </summary>
        public ReportIssue()
        {
            InitializeComponent();

            this.Text = "Report Issue";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(500, 500);
        }

        /// <summary>
        /// Event fired when form loads. Initializes UI controls and dropdown lists.
        /// </summary>
        private void ReportIssue_Load(object sender, EventArgs e)
        {
            UpdateProgress();

            issueLocation.ForeColor = Color.Gray;
            issueLocation.Text = "Report Address...";

            issueDescription.ForeColor = Color.Gray;
            issueDescription.Text = "Describe your issue here...";

            // Disable typing
            categoryDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            provinceDropdown.DropDownStyle = ComboBoxStyle.DropDownList;

            // Clear existing items just in case
            categoryDropdown.Items.Clear();
            provinceDropdown.Items.Clear();

            // Add placeholder
            categoryDropdown.Items.Add("– Select Issue Type –");

            // Add real categories
            categoryDropdown.Items.Add("Plumbing");
            categoryDropdown.Items.Add("Electrical");
            categoryDropdown.Items.Add("Road Damage");
            categoryDropdown.Items.Add("Other");

            // Select placeholder by default
            categoryDropdown.SelectedIndex = 0;

            // Add placeholder for province
            provinceDropdown.Items.Add("– Select Province –");

            // Add provinces (example)
            provinceDropdown.Items.Add("Western Cape");
            provinceDropdown.Items.Add("Eastern Cape");
            provinceDropdown.Items.Add("Gauteng");
            provinceDropdown.Items.Add("KwaZulu-Natal");
            provinceDropdown.Items.Add("Limpopo");
            provinceDropdown.Items.Add("North West");
            provinceDropdown.Items.Add("Mpumalanga");
            provinceDropdown.Items.Add("Free State");
            provinceDropdown.Items.Add("Northern Cape");

            // Select placeholder by default
            provinceDropdown.SelectedIndex = 0;
        }

        /// <summary>
        /// Submit button click handler.
        /// Validates input, creates a report object, saves it, and resets the form.
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userIdTextBox.Text))
            {
                MessageBox.Show("Please enter your Custom Report ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(issueLocation.Text) || issueLocation.Text == "Report Address...")
            {
                MessageBox.Show("Please enter a valid report location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(issueDescription.Text) || issueDescription.Text == "Describe your issue here...")
            {
                MessageBox.Show("Please enter a valid issue description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (categoryDropdown.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an issue type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gather form input values
            string location = issueLocation.Text.Trim();
            string description = issueDescription.Text.Trim();
            string category = categoryDropdown.SelectedItem?.ToString();
            string province = provinceDropdown.SelectedItem?.ToString();
            string userId = userIdTextBox.Text.Trim();


            // Create report object
            var report = new Report
            {
                Location = location,
                Description = description,
                Category = category,
                Province = province,
                AttachmentPaths = new List<string>(attachedFilePaths),
                UserId = userId
            };

            // Add report to service
            ReportService.AddReport(report);

            // Notify user of success
            MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form after submission
            issueLocation.Text = "Report Address...";
            issueLocation.ForeColor = Color.Gray;
            issueDescription.Text = "Describe your issue here...";
            issueDescription.ForeColor = Color.Gray;
            categoryDropdown.SelectedIndex = 0;
            provinceDropdown.SelectedIndex = 0;
            userIdTextBox.Clear();
            attachedFilePaths.Clear();

            // Reset attach button to default
            attachButton.Text = "Attach Files";
            attachButton.BackColor = SystemColors.Control;
        }

        private void issueLocation_Enter(object sender, EventArgs e)
        {
            if (issueLocation.Text == "Report Address...")
            {
                issueLocation.Text = "";
                issueLocation.ForeColor = Color.Black;
            }
        }

        private void issueLocation_Leave(object sender, EventArgs e)
        {
            // Restore placeholder if user leaves textbox empty
            if (string.IsNullOrWhiteSpace(issueLocation.Text))
            {
                issueLocation.Text = "Report Address...";
                issueLocation.ForeColor = Color.Gray;
            }
        }

        private void issueDescription_Enter(object sender, EventArgs e)
        {
            if (issueDescription.Text == "Describe your issue here...")
            {
                issueDescription.Text = "";
                issueDescription.ForeColor = Color.Black;
            }
        }

        private void issueDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(issueDescription.Text))
            {
                issueDescription.Text = "Describe your issue here...";
                issueDescription.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Opens a file dialog to allow users to attach media files to the report.
        /// </summary>
        private void attachButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select images or documents";
                dialog.Filter = "Images and Documents|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.pdf;*.doc;*.docx;*.txt|All files|*.*";
                dialog.Multiselect = true; // allow multiple files

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    attachedFilePaths.AddRange(dialog.FileNames);

                    // Update button text to show number of attached files
                    if (attachedFilePaths.Count == 1)
                        attachButton.Text = "1 file attached";
                    else
                        attachButton.Text = $"{attachedFilePaths.Count} files attached";

                    
                    attachButton.BackColor = Color.LightGreen;

                   
                    string files = string.Join(Environment.NewLine, dialog.FileNames);
                    MessageBox.Show($"Files attached:\n{files}", "Attachments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Updates the progress bar and label to reflect user engagement.
        /// </summary>
        private void UpdateProgress()
        {
            int progress = 0;

            // Location filled
            if (!string.IsNullOrWhiteSpace(issueLocation.Text) && issueLocation.Text != "Report Address...")
            {
                progress += 25;
            }

            // Description filled
            if (!string.IsNullOrWhiteSpace(issueDescription.Text) && issueDescription.Text != "Describe your issue here...")
            {
                progress += 25;
            }

            // Category selected (not placeholder)
            if (categoryDropdown.SelectedIndex > 0)
            {
                progress += 25;
            }

            // Province selected (not placeholder)
            if (provinceDropdown.SelectedIndex > 0)
            {
                progress += 25;
            }

            // Update progress bar
            progressBarReport.Value = progress;

            if (progress == 100)
            {
                label3.Text = "Report ready to submit ✅";
                label3.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = "Please complete all required fields...";
                label3.ForeColor = Color.Red;
            }
        }


        private void provinceDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }
        private void issueDescription_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void categoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void issueLocation_TextChanged(object sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void progressReport_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Title_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
