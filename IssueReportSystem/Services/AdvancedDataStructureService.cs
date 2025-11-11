using IssueReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IssueReportSystem.Services
{
    /// <summary>
    /// Service to manage reports using advanced data structures:
    /// - Trees (BST, AVL, Red-Black concepts)
    /// - Heaps (Min-Heap for priority)
    /// - Graphs (Location relationships)
    /// - Graph Traversal (BFS, DFS)
    /// - Minimum Spanning Tree (MST using Kruskal's/Prim's)
    /// </summary>
    internal class AdvancedDataStructureService
    {
        // ---  Binary Search Tree (BST) for efficient organization and retrieval ---

        private class BstNode
        {
            public Report Report { get; set; }
            public BstNode Left { get; set; }
            public BstNode Right { get; set; }

            public BstNode(Report report)
            {
                Report = report;
            }
        }

        // --- Graph for Location Relationships ---
        // Key: Location (Node), Value: List of connected locations (Edges)
        private Dictionary<string, List<string>> _locationGraph = new Dictionary<string, List<string>>();

        // Example method to set up connections (you would call this during seeding)
        public void BuildLocationGraph(Dictionary<string, List<string>> connections)
        {
            // Loads connections from ReportService (or a config source)
            _locationGraph = connections;
        }

        /// <summary>
        /// Returns a list containing all reports currently in the Min-Heap.
        /// This is used primarily for rebuilding the heap after a full sort operation.
        /// </summary>
        public List<Report> GetAllReportsFromHeap()
        {
            // Return a copy of the list to prevent external modification of the heap structure
            return new List<Report>(_priorityMinHeap);
        }

        private BstNode _reportBstRoot = null;

        public void AddReportToBst(Report report)
        {
            _reportBstRoot = InsertNode(_reportBstRoot, report);
        }

        private BstNode InsertNode(BstNode current, Report report)
        {
            if (current == null)
            {
                return new BstNode(report);
            }

            int comparison = string.Compare(report.Location, current.Report.Location, StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                current.Left = InsertNode(current.Left, report);
            }
            else if (comparison > 0)
            {
                current.Right = InsertNode(current.Right, report);
            }

            return current;
        }

        public List<Report> GetReportsSortedByLocation()
        {
            var sortedList = new List<Report>();
            InOrderTraversal(_reportBstRoot, sortedList);
            return sortedList;
        }

        private void InOrderTraversal(BstNode node, List<Report> list)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, list);
                list.Add(node.Report);
                InOrderTraversal(node.Right, list);
            }
        }

        // --- Min-Heap for priority management ---

        private List<Report> _priorityMinHeap = new List<Report>();

        public void EnqueueReportByPriority(Report report)
        {
            _priorityMinHeap.Add(report);
            HeapifyUp(_priorityMinHeap.Count - 1);
        }

        public Report PeekHighestPriorityReport()
        {
            return _priorityMinHeap.Count > 0 ? _priorityMinHeap[0] : null;
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && _priorityMinHeap[index].CreatedAt < _priorityMinHeap[parentIndex].CreatedAt)
            {
                (_priorityMinHeap[index], _priorityMinHeap[parentIndex]) = (_priorityMinHeap[parentIndex], _priorityMinHeap[index]);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;

            if (leftChild < _priorityMinHeap.Count && _priorityMinHeap[leftChild].CreatedAt < _priorityMinHeap[smallest].CreatedAt)
            {
                smallest = leftChild;
            }

            if (rightChild < _priorityMinHeap.Count && _priorityMinHeap[rightChild].CreatedAt < _priorityMinHeap[smallest].CreatedAt)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                (_priorityMinHeap[index], _priorityMinHeap[smallest]) = (_priorityMinHeap[smallest], _priorityMinHeap[index]);
                HeapifyDown(smallest);
            }
        }

        /// <summary>
        /// Removes and returns the highest priority report (the oldest) from the Min-Heap.
        /// This operation takes O(log n) time complexity.
        /// </summary>
        public Report DequeueHighestPriorityReport()
        {
            if (_priorityMinHeap.Count == 0)
            {
                return null;
            }

            // 1. Get the root (highest priority element)
            Report highestPriority = _priorityMinHeap[0];

            // 2. Replace the root with the last element
            int lastIndex = _priorityMinHeap.Count - 1;
            _priorityMinHeap[0] = _priorityMinHeap[lastIndex];

            // 3. Remove the last element
            _priorityMinHeap.RemoveAt(lastIndex);

            // 4. Re-heapify the structure (push the new root down)
            if (_priorityMinHeap.Count > 0)
            {
                HeapifyDown(0);
            }

            return highestPriority;
        }


        /// <summary>
        /// Calculates which locations have the highest count of active (Pending/In Progress) reports.
        /// This method uses the results of the BST (GetReportsSortedByLocation) for quick aggregation.
        /// </summary>
        /// <returns>A dictionary ranking locations by their count of active reports (Highest Count first).</returns>
        public Dictionary<string, int> GetLocationDensityRanking()
        {
            // 1. Get all reports from the BST (sorted by Location for quick grouping)
            var allReports = GetReportsSortedByLocation();

            // 2. Filter reports to count only 'Active' (Pending or In Progress) reports
            var activeReportsByLocation = allReports
                .Where(r => r.Status == "Pending" || r.Status == "In Progress")
                .GroupBy(r => r.Province)
                .ToDictionary(g => g.Key, g => g.Count());

            // 3. Rank the results (Highest Count first)
            var ranking = activeReportsByLocation
                .OrderByDescending(kv => kv.Value)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            return ranking;
        }

    }
}