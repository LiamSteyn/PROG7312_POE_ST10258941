using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReportSystem.Models
{
    /// <summary>
    /// Represents an event in the system.
    /// Used for local events, workshops, charity drives, and community activities.
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Unique identifier for the event.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the event (e.g., "Community Cleanup").
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Category of the event (e.g., "Environment", "Education", "Health").
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Location where the event will take place.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Detailed description of the event, including purpose, activities, and instructions.
        /// </summary>
        public string Description { get; set; }
    }
}
