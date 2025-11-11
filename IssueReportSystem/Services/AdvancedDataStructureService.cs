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

        public Report DequeueHighestPriorityReport()
        {
            if (_priorityMinHeap.Count == 0) return null;

            Report highPriority = _priorityMinHeap[0];
            int lastIndex = _priorityMinHeap.Count - 1;
            _priorityMinHeap[0] = _priorityMinHeap[lastIndex];
            _priorityMinHeap.RemoveAt(lastIndex);

            if (_priorityMinHeap.Count > 0)
            {
                HeapifyDown(0);
            }

            return highPriority;
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

    }
}