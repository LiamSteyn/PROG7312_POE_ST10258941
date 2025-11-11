// The 'using' statements bring in necessary namespaces and types.
using IssueReportSystem.Models; // Imports the data models, specifically the 'Report' class.
using System;                   // Provides fundamental classes and base types (e.g., DateTime, StringComparison).
using System.Collections.Generic; // Provides interfaces and classes for generic collections (e.g., List<T>, Dictionary<TKey, TValue>).
using System.Linq;                // Provides Language-Integrated Query (LINQ) features.
using System.Text;                // Provides classes for working with strings and encoding (not directly used here, but kept).
using System.Threading.Tasks;     // Provides types for implementing asynchronous operations (not directly used here, but kept).

// Define the namespace for the application's service layer.
namespace IssueReportSystem.Services
{

    // Static class that acts as the main repository and management service for Report objects.
    // It utilizes various data structures for different access patterns.
    public static class ReportService
    {
        // LinkedList will store ALL reports in the order they were added (insertion order).
        private static LinkedList<Report> reports = new LinkedList<Report>();

        // Queue to track reports with "Pending" status (First-In, First-Out, for processing).
        private static Queue<Report> pendingQueue = new Queue<Report>();

        // Stack for "Recently Viewed" reports (Last-In, First-Out, for typical undo/back functionality).
        private static Stack<Report> recentReports = new Stack<Report>();

        // Multi-level structure: Province (Key 1) → Category (Key 2) → LinkedList of Reports.
        // Allows efficient lookup of reports by a combination of geographic location and type.
        private static Dictionary<string, Dictionary<string, LinkedList<Report>>> reportsByProvinceAndCategory
      = new Dictionary<string, Dictionary<string, LinkedList<Report>>>();

        // HashSet to prevent duplicates or quickly check for existence of a unique report key.
        // The key is based on a concatenation of Location and Description.
        private static HashSet<string> reportKeys = new HashSet<string>();

        // Dictionary for efficient O(1) average time complexity lookup of reports by the user who submitted them.
        // Key: User ID (string), Value: List of Reports submitted by that user.
        private static Dictionary<string, List<Report>> reportsByUserId
      = new Dictionary<string, List<Report>>();


        // Instance of the AdvancedDataStructureService to handle BST and Min-Heap operations.
        private static AdvancedDataStructureService advancedService = new AdvancedDataStructureService();



        // Public static method to add a new Report to all relevant data structures.
        public static void AddReport(Report report)
        {

            // Generate a unique key for duplicate prevention check (case-insensitive key).
            string key = $"{report.Location}-{report.Description}".ToLower();

            // Checks if a report with this specific Location and Description already exists.
            if (reportKeys.Contains(key))
            {
                // Current implementation does nothing if a duplicate is found (i.e., it proceeds to add it).
                // The `reportKeys.Add(key);` later on would still run and fail to add the key if it exists,
                // but the report object itself is added to all other structures.
            }

            string userId = report.UserId;

            // Robustness check: Ensure UserId is not null or whitespace.
            if (string.IsNullOrWhiteSpace(userId))
            {
                userId = "UNKNOWN_USER"; // Assign a default key to prevent crash when accessing the dictionary.
            }

            // Check if the user ID has an entry in the reportsByUserId dictionary.
            if (!reportsByUserId.ContainsKey(userId))
            {
                // If not, create a new list for that user's reports.
                reportsByUserId[userId] = new List<Report>();
            }

            // Add the report to the user's specific list.
            reportsByUserId[userId].Add(report);

            // Attempt to add the unique key to the HashSet.
            reportKeys.Add(key);

            // Add to main linked list (maintains chronological insertion order).
            reports.AddLast(report);

            // Add to pending queue if the report's status is "Pending".
            if (report.Status == "Pending")
            {
                pendingQueue.Enqueue(report);
            }

            // --- Manage Multi-Level Dictionary (Province → Category) ---
            // 1. Check/create the Province level dictionary entry.
            if (!reportsByProvinceAndCategory.ContainsKey(report.Province))
            {
                reportsByProvinceAndCategory[report.Province] = new Dictionary<string, LinkedList<Report>>();
            }

            // 2. Check/create the Category level LinkedList entry within the Province dictionary.
            if (!reportsByProvinceAndCategory[report.Province].ContainsKey(report.Category))
            {
                reportsByProvinceAndCategory[report.Province][report.Category] = new LinkedList<Report>();
            }

            // 3. Add the report to the specific Province/Category list.
            reportsByProvinceAndCategory[report.Province][report.Category].AddLast(report);

            // --- Manage Advanced Data Structures ---
            // Add the report to the Binary Search Tree (BST) for location-based sorting.
            advancedService.AddReportToBst(report);

            // Note: To make the Min-Heap work correctly, you should ensure ReportId and CreatedAt are set.
            // This ensures the report has the necessary priority key (CreatedAt) for the heap.
            report.ReportId = Guid.NewGuid();
            report.CreatedAt = DateTime.Now;

            // Add the report to the Priority Queue (Min-Heap, prioritized by CreatedAt).
            advancedService.EnqueueReportByPriority(report);
        }




