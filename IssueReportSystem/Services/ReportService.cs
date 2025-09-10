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


        //Get all the reports
        public static LinkedList<Report> GetReports()
        {
            return reports;
        }

        // Get FIFO queue of pending reports
        public static Queue<Report> GetPendingQueue()
        {
            return new Queue<Report>(pendingQueue);
        }

        // Get reports by Province & Category
        public static LinkedList<Report> GetReportsByProvinceAndCategory(string province, string category)
        {
            if (reportsByProvinceAndCategory.ContainsKey(province) &&
                reportsByProvinceAndCategory[province].ContainsKey(category))
            {
                return reportsByProvinceAndCategory[province][category];
            }
            return new LinkedList<Report>();
        }

        // Add to "recently viewed reports" stack
        public static void AddRecentReport(Report report)
        {
            recentReports.Push(report);
        }

        // Get last viewed report (LIFO)
        public static Report GetLastViewedReport()
        {
            return recentReports.Count > 0 ? recentReports.Pop() : null;
        }

        // Expose the whole province/category dictionary
        public static Dictionary<string, Dictionary<string, LinkedList<Report>>> ReportsByProvinceAndCategoryDict
        {
            get { return reportsByProvinceAndCategory; }
        }
    }
}
