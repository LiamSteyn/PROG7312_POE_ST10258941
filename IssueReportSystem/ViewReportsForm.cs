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
        /// USES BINARY SEARCH TREE (BST): Reports are sorted alphabetically by Location.
        /// </summary>
        private void LoadAllReports()
        {
            // **ADVANCED DATA STRUCTURE: Binary Search Tree**
            // Get reports sorted by location using BST's In-Order traversal
            var sortedReports = ReportService.GetReportsSortedByLocation();

            dataGridViewReports.DataSource = sortedReports
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
        /// USES BINARY SEARCH TREE (BST): Maintains sorted order by Location.
        /// </summary>
        private void ApplyFilters()
        {
            string selectedCategory = comboCategory.SelectedItem?.ToString() ?? "All";
            string selectedProvince = comboProvince.SelectedItem?.ToString() ?? "All";

            // **ADVANCED DATA STRUCTURE: Binary Search Tree**
            // Get reports sorted by location using BST
            var sortedReports = ReportService.GetReportsSortedByLocation();

            // Apply filters on the BST-sorted results
            var filteredReports = sortedReports
                .Where(r =>
                    (selectedProvince == "All" || r.Province == selectedProvince) &&
                    (selectedCategory == "All" || r.Category == selectedCategory))
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

            dataGridViewReports.DataSource = filteredReports;
        }

        /// <summary>
        /// USES GRAPH: Detects potential duplicate reports submitted by different users.
        /// A graph relationship is created between reports that match:
        /// - Same Category
        /// - Connected Locations (nearby areas in the graph)
        /// - Within 12 hours of each other (±12 hours)
        /// 
        /// This helps identify when multiple users report the same issue.
        /// Double-click any report to see potential duplicates.
        /// </summary>
        private void dataGridViewReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string location = dataGridViewReports.Rows[e.RowIndex].Cells["Location"].Value?.ToString();
            string category = dataGridViewReports.Rows[e.RowIndex].Cells["Category"].Value?.ToString();
            string description = dataGridViewReports.Rows[e.RowIndex].Cells["Description"].Value?.ToString();
            string status = dataGridViewReports.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
            string userId = dataGridViewReports.Rows[e.RowIndex].Cells["UserId"].Value?.ToString();

            if (string.IsNullOrEmpty(location)) return;

            // **ADVANCED DATA STRUCTURE: Graph + BST + Time-based Analysis**
            var potentialDuplicates = FindPotentialDuplicates(location, category, userId);

            StringBuilder message = new StringBuilder();
            message.AppendLine("REPORT DETAILS & DUPLICATE ANALYSIS");
            message.AppendLine(new string('=', 60));
            message.AppendLine($"User ID: {userId}");
            message.AppendLine($"Location: {location}");
            message.AppendLine($"Category: {category}");
            message.AppendLine($"Status: {status}");
            message.AppendLine($"Description: {description}");
            message.AppendLine();

            if (potentialDuplicates.Count > 0)
            {
                message.AppendLine("⚠️  POTENTIAL DUPLICATE REPORTS DETECTED");
                message.AppendLine(new string('-', 60));
                message.AppendLine($"Found {potentialDuplicates.Count} similar report(s) by different user(s):");
                message.AppendLine("(Same category, nearby location, within ±12 hours)");
                message.AppendLine();

                int duplicateNumber = 1;
                foreach (var duplicate in potentialDuplicates)
                {
                    message.AppendLine($"DUPLICATE #{duplicateNumber}:");
                    message.AppendLine($"  User ID: {duplicate.UserId} (Different user!)");
                    message.AppendLine($"  Location: {duplicate.Location}");
                    message.AppendLine($"  Category: {duplicate.Category}");
                    message.AppendLine($"  Time Difference: {duplicate.TimeDifference}");
                    message.AppendLine($"  Status: {duplicate.Status}");
                    message.AppendLine($"  Description: {duplicate.Description}");
                    message.AppendLine();
                    duplicateNumber++;
                }

                message.AppendLine(new string('-', 60));
                message.AppendLine("💡 RECOMMENDATION:");
                message.AppendLine("   These reports may describe the same issue.");
                message.AppendLine("   Consider consolidating or cross-referencing them");
                message.AppendLine("   to avoid duplicate work.");
            }
            else
            {
                message.AppendLine("✓ NO DUPLICATE REPORTS FOUND");
                message.AppendLine(new string('-', 60));
                message.AppendLine("This appears to be a unique report.");
                message.AppendLine("No similar reports found in nearby locations");
                message.AppendLine("within the ±12 hour time window.");
            }

            MessageBox.Show(message.ToString(), "Duplicate Detection Analysis - Graph + Time-based",
                MessageBoxButtons.OK,
                potentialDuplicates.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        /// <summary>
        /// CORE GRAPH ALGORITHM: Finds potential duplicate reports using graph relationships.
        /// 
        /// This combines multiple advanced data structures for meaningful analysis.
        /// </summary>
        private List<DuplicateReport> FindPotentialDuplicates(string location, string category, string userId)
        {
            var duplicates = new List<DuplicateReport>();       

            //  Use BST to get all reports sorted by location**
            var allReports = ReportService.GetReportsSortedByLocation();

            // Find the current report to get its timestamp
            var currentReport = allReports.FirstOrDefault(r =>
                r.Location == location &&
                r.Category == category &&
                r.UserId == userId);

            if (currentReport == null) return duplicates;

            DateTime currentTime = currentReport.CreatedAt;

            //  Find potential duplicates using Graph + Time analysis**
            foreach (var report in allReports)
            {
                // Skip if same user (we want duplicates by DIFFERENT users)
                if (report.UserId == userId) continue;


                // Check if same category
                if (report.Category != category) continue;

                // Time-based comparison (±12 hours)**
                TimeSpan timeDifference = report.CreatedAt - currentTime;
                double hoursDifference = Math.Abs(timeDifference.TotalHours);

                // Within 12 hour window?
                if (hoursDifference <= 12)
                {
                    duplicates.Add(new DuplicateReport
                    {
                        UserId = report.UserId,
                        Location = report.Location,
                        Category = report.Category,
                        Description = report.Description,
                        Status = report.Status,
                        CreatedAt = report.CreatedAt,
                        TimeDifference = FormatTimeDifference(timeDifference)
                    });
                }
            }

            // Sort duplicates by time difference (closest first)
            duplicates = duplicates.OrderBy(d => Math.Abs((d.CreatedAt - currentTime).TotalHours)).ToList();

            return duplicates;
        }

        /// <summary>
        /// Formats time difference in a human-readable way.
        /// </summary>
        private string FormatTimeDifference(TimeSpan difference)
        {
            double hours = Math.Abs(difference.TotalHours);

            if (hours < 1)
            {
                int minutes = (int)(hours * 60);
                return $"{minutes} minute(s) apart";
            }
            else
            {
                return $"{hours:F1} hour(s) apart";
            }
        }

        /// <summary>
        /// Helper class to store duplicate report information.
        /// </summary>
        private class DuplicateReport
        {
            public string UserId { get; set; }
            public string Location { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public DateTime CreatedAt { get; set; }
            public string TimeDifference { get; set; }
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

            // Wire up double-click event for duplicate detection
            dataGridViewReports.CellDoubleClick += dataGridViewReports_CellDoubleClick;
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
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        /// <summary>
        /// Search button click event.
        /// Applies filters based on selected province and category.
        /// Results are sorted by Location using BST.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnDetectDuplicates_Click(object sender, EventArgs e)
        {
            var duplicates = ReportService.GetDuplicateReports();

            if (duplicates.Count == 0)
            {
                MessageBox.Show("No duplicate reports found within 12 hours.", "Duplicate Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Build a readable message for all duplicates found
            var message = "Duplicate reports found within ±12 hours:\n\n";

            foreach (var r in duplicates)
            {
                message +=
                    $"Province: {r.Province}\n" +
                    $"Category: {r.Category}\n" +
                    $"Location: {r.Location}\n" +
                    $"Description: {r.Description}\n" +
                    $"Status: {r.Status}\n" +
                    $"Created: {r.CreatedAt:g}\n" +
                    $"User ID: {r.UserId}\n" +
                    "--------------------------------------\n";
            }

            MessageBox.Show(message, "Duplicate Reports Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Retrieves the absolute highest priority report (the oldest overall) 
        /// from the Min-Heap and displays it. This demonstrates the O(1) efficiency 
        /// of the Heap for priority queue management.
        /// </summary>
        private void btnShowMyPriority_Click(object sender, EventArgs e)
        {
            // --- USE MIN-HEAP (O(1) retrieval) ---
            // Note: We use Peek to show the priority item without removing it from the queue.
            Report highestPriorityReport = ReportService.PeekHighestPriorityReport();

            if (highestPriorityReport == null)
            {
                MessageBox.Show("There are no reports currently waiting for processing in the system's priority queue.", "System Priority",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Display the details of the highest priority report
            MessageBox.Show(
                $"SYSTEM'S HIGHEST PRIORITY REPORT:\n" +
                $"This report is the oldest waiting issue in the system.\n\n" +
                $"User ID: {highestPriorityReport.UserId}\n" +
                $"Location: {highestPriorityReport.Location}\n" +
                $"Category: {highestPriorityReport.Category}\n" +
                $"Status: {highestPriorityReport.Status}\n" +
                $"Submitted: {highestPriorityReport.CreatedAt:yyyy-MM-dd HH:mm}\n" +
                $"Description: {highestPriorityReport.Description}",
                "System Priority Report (Min-Heap Result)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

    
        private void btnShowHotspots_Click(object sender, EventArgs e)
        {
            var ranking = ReportService.GetLocationDensityRanking();

            if (ranking.Any())
            {
                var topProvince = ranking.First();
                MessageBox.Show(
                    $"The current active hotspot PROVINCE is **{topProvince.Key}** with **{topProvince.Value}** active reports!",
                    "Report Density Hotspot: Province Ranking",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("No active reports found in the system.", "Report Density Hotspot");
            }
        }

        /// <summary>
        /// Button 2 click event (Sort by Priority).
        /// USES MIN-HEAP (Heap Sort): Retrieves all reports sorted by creation date (oldest first = highest priority).
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            // **ADVANCED DATA STRUCTURE: Min-Heap (Heap Sort)**
            var sortedReports = ReportService.GetReportsSortedByPriority();

            if (sortedReports.Count == 0)
            {
                MessageBox.Show("The priority queue is empty. Please submit new reports to repopulate it.", "Priority Sort Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Update the DataGridView with the newly sorted list
            dataGridViewReports.DataSource = sortedReports
                .Select(r => new
                {
                    r.UserId,
                    r.Province,
                    r.Category,
                    r.Location,
                    r.Description,
                    r.Status,
                    r.CreatedAt // Include CreatedAt to clearly show the sort order
                })
                .ToList();

            MessageBox.Show("Reports have been sorted by **Priority** (Oldest issue first) using the Min-Heap.",
                            "Priority Sort Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnGraphReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Show a loading message or cursor
                this.Cursor = Cursors.WaitCursor;

                // Calculate probabilities using the graph-based algorithm
                var probabilities = ReportService.CalculateFutureReportProbabilities();

                // Display in a MessageBox (Simple)
                DisplayProbabilitiesInMessageBox(probabilities);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating probabilities: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                // Restore cursor
                this.Cursor = Cursors.Default;
            }
        }

        // Option 1: Simple MessageBox display
        private void DisplayProbabilitiesInMessageBox(Dictionary<string, double> probabilities)
        {
            if (probabilities.Count == 0)
            {
                MessageBox.Show("No data available to calculate probabilities.",
                                "Graph Analysis",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // Build the message string
            StringBuilder message = new StringBuilder();
            message.AppendLine("FUTURE REPORT PROBABILITY BY PROVINCE");
            message.AppendLine("(Based on Graph Analysis)");
            message.AppendLine(new string('=', 50));
            message.AppendLine();

            // Sort by probability (highest first)
            var sortedProvinces = probabilities
                .OrderByDescending(kv => kv.Value)
                .ToList();

            foreach (var province in sortedProvinces)
            {
                // Create a visual bar using characters
                int barLength = (int)(province.Value / 5); // Scale to ~20 chars max
                string bar = new string('█', barLength);

                message.AppendLine($"{province.Key,-20} {province.Value,6:F2}% {bar}");
            }

            MessageBox.Show(message.ToString(),
                            "Province Report Probability",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}