        // Public property to expose the complex multi-level dictionary for external access.
        public static Dictionary<string, Dictionary<string, LinkedList<Report>>> ReportsByProvinceAndCategoryDict
        {
            get { return reportsByProvinceAndCategory; }
        }


        // Public static method to retrieve all reports submitted by a specific user ID.
        public static List<Report> GetReportsByUserId(string userId)
        {
            // Efficient lookup due to the use of a Dictionary (O(1) average time complexity).
            if (reportsByUserId.ContainsKey(userId))
            {
                return reportsByUserId[userId];
            }
            // Return an empty list if no reports are found for the given user ID.
            return new List<Report>();
        }


        // Public static method to populate the data structures with initial/sample data.
        public static void SeedReports()
        {
            // Prevent re-seeding if the main reports list already contains data.
            if (reports.Count > 0) return;


            // Define a list of initial Report objects.
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

            // Iterate through the sample reports and add them using the main AddReport method,
            // ensuring they are correctly placed in all data structures.
            foreach (var r in seededReports)
            {
                AddReport(r);
            }
        }


        // Public method to peek at the highest priority report without removing it.
        // Delegates the call to the AdvancedDataStructureService's Min-Heap implementation.
        public static Report PeekHighestPriorityReport()
        {
            return advancedService.PeekHighestPriorityReport();
        }


        // Public method to retrieve all reports sorted alphabetically by Location.
        // Delegates the call to the AdvancedDataStructureService's BST In-Order Traversal.
        public static List<Report> GetReportsSortedByLocation()
        {
            return advancedService.GetReportsSortedByLocation();
        }


        // Public method to get a ranking of provinces based on the density of active reports.
        // Delegates the data processing to the AdvancedDataStructureService.
        public static Dictionary<string, int> GetLocationDensityRanking()
        {
            return advancedService.GetLocationDensityRanking();
        }


        // Public method to identify and return reports that are considered duplicates based on criteria.
        public static List<Report> GetDuplicateReports()
        {
            var duplicateReports = new List<Report>();

            // Convert the LinkedList to a List for indexed access in the nested loops.
            var reportList = reports.ToList();

            // Use a nested loop to compare every report (r1) with every subsequent report (r2).
            for (int i = 0; i < reportList.Count; i++)
            {
                for (int j = i + 1; j < reportList.Count; j++)
                {
                    var r1 = reportList[i];
                    var r2 = reportList[j];

                    // Criteria for considering reports as duplicates:
                    // 1. Same Location (case-insensitive).
                    // 2. Same Category (case-insensitive).
                    // 3. Submitted within a 12-hour window of each other.
                    if (r1.Location.Equals(r2.Location, StringComparison.OrdinalIgnoreCase) &&
                        r1.Category.Equals(r2.Category, StringComparison.OrdinalIgnoreCase) &&
                        Math.Abs((r1.CreatedAt - r2.CreatedAt).TotalHours) <= 12)
                    {
                        // Add r1 and r2 to the duplicate list if they are not already present.
                        if (!duplicateReports.Contains(r1))
                            duplicateReports.Add(r1);
                        if (!duplicateReports.Contains(r2))
                            duplicateReports.Add(r2);
                    }
                }
            }

            return duplicateReports;
        }


        // Public method to retrieve all reports from the Min-Heap sorted by priority (CreatedAt ascending).
        // This process temporarily empties the heap and then rebuilds it to preserve the data structure.
        public static List<Report> GetReportsSortedByPriority()
        {
            List<Report> sortedList = new List<Report>();

            // 1. Store the reports needed for REBUILDING THE HEAP after the sort.
            // We get a copy of the heap's underlying list *before* we start dequeuing.
            List<Report> reportsToRebuild = advancedService.GetAllReportsFromHeap();

            // 2. Dequeue all reports into the sorted list (O(n log n) total time).
            // Each Dequeue operation extracts the highest priority element and re-heapifies. This empties the heap.
            while (true)
            {
                Report nextReport = advancedService.DequeueHighestPriorityReport();

                // Break the loop when the heap is empty.
                if (nextReport == null)
                    break;

                sortedList.Add(nextReport);
            }

            // 3. Rebuild the heap by re-enqueuing all reports. (O(n log n) total time).
            // This restores the priority queue structure for future operations.
            foreach (var report in reportsToRebuild)
            {
                advancedService.EnqueueReportByPriority(report);
            }

            // Return the list of reports sorted by priority (earliest CreatedAt first).
            return sortedList;
        }

    }
}