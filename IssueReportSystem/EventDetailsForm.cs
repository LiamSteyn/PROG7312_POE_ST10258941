using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueReportSystem
{
    public partial class EventDetailsForm : Form
    {
        /// <summary>
        /// Constructor initializes the EventDetailsForm with event details.
        /// </summary>
        /// <param name="title">Event title</param>
        /// <param name="category">Event category</param>
        /// <param name="location">Event location</param>
        /// <param name="date">Event date</param>
        /// <param name="description">Event description</param>
        public EventDetailsForm(string title, string category, string location, DateTime date, string description)
        {
            InitializeComponent();

            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set labels and description textbox with event details
            lblTitle.Text = title;
            lblCategory.Text = $"{category}";
            lblLocation.Text = $"{location}";
            lblDate.Text = $"{date:MMM dd, yyyy}";
            txtDescription.Text = description;
        }

        /// <summary>
        /// Form load event for optional UI styling.
        /// Sets the description textbox to read-only and white background.
        /// </summary>
        private void EventDetailsForm_Load(object sender, EventArgs e)
        {
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = System.Drawing.Color.White;
        }

        private void label5_Click(object sender, EventArgs e){}

        /// <summary>
        /// Close button click event handler.
        /// Closes the EventDetailsForm.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e){}

        /// <summary>
        /// Additional load event to set form properties.
        /// Disables resizing and maximization for fixed dialog appearance.
        /// </summary>
        private void EventDetailsForm_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Fix form size
            this.MaximizeBox = false;                           // Hide maximize button
            this.MinimizeBox = true;                            // Keep minimize button enabled
        }
    }
}
