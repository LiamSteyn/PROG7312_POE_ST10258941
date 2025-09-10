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
            LoadFilters();
            LoadAllReports();

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; // Hide maximize button
            this.MinimizeBox = true;  // Keep minimize if you want
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Load unique provinces and categories into dropdowns
        private void LoadFilters()
        {
            comboProvince.Items.Clear();
            comboProvince.Items.Add("All");

            comboCategory.Items.Clear();
            comboCategory.Items.Add("All");

            foreach (var province in ReportService.ReportsByProvinceAndCategoryDict.Keys)
            {
                comboProvince.Items.Add(province);

                foreach (var category in ReportService.ReportsByProvinceAndCategoryDict[province].Keys)
                {
                    if (!comboCategory.Items.Contains(category))
                        comboCategory.Items.Add(category);
                }
            }

            comboProvince.SelectedIndex = 0;
            comboCategory.SelectedIndex = 0;
        }

        // Load ALL reports into DataGridView
        private void LoadAllReports()
        {
            dataGridViewReports.DataSource = ReportService.GetReports()
                .Select(r => new
                {
                    r.Province,
                    r.Category,
                    r.Location,
                    r.Description,
                    r.Status
                })
                .ToList();
        }

        // Load reports based on filters
        private void ApplyFilters()
        {
            string selectedCategory = comboCategory.SelectedItem?.ToString() ?? "All";
            string selectedProvince = comboProvince.SelectedItem?.ToString() ?? "All";


            if (selectedProvince == "All" && selectedCategory == "All")
            {
                LoadAllReports();
                return;
            }

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
            ApplyFilters();
        }

        private void ViewReportsForm_Load(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dataGridReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
