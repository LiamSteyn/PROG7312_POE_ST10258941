using IssueReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReportSystem.Services
{
    /// <summary>
    /// Static service class that manages all reports submitted by users.
    /// Stores reports in multiple data structures for efficient retrieval and categorization.
    /// </summary>
    public static class ReportService
    {
        // LinkedList will store ALL reports in the order they were added
        private static LinkedList<Report> reports = new LinkedList<Report>();

        // Queue to track reports with "Pending" status (FIFO order)
        private static Queue<Report> pendingQueue = new Queue<Report>();

        // Stack for "Recently Viewed" reports (LIFO)
        private static Stack<Report> recentReports = new Stack<Report>();

        // Multi-level structure: Province → Category → LinkedList of Reports
        private static Dictionary<string, Dictionary<string, LinkedList<Report>>> reportsByProvinceAndCategory
            = new Dictionary<string, Dictionary<string, LinkedList<Report>>>();

        // HashSet to prevent duplicates (based on unique key: Location+Description)
        private static HashSet<string> reportKeys = new HashSet<string>();

        // Key: User ID (string), Value: List of Reports submitted by that user
        private static Dictionary<string, List<Report>> reportsByUserId
            = new Dictionary<string, List<Report>>();


        private static AdvancedDataStructureService advancedService = new AdvancedDataStructureService();


        /// <summary>
        /// Adds a new report to all relevant data structures.
        /// </summary>
        public static void AddReport(Report report)
        {


            // Generate a unique key for duplicate prevention
            string key = $"{report.Location}-{report.Description}".ToLower();

            if (reportKeys.Contains(key))
            {
                throw new InvalidOperationException("This report already exists (duplicate submission).");
            }

            string userId = report.UserId;

            if (string.IsNullOrWhiteSpace(userId))
            {
                userId = "UNKNOWN_USER"; // Assign a default key to prevent crash
            }

            if (!reportsByUserId.ContainsKey(userId))
            {
                // If not, create a new list for that user
                reportsByUserId[userId] = new List<Report>();
            }

            reportsByUserId[userId].Add(report);

            reportKeys.Add(key);

            // Add to main linked list
            reports.AddLast(report);

            // Add to pending queue if needed
            if (report.Status == "Pending")
            {
                pendingQueue.Enqueue(report);
            }

            // Add to multi-level dictionary
            if (!reportsByProvinceAndCategory.ContainsKey(report.Province))
            {
                reportsByProvinceAndCategory[report.Province] = new Dictionary<string, LinkedList<Report>>();
            }

            if (!reportsByProvinceAndCategory[report.Province].ContainsKey(report.Category))
            {
                reportsByProvinceAndCategory[report.Province][report.Category] = new LinkedList<Report>();
            }

            reportsByProvinceAndCategory[report.Province][report.Category].AddLast(report);

            advancedService.AddReportToBst(report);
            // Note: To make the Min-Heap work correctly, you should ensure ReportId and CreatedAt are set
            report.ReportId = Guid.NewGuid();
            report.CreatedAt = DateTime.Now;
            advancedService.EnqueueReportByPriority(report);
        }


        /// <summary>
        /// Returns all reports in the order they were added.
        /// </summary>
        public static LinkedList<Report> GetReports()
        {
            return reports;
        }

        /// <summary>
        /// Returns a FIFO queue of reports with "Pending" status.
        /// </summary>
        public static Queue<Report> GetPendingQueue()
        {
            return new Queue<Report>(pendingQueue);
        }

        /// <summary>
        /// Returns all reports for a specific province and category.
        /// If none exist, returns an empty linked list.
        /// </summary>
        public static LinkedList<Report> GetReportsByProvinceAndCategory(string province, string category)
        {
            if (reportsByProvinceAndCategory.ContainsKey(province) &&
                reportsByProvinceAndCategory[province].ContainsKey(category))
            {
                return reportsByProvinceAndCategory[province][category];
            }
            return new LinkedList<Report>();
        }

        /// <summary>
        /// Adds a report to the "recently viewed" stack.
        /// Useful for showing last viewed reports (LIFO).
        /// </summary>
        public static void AddRecentReport(Report report)
        {
            recentReports.Push(report);
        }

        /// <summary>
        /// Returns the last viewed report (LIFO) or null if none exist.
        /// </summary>
        public static Report GetLastViewedReport()
        {
            return recentReports.Count > 0 ? recentReports.Pop() : null;
        }

        /// <summary>
        /// Exposes the full dictionary of reports organized by province and category.
        /// Useful for populating filters dynamically.
        /// </summary>
        public static Dictionary<string, Dictionary<string, LinkedList<Report>>> ReportsByProvinceAndCategoryDict
        {
            get { return reportsByProvinceAndCategory; }
        }

        /// <summary>
        /// Returns all reports submitted by a specific user ID.
        /// </summary>
        /// <param name="userId">The unique identifier for the user.</param>
        /// <returns>A list of reports, or an empty list if the user has no reports.</returns>
        public static List<Report> GetReportsByUserId(string userId)
        {
            // O(1) average time complexity for lookup!
            if (reportsByUserId.ContainsKey(userId))
            {
                return reportsByUserId[userId];
            }
            return new List<Report>();
        }

        /// <summary>
        /// Seeds initial reports into the system for demonstration purposes.
        /// Only runs if no reports exist yet to avoid duplicates.
        /// </summary>
        public static void SeedReports()
        {
            if (reports.Count > 0) return; // don't seed again if reports exist

            var seededReports = new List<Report>
            {
                new Report { UserId = "TEST_C", Province = "Western Cape", Category = "Road Damage", Location = "Gugulethu", Description = "Potholes on Main Street need urgent repair.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-20) },
                new Report { UserId = "TEST_C", Province = "Western Cape", Category = "Plumbing", Location = "Claremont", Description = "Broken water pipe causing flooding near the library.", Status = "In Progress", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_B", Province = "Gauteng", Category = "Electrical", Location = "Soweto", Description = "Street lights not working along 5th Avenue.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "KwaZulu-Natal", Category = "Other", Location = "Durban Central", Description = "Graffiti on public property needs cleanup.", Status = "Resolved", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_B", Province = "Eastern Cape", Category = "Road Damage", Location = "Port Elizabeth", Description = "Traffic signals malfunctioning at 3rd Street intersection.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "Western Cape", Category = "Electrical", Location = "Woodstock", Description = "Power outage affecting multiple homes.", Status = "In Progress", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_B", Province = "Gauteng", Category = "Plumbing", Location = "Midrand", Description = "Leaking municipal water main in residential area.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "Limpopo", Category = "Road Damage", Location = "Polokwane", Description = "Road shoulder collapsed near highway exit.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "Western Cape", Category = "Other", Location = "Sea Point", Description = "Abandoned vehicle blocking parking bays.", Status = "Resolved", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "KwaZulu-Natal", Category = "Plumbing", Location = "Pietermaritzburg", Description = "Water supply issue in residential block.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) }
            };

            // Add seeded reports to all relevant data structures
            foreach (var r in seededReports)
            {
                AddReport(r);
            }
        }

        /// <summary>
        /// Returns all reports sorted alphabetically by location using the BST's In-Order traversal.
        /// (Meets the "organising and retrieving" requirement via Tree)
        /// </summary>
        public static List<Report> GetReportsSortedByLocation()
        {
            return advancedService.GetReportsSortedByLocation();
        }

        /// <summary>
        /// Retrieves and removes the single highest priority report (the oldest report) from the Min-Heap.
        /// (Meets the "optimise the display of service request status" requirement via Heap)
        /// </summary>
        public static Report DequeueHighestPriorityReport()
        {
            return advancedService.DequeueHighestPriorityReport();
        }
    }
}
