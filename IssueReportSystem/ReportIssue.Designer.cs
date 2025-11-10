namespace IssueReportSystem
{
    partial class ReportIssue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.IssueTitle = new System.Windows.Forms.Label();
            this.issueDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.issueLocation = new System.Windows.Forms.TextBox();
            this.categoryDropdown = new System.Windows.Forms.ComboBox();
            this.attachButton = new System.Windows.Forms.Button();
            this.progressBarReport = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.provinceDropdown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.516F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.45619F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.02781F));
            this.tableLayoutPanel1.Controls.Add(this.userIdTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.IssueTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.submitButton, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.issueDescription, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.issueLocation, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.categoryDropdown, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.attachButton, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.progressBarReport, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.provinceDropdown, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.homeButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.65579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.637982F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.005935F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.153347F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.155387F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.86501F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.010199F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.582793F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.60319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.86705F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.584832F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.888314F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.213376F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.67071F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 674);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // IssueTitle
            // 
            this.IssueTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.IssueTitle, 2);
            this.IssueTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IssueTitle.Font = new System.Drawing.Font("Segoe UI", 18.75F, System.Drawing.FontStyle.Bold);
            this.IssueTitle.Location = new System.Drawing.Point(3, 0);
            this.IssueTitle.Name = "IssueTitle";
            this.IssueTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.IssueTitle.Size = new System.Drawing.Size(454, 119);
            this.IssueTitle.TabIndex = 3;
            this.IssueTitle.Text = "Report an Issue";
            this.IssueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IssueTitle.Click += new System.EventHandler(this.Title_Click);
            // 
            // issueDescription
            // 
            this.issueDescription.AccessibleDescription = "";
            this.issueDescription.AccessibleName = "";
            this.issueDescription.BackColor = System.Drawing.SystemColors.Window;
            this.issueDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.issueDescription, 2);
            this.issueDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.issueDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.issueDescription.HideSelection = false;
            this.issueDescription.Location = new System.Drawing.Point(6, 355);
            this.issueDescription.Margin = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.issueDescription.Multiline = true;
            this.issueDescription.Name = "issueDescription";
            this.issueDescription.Size = new System.Drawing.Size(448, 99);
            this.issueDescription.TabIndex = 6;
            this.issueDescription.Tag = "";
            this.issueDescription.TextChanged += new System.EventHandler(this.issueDescription_TextChanged);
            this.issueDescription.Enter += new System.EventHandler(this.issueDescription_Enter);
            this.issueDescription.Leave += new System.EventHandler(this.issueDescription_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label1.Location = new System.Drawing.Point(6, 324);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label1.Size = new System.Drawing.Size(448, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Description:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // issueLocation
            // 
            this.issueLocation.AccessibleDescription = "";
            this.issueLocation.AccessibleName = "";
            this.issueLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.issueLocation.BackColor = System.Drawing.SystemColors.Window;
            this.issueLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.issueLocation, 2);
            this.issueLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.issueLocation.Location = new System.Drawing.Point(6, 285);
            this.issueLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.issueLocation.Multiline = true;
            this.issueLocation.Name = "issueLocation";
            this.issueLocation.Size = new System.Drawing.Size(448, 27);
            this.issueLocation.TabIndex = 10;
            this.issueLocation.Tag = "";
            this.issueLocation.TextChanged += new System.EventHandler(this.issueLocation_TextChanged);
            this.issueLocation.Enter += new System.EventHandler(this.issueLocation_Enter);
            this.issueLocation.Leave += new System.EventHandler(this.issueLocation_Leave);
            // 
            // categoryDropdown
            // 
            this.categoryDropdown.AccessibleName = "";
            this.tableLayoutPanel1.SetColumnSpan(this.categoryDropdown, 2);
            this.categoryDropdown.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.categoryDropdown.FormattingEnabled = true;
            this.categoryDropdown.Location = new System.Drawing.Point(6, 466);
            this.categoryDropdown.Margin = new System.Windows.Forms.Padding(6);
            this.categoryDropdown.Name = "categoryDropdown";
            this.categoryDropdown.Size = new System.Drawing.Size(129, 21);
            this.categoryDropdown.TabIndex = 5;
            this.categoryDropdown.Text = "-- Select Issue Type --";
            this.categoryDropdown.SelectedIndexChanged += new System.EventHandler(this.categoryDropdown_SelectedIndexChanged);
            // 
            // attachButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.attachButton, 2);
            this.attachButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.attachButton.Location = new System.Drawing.Point(6, 498);
            this.attachButton.Margin = new System.Windows.Forms.Padding(6);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(75, 23);
            this.attachButton.TabIndex = 11;
            this.attachButton.Text = "Attach File";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // progressBarReport
            // 
            this.progressBarReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.progressBarReport, 3);
            this.progressBarReport.Location = new System.Drawing.Point(3, 565);
            this.progressBarReport.Name = "progressBarReport";
            this.progressBarReport.Size = new System.Drawing.Size(570, 15);
            this.progressBarReport.Step = 25;
            this.progressBarReport.TabIndex = 12;
            this.progressBarReport.Click += new System.EventHandler(this.progressReport_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label3.Location = new System.Drawing.Point(3, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(570, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Report Progress";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // provinceDropdown
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.provinceDropdown, 2);
            this.provinceDropdown.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.provinceDropdown.FormattingEnabled = true;
            this.provinceDropdown.Location = new System.Drawing.Point(6, 224);
            this.provinceDropdown.Margin = new System.Windows.Forms.Padding(6);
            this.provinceDropdown.Name = "provinceDropdown";
            this.provinceDropdown.Size = new System.Drawing.Size(121, 21);
            this.provinceDropdown.TabIndex = 16;
            this.provinceDropdown.SelectedIndexChanged += new System.EventHandler(this.provinceDropdown_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label2.Location = new System.Drawing.Point(6, 190);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label2.Size = new System.Drawing.Size(448, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Report Location:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label4.Location = new System.Drawing.Point(3, 259);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Address:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 2);
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label5.Location = new System.Drawing.Point(6, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label5.Size = new System.Drawing.Size(448, 32);
            this.label5.TabIndex = 17;
            this.label5.Text = "User ID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.AccessibleDescription = "";
            this.userIdTextBox.AccessibleName = "";
            this.userIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userIdTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.userIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.userIdTextBox, 2);
            this.userIdTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.userIdTextBox.Location = new System.Drawing.Point(6, 157);
            this.userIdTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.userIdTextBox.Multiline = true;
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(448, 21);
            this.userIdTextBox.TabIndex = 18;
            this.userIdTextBox.Tag = "";
            this.userIdTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // submitButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.submitButton, 3);
            this.submitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.submitButton.Image = global::IssueReportSystem.Properties.Resources.icons8_send_32;
            this.submitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.submitButton.Location = new System.Drawing.Point(6, 589);
            this.submitButton.Margin = new System.Windows.Forms.Padding(6);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(564, 52);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit Issue";
            this.submitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.homeButton.Image = global::IssueReportSystem.Properties.Resources.icons8_home_32;
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homeButton.Location = new System.Drawing.Point(493, 34);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(50, 50);
            this.homeButton.TabIndex = 13;
            this.homeButton.Text = "Home";
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 674);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportIssue";
            this.Text = "Report Window";
            this.Load += new System.EventHandler(this.ReportIssue_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label IssueTitle;
        private System.Windows.Forms.ComboBox categoryDropdown;
        private System.Windows.Forms.TextBox issueDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox issueLocation;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.ProgressBar progressBarReport;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox provinceDropdown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userIdTextBox;
    }
}