# IssueReportSystem

## Overview
The **Municipality Issue Reporting System** is a **C# Windows Forms application** that allows citizens to report issues in their community, such as potholes, water leaks, or broken streetlights.

The system also provides a **Local Events module**, where users can view community events, search by title, category, or location, and get **suggested events based on interaction history**.

The application demonstrates the use of **advanced C# data structures** (Linked Lists, Queues, Stacks, Dictionaries, and HashSets) to manage reports and events efficiently, **without relying on simple arrays or lists**.

---

## Features

### Issue Reporting
- **Report an Issue** – Log issues with details such as location, description, province, and category.  
- **File Attachments** – Attach images or documents as supporting evidence.  
- **Progress Bar** – Visual indicator when filling out issue forms.  
- **Multi-level Report Storage** – Organized by **Province → Category → Reports**.  
- **Pending & Recent Tracking** – Reports can be tracked via queues and stacks.  
- **Duplicate Prevention** – Ensures the same report cannot be submitted twice.  

### Local Events
- **Event Listing** – View community events with title, category, location, date, and description.  
- **Search & Filter** – Search events by text or filter by category/location.  
- **Sorting** – Sort events by date or title (ascending/descending).  
- **Suggested Events** – Personalized suggestions based on category interactions and search history.  
- **Caching** – Suggestion data persists across sessions while the application runs.  
- **Announcements Banner** – Scrollable announcements panel for updates.  

### User Interface
- **Fixed/Resizable Forms** – Some forms are non-resizable to maintain UI layout; others allow resizing.  
- **Modal Dialogs** – Open forms like Event Details or Report Issue as modal windows for focused interaction.  

---

## Technologies Used
- **Language:** C#  
- **Framework:** .NET (Windows Forms)  
- **IDE:** Visual Studio  

---

## Data Structures Implemented

The application does **not use arrays or simple lists** for report management. Instead, it leverages:

### Reports
- `LinkedList<Report>` → Stores all reports  
- `Queue<Report>` → Stores pending reports  
- `Stack<Report>` → Tracks recently viewed reports  
- `Dictionary<string, Dictionary<string, LinkedList<Report>>>` → Multi-level storage by province & category  
- `HashSet<string>` → Prevents duplicate entries (e.g., report IDs or attachments)  

### Local Events
- `SortedDictionary<int, EventModel>` → Stores all events with unique IDs  
- `List<EventModel>` → Stores suggested events for user interaction  
- `Queue<EventModel>` → Maintains history of displayed suggestions  
- `Dictionary<string, int>` → Tracks category search frequency for generating recommendations  

---

## Author
Developed by **Liam Coetzee**  
Student Number: **ST10258941**  
YouTube Link: [https://www.youtube.com/watch?v=ibJt_bwFM4w](https://www.youtube.com/watch?v=ibJt_bwFM4w)
