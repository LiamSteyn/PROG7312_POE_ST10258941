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
        /// Seeds initial reports into the system for demonstration purposes.
        /// Only runs if no reports exist yet to avoid duplicates.
        /// </summary>
        public static void SeedReports()
        {
            if (reports.Count > 0) return; // don't seed again if reports exist

            var seededReports = new List<Report>
            {
                new Report { Province = "Western Cape", Category = "Road Damage", Location = "Gugulethu", Description = "Potholes on Main Street need urgent repair.", Status = "Pending" },
                new Report { Province = "Western Cape", Category = "Plumbing", Location = "Claremont", Description = "Broken water pipe causing flooding near the library.", Status = "In Progress" },
                new Report { Province = "Gauteng", Category = "Electrical", Location = "Soweto", Description = "Street lights not working along 5th Avenue.", Status = "Pending" },
                new Report { Province = "KwaZulu-Natal", Category = "Other", Location = "Durban Central", Description = "Graffiti on public property needs cleanup.", Status = "Resolved" },
                new Report { Province = "Eastern Cape", Category = "Road Damage", Location = "Port Elizabeth", Description = "Traffic signals malfunctioning at 3rd Street intersection.", Status = "Pending" },
                new Report { Province = "Western Cape", Category = "Electrical", Location = "Woodstock", Description = "Power outage affecting multiple homes.", Status = "In Progress" },
                new Report { Province = "Gauteng", Category = "Plumbing", Location = "Midrand", Description = "Leaking municipal water main in residential area.", Status = "Pending" },
                new Report { Province = "Limpopo", Category = "Road Damage", Location = "Polokwane", Description = "Road shoulder collapsed near highway exit.", Status = "Pending" },
                new Report { Province = "Western Cape", Category = "Other", Location = "Sea Point", Description = "Abandoned vehicle blocking parking bays.", Status = "Resolved" },
                new Report { Province = "KwaZulu-Natal", Category = "Plumbing", Location = "Pietermaritzburg", Description = "Water supply issue in residential block.", Status = "Pending" }
            };

            // Add seeded reports to all relevant data structures
            foreach (var r in seededReports)
            {
                AddReport(r);
            }
        }


    }
}
