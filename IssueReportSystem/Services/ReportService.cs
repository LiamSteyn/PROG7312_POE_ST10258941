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
                new Report { UserId = "TEST_A", Province = "Western Cape", Category = "Road Damage", Location = "Claremont Street 2", Description = "Potholes on Main Street need urgent repair.", Status = "In Progress", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_B", Province = "Gauteng", Category = "Electrical", Location = "Soweto Street 1", Description = "Street lights not working along 5th Avenue.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "KwaZulu-Natal", Category = "Other", Location = "Durban Central Street 2", Description = "Graffiti on public property needs cleanup.", Status = "Resolved", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_B", Province = "Eastern Cape", Category = "Road Damage", Location = "Port Elizabeth", Description = "Traffic signals malfunctioning at 3rd Street intersection.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_C", Province = "Western Cape", Category = "Plumbing", Location = "Claremont Street 1", Description = "Water is currently off.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-8) },
                new Report { UserId = "TEST_D", Province = "Western Cape", Category = "Electrical", Location = "Claremont Street 3", Description = "Electricity is currently off.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-8) },
                new Report { UserId = "TEST_A", Province = "Western Cape", Category = "Electrical", Location = "Woodstock Street 2", Description = "Power outage affecting multiple homes.", Status = "In Progress", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_B", Province = "Gauteng", Category = "Plumbing", Location = "Midrand Street 1", Description = "Leaking municipal water main in residential area.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "Limpopo", Category = "Road Damage", Location = "Polokwane Street 1", Description = "Road shoulder collapsed near highway exit.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "Western Cape", Category = "Other", Location = "Sea Point Street 1", Description = "Abandoned vehicle blocking parking bays.", Status = "Resolved", CreatedAt = DateTime.Now.AddHours(-10) },
                new Report { UserId = "TEST_A", Province = "KwaZulu-Natal", Category = "Plumbing", Location = "Pietermaritzburg Street 1", Description = "Water supply issue in residential block.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-12) },
                new Report { UserId = "TEST_C", Province = "Western Cape", Category = "Road Damage", Location = "Claremont Street 2", Description = "Alot of potholes in the area.", Status = "Pending", CreatedAt = DateTime.Now.AddHours(-9) }
            };

            // Add seeded reports to all relevant data structures
            foreach (var r in seededReports)
            {
                AddReport(r);
            }
        }

        /// <summary>
        /// Retrieves the single highest priority report (the oldest report) from the Min-Heap
        /// without removing it. (O(1) time complexity).    
        /// </summary>
        public static Report PeekHighestPriorityReport()
        {
            return advancedService.PeekHighestPriorityReport();
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
        /// Retrieves a ranking of locations based on the number of active reports, 
        /// utilizing the AdvancedDataStructureService for analysis.
        /// </summary>
        public static Dictionary<string, int> GetLocationDensityRanking()
        {
            return advancedService.GetLocationDensityRanking();
        }

        /// <summary>
        /// Finds duplicate reports that share the same Location and Category
        /// within ±12 hours of each other.
        /// </summary>
        public static List<Report> GetDuplicateReports()
        {
            var duplicateReports = new List<Report>();

            var reportList = reports.ToList();

            for (int i = 0; i < reportList.Count; i++)
            {
                for (int j = i + 1; j < reportList.Count; j++)
                {
                    var r1 = reportList[i];
                    var r2 = reportList[j];

                    // Check if same location + category, and within ±12 hours
                    if (r1.Location.Equals(r2.Location, StringComparison.OrdinalIgnoreCase) &&
                        r1.Category.Equals(r2.Category, StringComparison.OrdinalIgnoreCase) &&
                        Math.Abs((r1.CreatedAt - r2.CreatedAt).TotalHours) <= 12)
                    {
                        if (!duplicateReports.Contains(r1))
                            duplicateReports.Add(r1);
                        if (!duplicateReports.Contains(r2))
                            duplicateReports.Add(r2);
                    }
                }
            }

            return duplicateReports;
        }

        /// <summary>
        /// Returns ALL reports sorted by priority (oldest first) using the Min-Heap (Heap Sort logic).
        /// This demonstrates the full functionality of the Heap structure.
        /// NOTE: This clears the internal priority queue, but it is then IMMEDIATELY rebuilt.
        /// </summary>
        public static List<Report> GetReportsSortedByPriority()
        {
            List<Report> sortedList = new List<Report>();

            // 1. Store the reports needed for REBUILDING THE HEAP after the sort.
            // The heap will be empty after the loop below runs.
            List<Report> reportsToRebuild = advancedService.GetAllReportsFromHeap();

            // 2. Dequeue all reports into the sorted list (O(n log n))
            // This empties the heap.
            while (true)
            {
                Report nextReport = advancedService.DequeueHighestPriorityReport();

                if (nextReport == null)
                    break;

                sortedList.Add(nextReport);
            }

            // 3. Rebuild the heap by re-enqueuing all reports. (O(n log n))
            // Use the list we saved in step 1.
            foreach (var report in reportsToRebuild)
            {
                advancedService.EnqueueReportByPriority(report);
            }

            return sortedList;
        }

    }
}
