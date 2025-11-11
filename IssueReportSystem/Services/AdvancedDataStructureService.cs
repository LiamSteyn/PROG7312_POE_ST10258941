// The 'using' statements bring in necessary namespaces and types.
using IssueReportSystem.Models; // Imports the data models, specifically the 'Report' class.
using System;                   // Provides fundamental classes and base types, e.g., StringComparison.
using System.Collections.Generic; // Provides interfaces and classes that define generic collections, e.g., List<T>, Dictionary<TKey, TValue>.
using System.Linq;                // Provides language-integrated query (LINQ) features for filtering, sorting, and grouping.

// Define the namespace for the service classes in the Issue Report System.
namespace IssueReportSystem.Services
{

    // Internal class encapsulating advanced data structures (BST and Min Heap)
    // for managing 'Report' objects efficiently.
    internal class AdvancedDataStructureService
    {
        // ---  Binary Search Tree (BST) for efficient organization and retrieval ---

        // Private nested class representing a node in the Binary Search Tree (BST).
        private class BstNode
        {
            // Data payload: The Report object stored in this node.
            public Report Report { get; set; }
            // Reference to the left child node (Reports with a smaller sorting key).
            public BstNode Left { get; set; }
            // Reference to the right child node (Reports with a larger sorting key).
            public BstNode Right { get; set; }

            // Constructor to initialize a new node with a Report.
            public BstNode(Report report)
            {
                Report = report;
            }
        }



        // Public method to retrieve all reports currently in the Min Heap.
        public List<Report> GetAllReportsFromHeap()
        {
            // Return a copy of the list to prevent external modification of the heap structure.
            return new List<Report>(_priorityMinHeap);
        }

        // Private field to hold the root node of the Binary Search Tree.
        private BstNode _reportBstRoot = null;

        // Public method to add a new Report to the BST.
        public void AddReportToBst(Report report)
        {
            // Starts the recursive insertion process from the root, updating the root reference if needed (for the initial insertion).
            _reportBstRoot = InsertNode(_reportBstRoot, report);
        }

        // Private recursive method to insert a Report into the BST, ordered by Report.Location.
        private BstNode InsertNode(BstNode current, Report report)
        {
            // Base case: If the current node is null, we've found the insertion point.
            if (current == null)
            {
                // Create and return the new node.
                return new BstNode(report);
            }

            // Compare the new report's Location with the current node's report's Location (case-insensitive, culture-independent).
            int comparison = string.Compare(report.Location, current.Report.Location, StringComparison.OrdinalIgnoreCase);

            // If the new report's Location is lexicographically less than the current node's...
            if (comparison < 0)
            {
                // Recurse down the left subtree.
                current.Left = InsertNode(current.Left, report);
            }
            // If the new report's Location is lexicographically greater than the current node's...
            else if (comparison > 0)
            {
                // Recurse down the right subtree.
                current.Right = InsertNode(current.Right, report);
            }
            // Note: If comparison == 0 (duplicate Location), the node is not inserted, preserving the structure.

            // Return the current node (its children may have been updated).
            return current;
        }

        // Public method to retrieve all Reports from the BST, sorted by Location.
        public List<Report> GetReportsSortedByLocation()
        {
            var sortedList = new List<Report>();
            // Perform an In-Order Traversal on the BST, which visits nodes in ascending order of the key (Location).
            InOrderTraversal(_reportBstRoot, sortedList);
            return sortedList;
        }

        // Private recursive method implementing the In-Order Traversal algorithm.
        // Traversal order: Left -> Root -> Right.
        private void InOrderTraversal(BstNode node, List<Report> list)
        {
            // Check if the current node is valid.
            if (node != null)
            {
                // 1. Traverse the left subtree.
                InOrderTraversal(node.Left, list);
                // 2. Visit the current node (add the Report to the list).
                list.Add(node.Report);
                // 3. Traverse the right subtree.
                InOrderTraversal(node.Right, list);
            }
        }


        // --- Priority Queue implemented as a Min-Heap ---

        // Private field to hold the Min Heap structure, using a List to represent a complete binary tree.
        // The priority is based on the Report.CreatedAt property (earlier date/time means higher priority, hence a Min Heap).
        private List<Report> _priorityMinHeap = new List<Report>();

        // Public method to add a Report to the priority queue (Min Heap).
        public void EnqueueReportByPriority(Report report)
        {
            // Add the new element to the end of the list (the next available position in the heap).
            _priorityMinHeap.Add(report);
            // Restore the heap property by bubbling the new element up.
            HeapifyUp(_priorityMinHeap.Count - 1);
        }

