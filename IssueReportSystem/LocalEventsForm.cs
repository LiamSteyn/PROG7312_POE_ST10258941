using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using IssueReportSystem.Models;

namespace IssueReportSystem
{
    public partial class LocalEventsForm : Form
    {
        // Stores all events in a sorted dictionary keyed by event ID
        private SortedDictionary<int, EventModel> allEvents = new SortedDictionary<int, EventModel>();

        // Stores the current suggested events based on user interactions
        private List<EventModel> suggestedEvents = new List<EventModel>();

        // Keeps a history of suggested events shown to the user
        private Queue<EventModel> suggestionHistory = new Queue<EventModel>();

        // Tracks how often each category is searched or interacted with
        private Dictionary<string, int> categorySearchFrequency = new Dictionary<string, int>();

        // Cached suggestion data (persisted across form instances)
        private static Dictionary<string, int> cachedCategorySearchFrequency = new Dictionary<string, int>();
        private static List<EventModel> cachedSuggestedEvents = new List<EventModel>();
        private static bool hasCachedSuggestions = false;

        private const int MaxHistory = 10; // Maximum number of recent suggested events to track

        // Constructor sets up the form and announcement label
        public LocalEventsForm()
        {
            InitializeComponent();

            // Position the announcements label outside the panel and vertically center it
            lblAnnouncements.Left = pnlAnnouncements.Width;
            lblAnnouncements.Top = (pnlAnnouncements.Height - lblAnnouncements.Height) / 2; // vertically center
            lblAnnouncements.Text = "Announcements: More updates coming soon!                    Youth Coding Workshop starting next week!                    Community Cleanup event this weekend!                      Try out our suggested events!";

            // Attach Load event handler
            Load += LocalEventsForm_Load;
        }

        // Form load event handler
        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            // Seed initial events into the SortedDictionary
            allEvents = new SortedDictionary<int, EventModel>
            {
                { 1, new EventModel { Id = 1, Title = "Community Cleanup", Category = "Environment", Location = "Gugulethu", Date = DateTime.Now.AddDays(2), Description = "Join us to clean up the local park and surrounding areas, making our community greener and more welcoming for everyone." } },
                { 2, new EventModel { Id = 2, Title = "Youth Coding Workshop", Category = "Education", Location = "Khayelitsha", Date = DateTime.Now.AddDays(5), Description = "A hands-on workshop designed for young learners to explore the basics of C# programming and develop problem-solving skills." } },
                { 3, new EventModel { Id = 3, Title = "Food Drive", Category = "Charity", Location = "Nyanga", Date = DateTime.Now.AddDays(1), Description = "Help collect and organize food donations for underprivileged families in our community, making a tangible difference in their lives." } },
                { 4, new EventModel { Id = 4, Title = "Town Hall Meeting", Category = "Community", Location = "Cape Town", Date = DateTime.Now.AddDays(3), Description = "Join local leaders and residents to discuss ongoing developments, community projects, and address any concerns or ideas you may have." } },
                { 5, new EventModel { Id = 5, Title = "Tree Planting", Category = "Environment", Location = "Langa", Date = DateTime.Now.AddDays(4), Description = "Participate in planting trees to support local green initiatives, improve air quality, and create shaded spaces for the community." } },
                { 6, new EventModel { Id = 6, Title = "Senior Health Check", Category = "Health", Location = "Philippi", Date = DateTime.Now.AddDays(6), Description = "Free health checkups for seniors, including blood pressure, glucose levels, and general wellness assessments to support a healthy lifestyle." } },
                { 7, new EventModel { Id = 7, Title = "Art Festival", Category = "Culture", Location = "Cape Town", Date = DateTime.Now.AddDays(10), Description = "Celebrate the vibrant local art scene with exhibitions, live performances, and workshops led by talented artists from the area." } },
                { 8, new EventModel { Id = 8, Title = "Beach Cleanup", Category = "Environment", Location = "Muizenberg", Date = DateTime.Now.AddDays(7), Description = "Join volunteers to remove litter and debris from the beach, protecting marine life and promoting environmental responsibility." } },
                { 9, new EventModel { Id = 9, Title = "Charity Fun Run", Category = "Charity", Location = "Claremont", Date = DateTime.Now.AddDays(8), Description = "Participate in a fun run to raise funds for local schools, encouraging fitness while supporting educational programs for children." } },
                { 10, new EventModel { Id = 10, Title = "Book Donation Drive", Category = "Education", Location = "Athlone", Date = DateTime.Now.AddDays(9), Description = "Donate new or gently used books to local libraries and schools to promote literacy and learning within the community." } },
                { 11, new EventModel { Id = 11, Title = "Cultural Dance Festival", Category = "Culture", Location = "Cape Town City Hall", Date = DateTime.Now.AddDays(11), Description = "Experience traditional and contemporary dance performances from various cultures, celebrating diversity and artistic expression." } },
                { 12, new EventModel { Id = 12, Title = "Health Awareness Walk", Category = "Health", Location = "Mitchells Plain", Date = DateTime.Now.AddDays(12), Description = "Join a community walk to raise awareness about healthy living, wellness practices, and preventive care for all ages." } },
                { 13, new EventModel { Id = 13, Title = "Recycling Workshop", Category = "Environment", Location = "Observatory", Date = DateTime.Now.AddDays(13), Description = "Learn practical ways to recycle and upcycle household waste, reducing environmental impact and promoting sustainable living." } },
                { 14, new EventModel { Id = 14, Title = "Blood Donation Drive", Category = "Health", Location = "Bellville", Date = DateTime.Now.AddDays(14), Description = "Donate blood to help save lives, support local hospitals, and contribute to a vital community health resource." } },
                { 15, new EventModel { Id = 15, Title = "Local Art Exhibition", Category = "Culture", Location = "Woodstock", Date = DateTime.Now.AddDays(15), Description = "Explore and support local artists as they showcase their latest artwork, from paintings to sculptures and interactive installations." } },
                { 16, new EventModel { Id = 16, Title = "Coding for Kids", Category = "Education", Location = "Mitchells Plain", Date = DateTime.Now.AddDays(16), Description = "A fun and interactive programming workshop where children learn coding fundamentals through games and creative projects." } },
                { 17, new EventModel { Id = 17, Title = "Neighborhood Watch Meeting", Category = "Community", Location = "Kraaifontein", Date = DateTime.Now.AddDays(17), Description = "Meet your neighbors, discuss safety concerns, and collaborate on strategies to improve security in your community." } },
                { 18, new EventModel { Id = 18, Title = "Animal Shelter Fundraiser", Category = "Charity", Location = "Durbanville", Date = DateTime.Now.AddDays(18), Description = "Support local animal shelters by contributing to fundraising efforts that provide food, medical care, and shelter for animals in need." } },
                { 19, new EventModel { Id = 19, Title = "Mental Health Awareness Talk", Category = "Health", Location = "Rondebosch", Date = DateTime.Now.AddDays(19), Description = "Engage in an open discussion about mental health, learn coping strategies, and discover available support resources." } },
                { 20, new EventModel { Id = 20, Title = "Heritage Day Celebration", Category = "Culture", Location = "Bo-Kaap", Date = DateTime.Now.AddDays(20), Description = "Celebrate South Africa’s rich and diverse heritage through food, music, traditional clothing, and cultural performances." } },
                { 21, new EventModel { Id = 21, Title = "Youth Leadership Seminar", Category = "Education", Location = "Mowbray", Date = DateTime.Now.AddDays(21), Description = "A seminar designed to inspire young people, develop leadership skills, and encourage active participation in community projects." } },
                { 22, new EventModel { Id = 22, Title = "Community Sports Day", Category = "Community", Location = "Athlone Stadium", Date = DateTime.Now.AddDays(22), Description = "Enjoy a day of sports and recreational activities for all ages, fostering teamwork, fitness, and community spirit." } }
            };

