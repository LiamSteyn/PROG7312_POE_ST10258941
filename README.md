#  IssueReportSystem

##  Overview
The **Municipality Issue Reporting System** is a **C# Windows Forms application** that allows citizens to report issues in their community, such as potholes, water leaks, or broken streetlights.

The system demonstrates the use of **advanced C# data structures** (Linked Lists, Queues, Stacks, Dictionaries, and HashSets) to manage reports **without relying on arrays or simple lists**.

---

##  Features
-  **Report an Issue** – Log issues with details such as location, description, province, and category.  
-  **File Attachments** – Attach images or documents as supporting evidence.  
-  **Progress Bar** – Visual progress indicator when filling out issue forms.  
- 🗂 **Multi-level Report Storage** – Organized by **Province → Category → Reports**.  

---

## 🛠 Technologies Used
- **Language:** C#  
- **Framework:** .NET (Windows Forms)  
- **IDE:** Visual Studio  

---

##  Data Structures Implemented
The application does **not use arrays or simple lists** for report management. Instead, it leverages:

- `LinkedList<Report>` → Stores all reports  
- `Queue<Report>` → Stores pending reports  
- `Stack<Report>` → Tracks recently viewed reports  
- `Dictionary<string, Dictionary<string, LinkedList<Report>>>` → Multi-level storage by province & category  
- `HashSet<string>` → Prevents duplicate entries (e.g., report IDs or attachments)  

---

##  Author
Developed by **Liam Coetzee**  
Student Number: **ST10258941**