        // Public method to look at the highest priority Report without removing it.
        public Report PeekHighestPriorityReport()
        {
            // The highest priority element is always at the root (index 0). Returns null if the heap is empty.
            return _priorityMinHeap.Count > 0 ? _priorityMinHeap[0] : null;
        }

        // Private method to restore the Min Heap property by moving an element up.
        private void HeapifyUp(int index)
        {
            // Calculate the parent index: (i - 1) / 2 for 0-based indexing.
            int parentIndex = (index - 1) / 2;

            // Loop while the current node is not the root and its 'CreatedAt' date is earlier (higher priority) than its parent's.
            while (index > 0 && _priorityMinHeap[index].CreatedAt < _priorityMinHeap[parentIndex].CreatedAt)
            {
                // Swap the current node with its parent (using C# 7+ tuple deconstruction/assignment for concise swap).
                (_priorityMinHeap[index], _priorityMinHeap[parentIndex]) = (_priorityMinHeap[parentIndex], _priorityMinHeap[index]);
                // Move up to the parent's position.
                index = parentIndex;
                // Recalculate the new parent's index.
                parentIndex = (index - 1) / 2;
            }
        }

        // Private method to restore the Min Heap property by moving an element down.
        private void HeapifyDown(int index)
        {
            // Calculate indices of the left and right children.
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            // Assume the current node is the smallest initially.
            int smallest = index;

            // Check if the left child exists and has a higher priority (earlier CreatedAt date) than the current smallest.
            if (leftChild < _priorityMinHeap.Count && _priorityMinHeap[leftChild].CreatedAt < _priorityMinHeap[smallest].CreatedAt)
            {
                smallest = leftChild;
            }

            // Check if the right child exists and has a higher priority (earlier CreatedAt date) than the current smallest.
            if (rightChild < _priorityMinHeap.Count && _priorityMinHeap[rightChild].CreatedAt < _priorityMinHeap[smallest].CreatedAt)
            {
                smallest = rightChild;
            }

            // If the smallest element is not the current node (a swap is needed)...
            if (smallest != index)
            {
                // Swap the current node with the smallest child.
                (_priorityMinHeap[index], _priorityMinHeap[smallest]) = (_priorityMinHeap[smallest], _priorityMinHeap[index]);
                // Recursively call HeapifyDown from the new position of the swapped element.
                HeapifyDown(smallest);
            }
        }


        // Public method to remove and return the highest priority Report (Min Heap extract_min operation).
        public Report DequeueHighestPriorityReport()
        {
            // Handle the case where the heap is empty.
            if (_priorityMinHeap.Count == 0)
            {
                return null;
            }

            // 1. Get the root (highest priority element).
            Report highestPriority = _priorityMinHeap[0];

            // 2. Replace the root (index 0) with the last element of the list.
            int lastIndex = _priorityMinHeap.Count - 1;
            _priorityMinHeap[0] = _priorityMinHeap[lastIndex];

            // 3. Remove the last element (which is now a duplicate of the new root).
            _priorityMinHeap.RemoveAt(lastIndex);

            // 4. Re-heapify the structure (push the new root down to its correct position).
            if (_priorityMinHeap.Count > 0)
            {
                HeapifyDown(0);
            }

            // Return the element that was removed (the highest priority report).
            return highestPriority;
        }



        // --- Data Analysis / Utility Method ---

        // Public method to calculate and return a ranking of provinces based on the count of active reports.
        // Returns a Dictionary<string, int> where the key is the Province name and the value is the count.
        public Dictionary<string, int> GetLocationDensityRanking()
        {

            // Step 1: Get all reports from the BST (sorted by Location, though sorting isn't strictly necessary for this operation).
            var allReports = GetReportsSortedByLocation();


            // Step 2: Filter the reports to include only those with active statuses ("Pending" or "In Progress").
            // Then, group the filtered reports by the 'Province' property.
            // Finally, convert the grouping into a Dictionary where Key = Province, Value = Count of reports in that Province.
            var activeReportsByLocation = allReports
            .Where(r => r.Status == "Pending" || r.Status == "In Progress")
            .GroupBy(r => r.Province)
            .ToDictionary(g => g.Key, g => g.Count());


            // Step 3: Order the dictionary entries (KeyValuePair) by the Count (Value) in descending order (highest count first).
            // Convert the sorted sequence back into a Dictionary.
            var ranking = activeReportsByLocation
            .OrderByDescending(kv => kv.Value)
            .ToDictionary(kv => kv.Key, kv => kv.Value);

            // Return the final ranked list of provinces and their active report counts.
            return ranking;
        }

    }
}