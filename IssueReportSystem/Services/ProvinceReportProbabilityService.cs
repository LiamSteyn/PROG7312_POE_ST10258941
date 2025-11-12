using IssueReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IssueReportSystem.Services
{
    // Service that uses Graph data structure to predict future report probabilities
    public class ProvinceReportProbabilityService
    {
        // Graph node representing a province with its report statistics
        private class ProvinceNode
        {
            public string ProvinceName { get; set; }
            public int TotalReports { get; set; }
            public int RecentReports { get; set; } // Last 24 hours
            public Dictionary<string, int> CategoryCounts { get; set; }
            public List<DateTime> ReportTimestamps { get; set; }

            public ProvinceNode(string name)
            {
                ProvinceName = name;
                TotalReports = 0;
                RecentReports = 0;
                CategoryCounts = new Dictionary<string, int>();
                ReportTimestamps = new List<DateTime>();
            }
        }

        // Graph edge representing relationship between provinces
        private class ProvinceEdge
        {
            public string FromProvince { get; set; }
            public string ToProvince { get; set; }
            public double SimilarityScore { get; set; } // How similar the report patterns are

            public ProvinceEdge(string from, string to, double score)
            {
                FromProvince = from;
                ToProvince = to;
                SimilarityScore = score;
            }
        }

        // Adjacency list representation of the graph
        private Dictionary<string, ProvinceNode> _provinceNodes;
        private Dictionary<string, List<ProvinceEdge>> _adjacencyList;

        public ProvinceReportProbabilityService()
        {
            _provinceNodes = new Dictionary<string, ProvinceNode>();
            _adjacencyList = new Dictionary<string, List<ProvinceEdge>>();
        }

        // Build the graph from all reports in the system
        public void BuildGraphFromReports(LinkedList<Report> allReports)
        {
            // Clear existing graph
            _provinceNodes.Clear();
            _adjacencyList.Clear();

            // Step 1: Build nodes with statistics
            foreach (var report in allReports)
            {
                if (!_provinceNodes.ContainsKey(report.Province))
                {
                    _provinceNodes[report.Province] = new ProvinceNode(report.Province);
                    _adjacencyList[report.Province] = new List<ProvinceEdge>();
                }

                var node = _provinceNodes[report.Province];
                node.TotalReports++;
                node.ReportTimestamps.Add(report.CreatedAt);

                // Count recent reports (within last 24 hours)
                if ((DateTime.Now - report.CreatedAt).TotalHours <= 24)
                {
                    node.RecentReports++;
                }

                // Track category distribution
                if (!node.CategoryCounts.ContainsKey(report.Category))
                {
                    node.CategoryCounts[report.Category] = 0;
                }
                node.CategoryCounts[report.Category]++;
            }

            // Step 2: Build edges based on similarity between provinces
            var provinces = _provinceNodes.Keys.ToList();
            for (int i = 0; i < provinces.Count; i++)
            {
                for (int j = i + 1; j < provinces.Count; j++)
                {
                    string province1 = provinces[i];
                    string province2 = provinces[j];

                    double similarity = CalculateSimilarity(
                        _provinceNodes[province1],
                        _provinceNodes[province2]
                    );

                    // Only create edges if similarity is significant (> 0.3)
                    if (similarity > 0.3)
                    {
                        _adjacencyList[province1].Add(new ProvinceEdge(province1, province2, similarity));
                        _adjacencyList[province2].Add(new ProvinceEdge(province2, province1, similarity));
                    }
                }
            }
        }

        // Calculate similarity between two provinces based on report patterns
        private double CalculateSimilarity(ProvinceNode node1, ProvinceNode node2)
        {
            double categorySimilarity = CalculateCategorySimilarity(node1, node2);
            double trendSimilarity = CalculateTrendSimilarity(node1, node2);

            // Weighted combination of different similarity metrics
            return (0.6 * categorySimilarity) + (0.4 * trendSimilarity);
        }

        // Calculate how similar the category distributions are
        private double CalculateCategorySimilarity(ProvinceNode node1, ProvinceNode node2)
        {
            var allCategories = node1.CategoryCounts.Keys
                .Union(node2.CategoryCounts.Keys)
                .ToList();

            if (allCategories.Count == 0) return 0;

            double dotProduct = 0;
            double magnitude1 = 0;
            double magnitude2 = 0;

            foreach (var category in allCategories)
            {
                int count1 = node1.CategoryCounts.ContainsKey(category) ? node1.CategoryCounts[category] : 0;
                int count2 = node2.CategoryCounts.ContainsKey(category) ? node2.CategoryCounts[category] : 0;

                dotProduct += count1 * count2;
                magnitude1 += count1 * count1;
                magnitude2 += count2 * count2;
            }

            // Cosine similarity
            if (magnitude1 == 0 || magnitude2 == 0) return 0;
            return dotProduct / (Math.Sqrt(magnitude1) * Math.Sqrt(magnitude2));
        }

        // Calculate trend similarity based on recent activity
        private double CalculateTrendSimilarity(ProvinceNode node1, ProvinceNode node2)
        {
            if (node1.TotalReports == 0 || node2.TotalReports == 0) return 0;

            double recentRatio1 = (double)node1.RecentReports / node1.TotalReports;
            double recentRatio2 = (double)node2.RecentReports / node2.TotalReports;

            // Similarity based on how close the recent activity ratios are
            return 1.0 - Math.Abs(recentRatio1 - recentRatio2);
        }

        // Main method: Calculate probability of future reports for each province
        public Dictionary<string, double> CalculateReportProbabilities()
        {
            var probabilities = new Dictionary<string, double>();

            foreach (var province in _provinceNodes.Keys)
            {
                double probability = CalculateProvinceProbability(province);
                probabilities[province] = probability;
            }

            return probabilities;
        }

        // Calculate probability for a single province using graph traversal
        private double CalculateProvinceProbability(string province)
        {
            var node = _provinceNodes[province];

            // Factor 1: Recent activity (40% weight)
            double recentActivityScore = 0;
            if (node.TotalReports > 0)
            {
                recentActivityScore = (double)node.RecentReports / Math.Max(1, node.TotalReports);
            }

            // Factor 2: Historical volume (20% weight)
            double volumeScore = Math.Min(1.0, node.TotalReports / 10.0);

            // Factor 3: Report velocity (20% weight)
            double velocityScore = CalculateReportVelocity(node);

            // Factor 4: Influence from neighboring provinces (20% weight)
            double neighborInfluence = CalculateNeighborInfluence(province);

            // Weighted combination
            double probability =
                (0.40 * recentActivityScore) +
                (0.20 * volumeScore) +
                (0.20 * velocityScore) +
                (0.20 * neighborInfluence);

            // Normalize to 0-100% range
            return Math.Round(probability * 100, 2);
        }

        // Calculate how fast reports are being submitted (acceleration)
        private double CalculateReportVelocity(ProvinceNode node)
        {
            if (node.ReportTimestamps.Count < 2) return 0;

            var sortedTimestamps = node.ReportTimestamps.OrderBy(t => t).ToList();

            // Calculate average time between reports (in hours)
            double totalGap = 0;
            for (int i = 1; i < sortedTimestamps.Count; i++)
            {
                totalGap += (sortedTimestamps[i] - sortedTimestamps[i - 1]).TotalHours;
            }
            double avgGap = totalGap / (sortedTimestamps.Count - 1);

            // Check recent trend (last 3 reports vs previous 3)
            if (sortedTimestamps.Count >= 6)
            {
                var recent = sortedTimestamps.Skip(sortedTimestamps.Count - 3).ToList();
                var previous = sortedTimestamps.Skip(sortedTimestamps.Count - 6).Take(3).ToList();

                double recentGap = (recent[2] - recent[0]).TotalHours / 2;
                double previousGap = (previous[2] - previous[0]).TotalHours / 2;

                // If recent gap is smaller, velocity is increasing
                if (previousGap > 0)
                {
                    return Math.Min(1.0, previousGap / Math.Max(1, recentGap) - 1);
                }
            }

            // Fallback: Higher velocity if reports are frequent
            return Math.Min(1.0, 24.0 / Math.Max(1, avgGap));
        }

        // Calculate influence from connected provinces (graph traversal)
        private double CalculateNeighborInfluence(string province)
        {
            if (!_adjacencyList.ContainsKey(province) || _adjacencyList[province].Count == 0)
            {
                return 0;
            }

            double totalInfluence = 0;
            double totalWeight = 0;

            // Traverse edges to neighboring provinces
            foreach (var edge in _adjacencyList[province])
            {
                var neighborNode = _provinceNodes[edge.ToProvince];
                double neighborActivity = 0;

                if (neighborNode.TotalReports > 0)
                {
                    neighborActivity = (double)neighborNode.RecentReports / neighborNode.TotalReports;
                }

                // Weight the influence by edge similarity
                totalInfluence += neighborActivity * edge.SimilarityScore;
                totalWeight += edge.SimilarityScore;
            }

            return totalWeight > 0 ? totalInfluence / totalWeight : 0;
        }

        // Get detailed analysis for display
        public Dictionary<string, ProvinceAnalysis> GetDetailedAnalysis()
        {
            var analysis = new Dictionary<string, ProvinceAnalysis>();

            foreach (var province in _provinceNodes.Keys)
            {
                var node = _provinceNodes[province];
                var neighbors = _adjacencyList[province]
                    .OrderByDescending(e => e.SimilarityScore)
                    .Take(3)
                    .Select(e => $"{e.ToProvince} ({e.SimilarityScore:P0})")
                    .ToList();

                analysis[province] = new ProvinceAnalysis
                {
                    Province = province,
                    TotalReports = node.TotalReports,
                    RecentReports = node.RecentReports,
                    TopCategories = node.CategoryCounts
                        .OrderByDescending(kv => kv.Value)
                        .Take(3)
                        .ToDictionary(kv => kv.Key, kv => kv.Value),
                    SimilarProvinces = neighbors,
                    Probability = CalculateProvinceProbability(province)
                };
            }

            return analysis;
        }

        // Data class for detailed province analysis
        public class ProvinceAnalysis
        {
            public string Province { get; set; }
            public int TotalReports { get; set; }
            public int RecentReports { get; set; }
            public Dictionary<string, int> TopCategories { get; set; }
            public List<string> SimilarProvinces { get; set; }
            public double Probability { get; set; }
        }
    }
}