            // Configure main events DataGridView
            dataEvents.AutoGenerateColumns = false;
            dataEvents.Columns.Clear();

            // Add columns for Title, Category, Location, Date, and Description
            dataEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "Title",
                Width = 150
            });
            dataEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Category",
                DataPropertyName = "Category",
                Width = 100
            });
            dataEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Location",
                DataPropertyName = "Location",
                Width = 100
            });
            dataEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date",
                DataPropertyName = "Date",
                Width = 100
            });
            dataEvents.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                DataPropertyName = "Description",
                Width = 250
            });

            // Bind events to the DataGridView
            dataEvents.DataSource = allEvents.Values.ToList();

            // Configure sorting options
            cmbSort.Items.AddRange(new string[]
            {
                "Date ↑",
                "Date ↓",
                "Title A-Z",
                "Title Z-A"
            });
            cmbSort.SelectedIndexChanged += cmbSort_SelectedIndexChanged;
            cmbSort.SelectedIndex = 0;

            // Attach cell click event handlers
            dataEvents.CellClick += DataEvents_CellClick;
            dataSuggested.CellClick += DataSuggested_CellClick;

            // Setup the suggested events DataGridView
            SetupSuggestedGrid();

            // Restore cached suggestions if available
            if (hasCachedSuggestions)
            {
                categorySearchFrequency = new Dictionary<string, int>(cachedCategorySearchFrequency);
                suggestedEvents = new List<EventModel>(cachedSuggestedEvents);
                dataSuggested.DataSource = suggestedEvents.Select(ev => new { ev.Title, ev.Location, ev.Date }).ToList();
            }

        }

        // Configures the suggested events DataGridView
        private void SetupSuggestedGrid()
        {
            dataSuggested.AutoGenerateColumns = false;
            dataSuggested.Columns.Clear();

            dataSuggested.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Title",
                DataPropertyName = "Title",
                Width = 125
            });

            dataSuggested.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Location",
                DataPropertyName = "Location",
                Width = 150
            });

            dataSuggested.DataSource = new List<EventModel>();
        }

        // Filters events based on search text
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            // Filter events matching title, category, or location
            var filtered = allEvents.Values
            .Where(ev =>
                ev.Title.ToLower().Contains(searchText) ||
                ev.Category.ToLower().Contains(searchText) ||
                ev.Location.ToLower().Contains(searchText))
            .ToList();

            dataEvents.DataSource = filtered;

            // Update category search frequencies for suggestions
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var matchedCategories = filtered
                    .Select(ev => ev.Category.ToLower())
                    .Distinct()
                    .ToList();

                foreach (var cat in matchedCategories)
                {
                    if (categorySearchFrequency.ContainsKey(cat))
                        categorySearchFrequency[cat]++;
                    else
                        categorySearchFrequency[cat] = 1;
                }

            }
        }

        // Updates suggested events based on user interactions
        private void UpdateSuggestionsFromInteraction(string category)
        {
            string lowerCat = category.ToLower();

            // Increment frequency count for this category
            if (categorySearchFrequency.ContainsKey(lowerCat))
                categorySearchFrequency[lowerCat]++;
            else
                categorySearchFrequency[lowerCat] = 1;

            // Find top category
            var topCategory = categorySearchFrequency.OrderByDescending(c => c.Value).First().Key;

            // Get all events from top category
            suggestedEvents = allEvents.Values
                .Where(ev => ev.Category.ToLower() == topCategory)
                .ToList();

            // Update suggestion history
            foreach (var ev in suggestedEvents)
            {
                if (!suggestionHistory.Any(h => h.Title == ev.Title))
                {
                    suggestionHistory.Enqueue(ev);
                    if (suggestionHistory.Count > MaxHistory)
                        suggestionHistory.Dequeue();
                }
            }

            // Prepare display list including history
            var displayList = suggestedEvents
                .Select(ev => new { ev.Title, ev.Location, ev.Date })
                .Concat(suggestionHistory
                    .Except(suggestedEvents)
                    .Select(ev => new { ev.Title, ev.Location, ev.Date }))
                .ToList();

            dataSuggested.DataSource = displayList;

            // Cache suggestions for future use
            cachedCategorySearchFrequency = new Dictionary<string, int>(categorySearchFrequency);
            cachedSuggestedEvents = new List<EventModel>(suggestedEvents);
            hasCachedSuggestions = true;

        }

        // Trigger search on search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void dataEvents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataSuggested_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // Sort events based on selected criteria
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbSort.SelectedItem.ToString();
            var currentEvents = (dataEvents.DataSource as List<EventModel>) ?? allEvents.Values.ToList();

            switch (selected)
            {
                case "Date ↑":
                    currentEvents = currentEvents.OrderBy(ev => ev.Date).ToList();
                    break;
                case "Date ↓":
                    currentEvents = currentEvents.OrderByDescending(ev => ev.Date).ToList();
                    break;
                case "Title A-Z":
                    currentEvents = currentEvents.OrderBy(ev => ev.Title).ToList();
                    break;
                case "Title Z-A":
                    currentEvents = currentEvents.OrderByDescending(ev => ev.Title).ToList();
                    break;
            }

            dataEvents.DataSource = currentEvents;
        }

        // Home button closes the form
        private void homeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handles clicks on main events grid
        private void DataEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataEvents.DataSource is List<EventModel> currentEvents)
            {
                var selectedEvent = currentEvents[e.RowIndex];
                ShowEventDetails(selectedEvent); // open details form
                UpdateSuggestionsFromInteraction(selectedEvent.Category); // update suggestions
            }
        }

        // Handles clicks on suggested events grid
        private void DataSuggested_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataSuggested.DataSource is List<EventModel> suggested)
            {
                var selectedEvent = suggested[e.RowIndex];
                ShowEventDetails(selectedEvent);
            }
        }

        // Shows detailed information for an event
        private void ShowEventDetails(EventModel ev)
        {
            var detailsForm = new EventDetailsForm(ev.Title, ev.Category, ev.Location, ev.Date, ev.Description);
            detailsForm.ShowDialog();
        }

        // Clears cached suggestion data
        public static void ClearSuggestionCache()
        {
            cachedCategorySearchFrequency.Clear();
            cachedSuggestedEvents.Clear();
            hasCachedSuggestions = false;
        }

        // Moves announcement text to create scrolling effect
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblAnnouncements.Left -= 2; // move left

            // loop back when fully out of view
            if (lblAnnouncements.Right < 0)
            {
                lblAnnouncements.Left = pnlAnnouncements.Width;
            }
        }


        private void LocalEventsForm_Load_1(object sender, EventArgs e){}

        private void lblAnnouncements_Click(object sender, EventArgs e){}
    }
}
