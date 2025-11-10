using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReportSystem.Models
{
    /// <summary>
    /// Represents a single issue report submitted by a user.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Gets or sets a unique identifier for the report.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the location/address where the issue was observed.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the issue.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category/type of issue (e.g., Plumbing, Electrical).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the province where the issue occurred.
        /// Useful for sorting or filtering reports by location.
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Gets or sets a list of file paths for attachments (images, documents) related to the issue.
        /// Initialized to an empty list to prevent null reference errors.
        /// </summary>
        public List<string> AttachmentPaths { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the date and time when the report was created.
        /// Defaults to the current system date and time.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the current status of the report (e.g., Pending, Resolved).
        /// Defaults to "Pending" when a new report is created.
        /// </summary>
        public string Status { get; set; } = "Pending";

    }
}
