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
using IssueReportSystem.Services;
using IssueReportSystem.Models;
using System.Data.SqlTypes;

namespace IssueReportSystem
{
    public partial class ViewReportsForm : Form
    {
        public ViewReportsForm()
        {
            InitializeComponent();

            // Load the filter dropdowns and all reports initially
            LoadFilters();
            LoadAllReports();

            // Disable resizing for consistent layout
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; // Hide maximize button
            this.MinimizeBox = true;  // Keep minimize button
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Populates the province and category dropdowns with unique values.
        /// Adds a default "All" option to allow unfiltered searches.
        /// </summary>
        private void LoadFilters()
        {
            comboProvince.Items.Clear();
            comboProvince.Items.Add("All"); // Default option for no filter

            comboCategory.Items.Clear();
            comboCategory.Items.Add("All"); // Default option for no filter

            // Populate dropdowns with unique provinces and categories from seeded/user reports
            foreach (var province in ReportService.ReportsByProvinceAndCategoryDict.Keys)
            {
                comboProvince.Items.Add(province);

                foreach (var category in ReportService.ReportsByProvinceAndCategoryDict[province].Keys)
                {
                    if (!comboCategory.Items.Contains(category))
                        comboCategory.Items.Add(category);
                }
            }

            // Set default selection to "All"
            comboProvince.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads all reports into the DataGridView without any filters.
        /// Converts reports into an anonymous type for display.
        /// </summary>
        private void LoadAllReports()
        {
            dataGridViewReports.DataSource = ReportService.GetReports()
                .Select(r => new
                {
                    r.UserId,
                    r.Province,
                    r.Category,
                    r.Location,
                    r.Description,
                    r.Status
                })
                .ToList();
        }

        /// <summary>
        /// Applies filters selected in the dropdowns and updates the DataGridView.
        /// "All" in either dropdown means no filter for that field.
        /// </summary>
        private void ApplyFilters()
        {
            string selectedCategory = comboCategory.SelectedItem?.ToString() ?? "All";
            string selectedProvince = comboProvince.SelectedItem?.ToString() ?? "All";

            // If both filters are "All", show all reports
            if (selectedProvince == "All" && selectedCategory == "All")
            {
                LoadAllReports();
                return;
            }

            // Filter reports based on selected province and category
            var filteredReports = ReportService.GetReports()
                .Where(r =>
                    (selectedProvince == "All" || r.Province == selectedProvince) &&
                    (selectedCategory == "All" || r.Category == selectedCategory))
                .Select(r => new
                {
                    r.Province,
                    r.Category,
                    r.Location,
                    r.Description,
                    r.Status
                })
                .ToList();

            dataGridViewReports.DataSource = filteredReports;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Currently unused; filtering is applied manually with the Search button
        }

        /// <summary>
        /// Form load event. Ensures seeded reports are present,
        /// populates dropdowns, and displays all reports.
        /// </summary>
        private void ViewReportsForm_Load(object sender, EventArgs e)
        {
            ReportService.SeedReports(); // ensure seeded data is present
            LoadFilters();               // populate dropdowns with all data
            ApplyFilters();              // display all reports including seeded ones
        }

        private void dataGridReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Can be used for row click events in future (e.g., view report details)
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Close form when Back button is clicked
        }

        // Placeholder event handlers for UI labels (can be removed if unused)
        private void label1_Click(object sender, EventArgs e){}
        private void label3_Click(object sender, EventArgs e){}
        private void label4_Click(object sender, EventArgs e){}
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e){}
        private void label5_Click(object sender, EventArgs e){}

        /// <summary>
        /// Search button click event.
        /// Applies filters based on selected province and category.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
