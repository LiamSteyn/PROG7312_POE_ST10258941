using IssueReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IssueReportSystem.Services
{
    /// <summary>
    /// Service to manage reports using advanced data structures (Trees and Heaps).
    /// </summary>
    internal class AdvancedDataStructureService
    {
        // --- 1. Binary Search Tree (BST) for efficient organization and retrieval (Tree Requirement) ---

        // Simple BST Node definition
        private class BstNode
        {
            public Report Report { get; set; }
            public BstNode Left { get; set; }
            public BstNode Right { get; set; }

            // Reports are sorted by their Location string
            public BstNode(Report report)
            {
                Report = report;
            }
        }

        // The root of the BST, organizing reports by Location for quick search
        private BstNode _reportBstRoot = null;

        /// <summary>
        /// Inserts a report into the BST, ordered by Report Location.
        /// </summary>
        public void AddReportToBst(Report report)
        {
            _reportBstRoot = InsertNode(_reportBstRoot, report);
        }

        private BstNode InsertNode(BstNode current, Report report)
        {
            if (current == null)
            {
                // Base case: Create a new node
                return new BstNode(report);
            }

            // Compare reports based on their Location string for ordering
            int comparison = string.Compare(report.Location, current.Report.Location, StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                // Current report's location comes before the current node's location
                current.Left = InsertNode(current.Left, report);
            }
            else if (comparison > 0)
            {
                // Current report's location comes after the current node's location
                current.Right = InsertNode(current.Right, report);
            }
            // If comparison is 0 (same location), we simply discard the new one (or handle duplicates as needed)

            return current;
        }

        /// <summary>
        /// Retrieves reports in alphabetical order of their Location (In-order Traversal).
        /// </summary>
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

        // --- 2. Min-Heap for priority/urgency management (Heaps Requirement) ---

        // Using List<T> to represent the underlying complete binary tree structure of the heap
        // The heap will order reports by oldest 'CreatedAt' date (Min-Heap: oldest = highest priority)
        private List<Report> _priorityMinHeap = new List<Report>();

        /// <summary>
        /// Inserts a report into the Min-Heap, prioritizing older reports (smaller CreatedAt time).
        /// Time Complexity: O(log n)
        /// </summary>
        public void EnqueueReportByPriority(Report report)
        {
            _priorityMinHeap.Add(report); // Add to the end
            HeapifyUp(_priorityMinHeap.Count - 1); // Restore the heap property
        }

        /// <summary>
        /// Retrieves and removes the highest priority report (the oldest report).
        /// Time Complexity: O(log n)
        /// </summary>
        public Report DequeueHighestPriorityReport()
        {
            if (_priorityMinHeap.Count == 0) return null;

            // The root is the highest priority element
            Report highPriority = _priorityMinHeap[0];

            // Replace root with the last element
            int lastIndex = _priorityMinHeap.Count - 1;
            _priorityMinHeap[0] = _priorityMinHeap[lastIndex];
            _priorityMinHeap.RemoveAt(lastIndex);

            // Restore the heap property
            if (_priorityMinHeap.Count > 0)
            {
                HeapifyDown(0);
            }

            return highPriority;
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            // The comparison: _priorityMinHeap[index] < _priorityMinHeap[parentIndex]
            // We want the **smaller** 'CreatedAt' (older report) to bubble up.
            while (index > 0 && _priorityMinHeap[index].CreatedAt < _priorityMinHeap[parentIndex].CreatedAt)
            {
                // Swap the current element with its parent
                (_priorityMinHeap[index], _priorityMinHeap[parentIndex]) = (_priorityMinHeap[parentIndex], _priorityMinHeap[index]);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index; // The index of the smallest (highest priority) element

            // Compare with left child
            if (leftChild < _priorityMinHeap.Count && _priorityMinHeap[leftChild].CreatedAt < _priorityMinHeap[smallest].CreatedAt)
            {
                smallest = leftChild;
            }

            // Compare with right child
            if (rightChild < _priorityMinHeap.Count && _priorityMinHeap[rightChild].CreatedAt < _priorityMinHeap[smallest].CreatedAt)
            {
                smallest = rightChild;
            }

            // If the smallest is not the current node, swap and continue
            if (smallest != index)
            {
                (_priorityMinHeap[index], _priorityMinHeap[smallest]) = (_priorityMinHeap[smallest], _priorityMinHeap[index]);
                HeapifyDown(smallest);
            }
        }
    }
}