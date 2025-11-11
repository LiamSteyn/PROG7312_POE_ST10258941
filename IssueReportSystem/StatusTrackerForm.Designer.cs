namespace IssueReportSystem
{
    partial class StatusTrackerForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewStatus = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.statusFilterDropdown = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowMyPriority = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.49056F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.50943F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
            this.tableLayoutPanel1.Controls.Add(this.btnBack, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewStatus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userIdTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusFilterDropdown, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnShowMyPriority, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.93023F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.06977F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnBack.Image = global::IssueReportSystem.Properties.Resources.icons8_home_32;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(730, 3);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 55);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Home";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label1.Location = new System.Drawing.Point(3, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Filter Status:";
            // 
            // dataGridViewStatus
            // 
            this.dataGridViewStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewStatus, 3);
            this.dataGridViewStatus.Location = new System.Drawing.Point(3, 184);
            this.dataGridViewStatus.Name = "dataGridViewStatus";
            this.dataGridViewStatus.Size = new System.Drawing.Size(794, 168);
            this.dataGridViewStatus.TabIndex = 21;
            this.dataGridViewStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStatus_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "View Report Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search Via ID:";
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
            this.userIdTextBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.userIdTextBox.Location = new System.Drawing.Point(6, 86);
            this.userIdTextBox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.userIdTextBox.Multiline = true;
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(271, 23);
            this.userIdTextBox.TabIndex = 19;
            this.userIdTextBox.Tag = "";
            this.userIdTextBox.TextChanged += new System.EventHandler(this.userIdTextBox_TextChanged);
            // 
            // statusFilterDropdown
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusFilterDropdown, 2);
            this.statusFilterDropdown.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.statusFilterDropdown.FormattingEnabled = true;
            this.statusFilterDropdown.Location = new System.Drawing.Point(6, 150);
            this.statusFilterDropdown.Margin = new System.Windows.Forms.Padding(6);
            this.statusFilterDropdown.Name = "statusFilterDropdown";
            this.statusFilterDropdown.Size = new System.Drawing.Size(121, 21);
            this.statusFilterDropdown.TabIndex = 20;
            this.statusFilterDropdown.SelectedIndexChanged += new System.EventHandler(this.statusFilterDropdown_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowMyPriority
            // 
            this.btnShowMyPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMyPriority.Location = new System.Drawing.Point(672, 147);
            this.btnShowMyPriority.Name = "btnShowMyPriority";
            this.btnShowMyPriority.Size = new System.Drawing.Size(125, 23);
            this.btnShowMyPriority.TabIndex = 24;
            this.btnShowMyPriority.Text = "Next In-line Report";
            this.btnShowMyPriority.UseVisualStyleBackColor = true;
            this.btnShowMyPriority.Click += new System.EventHandler(this.btnShowMyPriority_Click);
            // 
            // StatusTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatusTrackerForm";
            this.Text = "StatusTrackerForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.ComboBox statusFilterDropdown;
        private System.Windows.Forms.DataGridView dataGridViewStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnShowMyPriority;
    }
}