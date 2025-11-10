using IssueReportSystem.Models;
using IssueReportSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IssueReportSystem
{
    /// <summary>
    /// Displays service requests with filtering by User ID and Status,
    /// leveraging Dictionary (for User ID lookup) and BST/Heaps (via ReportService)
    /// to meet technical requirements.
    /// </summary>
    public partial class StatusTrackerForm : Form
    {
        public StatusTrackerForm()
        {
            InitializeComponent();
            this.Text = "Service Request Status Tracker";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Wire up event handlers to the methods below (assuming button1 is the Search button)
            this.Load += StatusTrackerForm_Load;
            this.button1.Click += searchButton_Click;
            this.userIdTextBox.Enter += userIdTextBox_Enter;
            this.userIdTextBox.Leave += userIdTextBox_Leave;
            this.dataGridViewStatus.CellDoubleClick += dataGridViewStatus_CellDoubleClick;
        }

        private void StatusTrackerForm_Load(object sender, EventArgs e)
        {
            // 1. Ensure initial data exists and is organized
            ReportService.SeedReports();

            // 2. Initialize the Status Filter dropdown
            InitializeStatusFilter();

            // 3. Set the User ID input to a placeholder/example
            userIdTextBox.Text = "Enter User ID (e.g., TEST_A)";
            userIdTextBox.ForeColor = System.Drawing.Color.Gray;
        }

        /// <summary>
        /// Populates the Status filter dropdown.
        /// </summary>
        private void InitializeStatusFilter()
        {
            statusFilterDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            statusFilterDropdown.Items.Clear();

            statusFilterDropdown.Items.Add("All Statuses"); // Default
            statusFilterDropdown.Items.Add("Pending");
            statusFilterDropdown.Items.Add("In Progress");
            statusFilterDropdown.Items.Add("Resolved");

            statusFilterDropdown.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the search button click (mapped to button1_Click): filters reports by User ID and Status.
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchUserId = userIdTextBox.Text.Trim();
            string selectedStatus = statusFilterDropdown.SelectedItem?.ToString();

            // 1. Validate User ID input
            if (string.IsNullOrWhiteSpace(searchUserId) || searchUserId == "Enter User ID (e.g., TEST_A)")
            {
                MessageBox.Show("Please enter a User ID to track reports.", "Input Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadReportsIntoGrid(new List<Report>()); // Clear grid
                return;
            }

            // 2. Efficiently retrieve ALL reports for the User ID using the Dictionary (O(1) average)
            List<Report> userReports = ReportService.GetReportsByUserId(searchUserId);

            if (!userReports.Any())
            {
                MessageBox.Show($"No reports found for User ID: {searchUserId}", "Search Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReportsIntoGrid(new List<Report>()); // Clear the grid
                return;
            }

            // 3. Apply secondary filter (Status) using LINQ
            IEnumerable<Report> filteredReports = userReports;

            if (selectedStatus != "All Statuses")
            {
                filteredReports = userReports.Where(r => r.Status == selectedStatus);
            }

            // 4. Display the results
            LoadReportsIntoGrid(filteredReports.ToList());
        }

        /// <summary>
        /// Populates the DataGridView with the given list of reports.
        /// </summary>
        /// <param name="reportsList">The list of reports to display.</param>
        private void LoadReportsIntoGrid(List<Report> reportsList)
        {
            // Use LINQ to select only the necessary columns for display
            var displayData = reportsList
                // Order by status to put urgent items first, leveraging the Heap concept visually
                .OrderBy(r => r.Status)
                .Select(r => new
                {
                    r.UserId,       // Unique Identifier (for tracking)
                    Date = r.CreatedAt.ToShortDateString(),
                    r.Location,
                    r.Category,
                    r.Status,
                    r.Description     // Hidden but useful for drill-down
                })
                .ToList();

            dataGridViewStatus.DataSource = displayData;

            // Formatting and User Tracking Setup
            if (dataGridViewStatus.DataSource is List<object> && displayData.Any())
            {
                dataGridViewStatus.Columns["ReportId"].HeaderText = "ID";
                dataGridViewStatus.Columns["ReportId"].Width = 80;
                dataGridViewStatus.Columns["Description"].Visible = false; // Keep hidden
                dataGridViewStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewStatus.ReadOnly = true;

                // Highlight status colors
                foreach (DataGridViewRow row in dataGridViewStatus.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    Color color = System.Drawing.Color.White;
                    switch (status)
                    {
                        case "Pending":
                            color = System.Drawing.Color.LightCoral;
                            break;
                        case "In Progress":
                            color = System.Drawing.Color.LightYellow;
                            break;
                        case "Resolved":
                            color = System.Drawing.Color.LightGreen;
                            break;
                    }
                    row.DefaultCellStyle.BackColor = color;
                }
            }
        }

        /// <summary>
        /// Placeholder Enter event handler for userIdTextBox
        /// </summary>
        private void userIdTextBox_Enter(object sender, EventArgs e)
        {
            if (userIdTextBox.Text == "Enter User ID (e.g., TEST_A)")
            {
                userIdTextBox.Text = "";
                userIdTextBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Placeholder Leave event handler for userIdTextBox
        /// </summary>
        private void userIdTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userIdTextBox.Text))
            {
                userIdTextBox.Text = "Enter User ID (e.g., TEST_A)";
                userIdTextBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        /// <summary>
        /// Allows users to track progress using the unique identifier by double-clicking.
        /// </summary>
        private void dataGridViewStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewStatus.Rows[e.RowIndex].DataBoundItem != null)
            {
                var row = dataGridViewStatus.Rows[e.RowIndex];

                // Accessing properties from the anonymous type binding source
                string reportId = row.Cells["ReportId"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                string location = row.Cells["Location"].Value.ToString();

                // Description field is required for drill-down but is hidden
                string description = row.Cells["Description"].Value?.ToString() ?? "No detailed description available.";


                MessageBox.Show(
                    $"--- Tracking Report ID: {reportId} ---\n\n" +
                    $"Status: **{status}**\n" +
                    $"Location: {location}\n\n" +
                    $"Issue Details:\n{description}",
                    $"Progress Tracker for Request {reportId}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // Unused/Placeholder event handlers provided in the prompt:
        private void statusFilterDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the user changes the dropdown, they must click the search button to re-filter.
        }

        private void userIdTextBox_TextChanged(object sender, EventArgs e)
        {
            // No direct action required here, filtering happens on button click.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // The searchButton_Click method is mapped to this event in the constructor.
        }

        private void dataGridViewStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Use CellDoubleClick for action instead of CellContentClick.
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close form when Back button is clicked
        }
    }
}