namespace IssueReportSystem
{
    partial class ViewReportsForm
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
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.comboProvince = new System.Windows.Forms.ComboBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDetectDuplicates = new System.Windows.Forms.Button();
            this.btnShowMyPriority = new System.Windows.Forms.Button();
            this.btnShowHotspots = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Location = new System.Drawing.Point(12, 163);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.Size = new System.Drawing.Size(407, 226);
            this.dataGridViewReports.TabIndex = 0;
            this.dataGridViewReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReports_CellContentClick);
            // 
            // comboProvince
            // 
            this.comboProvince.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.comboProvince.FormattingEnabled = true;
            this.comboProvince.Location = new System.Drawing.Point(12, 114);
            this.comboProvince.Name = "comboProvince";
            this.comboProvince.Size = new System.Drawing.Size(121, 21);
            this.comboProvince.TabIndex = 1;
            this.comboProvince.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboCategory
            // 
            this.comboCategory.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(165, 114);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(121, 21);
            this.comboCategory.TabIndex = 2;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label1.Location = new System.Drawing.Point(161, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter Category";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label2.Location = new System.Drawing.Point(8, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter Province";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Report Data";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Review Reported Issues";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(162, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "First select a province";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(9, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "View issues by province";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnBack.Image = global::IssueReportSystem.Properties.Resources.icons8_home_32;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(369, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 51);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Home";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDetectDuplicates
            // 
            this.btnDetectDuplicates.Location = new System.Drawing.Point(12, 474);
            this.btnDetectDuplicates.Name = "btnDetectDuplicates";
            this.btnDetectDuplicates.Size = new System.Drawing.Size(91, 23);
            this.btnDetectDuplicates.TabIndex = 11;
            this.btnDetectDuplicates.Text = "Duplicates";
            this.btnDetectDuplicates.UseVisualStyleBackColor = true;
            this.btnDetectDuplicates.Click += new System.EventHandler(this.btnDetectDuplicates_Click);
            // 
            // btnShowMyPriority
            // 
            this.btnShowMyPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMyPriority.Location = new System.Drawing.Point(234, 474);
            this.btnShowMyPriority.Name = "btnShowMyPriority";
            this.btnShowMyPriority.Size = new System.Drawing.Size(108, 23);
            this.btnShowMyPriority.TabIndex = 25;
            this.btnShowMyPriority.Text = "Next In-line Report";
            this.btnShowMyPriority.UseVisualStyleBackColor = true;
            this.btnShowMyPriority.Click += new System.EventHandler(this.btnShowMyPriority_Click);
            // 
            // btnShowHotspots
            // 
            this.btnShowHotspots.Location = new System.Drawing.Point(120, 474);
            this.btnShowHotspots.Name = "btnShowHotspots";
            this.btnShowHotspots.Size = new System.Drawing.Size(95, 23);
            this.btnShowHotspots.TabIndex = 26;
            this.btnShowHotspots.Text = "Report Hotspots";
            this.btnShowHotspots.UseVisualStyleBackColor = true;
            this.btnShowHotspots.Click += new System.EventHandler(this.btnShowHotspots_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 22);
            this.button2.TabIndex = 27;
            this.button2.Text = "Priority Sort";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.25F);
            this.label7.Location = new System.Drawing.Point(13, 442);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Exta Tools:";
            // 
            // ViewReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 509);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnShowHotspots);
            this.Controls.Add(this.btnShowMyPriority);
            this.Controls.Add(this.btnDetectDuplicates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.comboProvince);
            this.Controls.Add(this.dataGridViewReports);
            this.Name = "ViewReportsForm";
            this.Text = "View Reports Window";
            this.Load += new System.EventHandler(this.ViewReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.ComboBox comboProvince;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDetectDuplicates;
        private System.Windows.Forms.Button btnShowMyPriority;
        private System.Windows.Forms.Button btnShowHotspots;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
    }
}