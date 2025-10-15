namespace IssueReportSystem
{
    partial class LocalEventsForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvEvents = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataEvents = new System.Windows.Forms.DataGridView();
            this.dataSuggested = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.homeButton = new System.Windows.Forms.Button();
            this.pnlAnnouncements = new System.Windows.Forms.Panel();
            this.lblAnnouncements = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSuggested)).BeginInit();
            this.pnlAnnouncements.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnCount = 4;
            this.dgvEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.96629F));
            this.dgvEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.89888F));
            this.dgvEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.13483F));
            this.dgvEvents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 373F));
            this.dgvEvents.Controls.Add(this.label1, 1, 0);
            this.dgvEvents.Controls.Add(this.pictureBox1, 0, 0);
            this.dgvEvents.Controls.Add(this.dataEvents, 1, 4);
            this.dgvEvents.Controls.Add(this.dataSuggested, 3, 4);
            this.dgvEvents.Controls.Add(this.txtSearch, 1, 3);
            this.dgvEvents.Controls.Add(this.label3, 1, 2);
            this.dgvEvents.Controls.Add(this.cmbSort, 2, 3);
            this.dgvEvents.Controls.Add(this.label4, 2, 2);
            this.dgvEvents.Controls.Add(this.label2, 3, 2);
            this.dgvEvents.Controls.Add(this.label5, 3, 3);
            this.dgvEvents.Controls.Add(this.homeButton, 3, 0);
            this.dgvEvents.Controls.Add(this.pnlAnnouncements, 0, 5);
            this.dgvEvents.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(0, 0);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowCount = 6;
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.16674F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02781F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.180255F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.68768F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.937519F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dgvEvents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dgvEvents.Size = new System.Drawing.Size(1249, 464);
            this.dgvEvents.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.dgvEvents.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(151, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(720, 101);
            this.label1.TabIndex = 9;
            this.label1.Text = "Local Community Events";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::IssueReportSystem.Properties.Resources.govLogo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.dgvEvents.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(142, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataEvents
            // 
            this.dataEvents.AllowUserToAddRows = false;
            this.dataEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.SetColumnSpan(this.dataEvents, 2);
            this.dataEvents.Location = new System.Drawing.Point(151, 189);
            this.dataEvents.Name = "dataEvents";
            this.dataEvents.ReadOnly = true;
            this.dataEvents.Size = new System.Drawing.Size(705, 241);
            this.dataEvents.TabIndex = 12;
            this.dataEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEvents_CellContentClick);
            // 
            // dataSuggested
            // 
            this.dataSuggested.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataSuggested.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataSuggested.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataSuggested.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataSuggested.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSuggested.Location = new System.Drawing.Point(877, 189);
            this.dataSuggested.Name = "dataSuggested";
            this.dataSuggested.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataSuggested.Size = new System.Drawing.Size(358, 130);
            this.dataSuggested.TabIndex = 13;
            this.dataSuggested.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSuggested_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(151, 157);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(264, 20);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label3.Location = new System.Drawing.Point(148, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 6, 6, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label3.Size = new System.Drawing.Size(264, 39);
            this.label3.TabIndex = 15;
            this.label3.Text = "Search Events";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(421, 157);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(88, 21);
            this.cmbSort.TabIndex = 16;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label4.Location = new System.Drawing.Point(418, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 6, 6, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label4.Size = new System.Drawing.Size(450, 39);
            this.label4.TabIndex = 17;
            this.label4.Text = "Filter by:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.75F);
            this.label2.Location = new System.Drawing.Point(914, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(40, 6, 6, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label2.Size = new System.Drawing.Size(329, 39);
            this.label2.TabIndex = 14;
            this.label2.Text = "Recommended for You";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(914, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(40, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(203, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Search the title below to learn more!";
            // 
            // homeButton
            // 
            this.homeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.homeButton.Image = global::IssueReportSystem.Properties.Resources.icons8_home_32;
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.homeButton.Location = new System.Drawing.Point(1036, 25);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(50, 50);
            this.homeButton.TabIndex = 19;
            this.homeButton.Text = "Home";
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // pnlAnnouncements
            // 
            this.pnlAnnouncements.AutoSize = true;
            this.pnlAnnouncements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvEvents.SetColumnSpan(this.pnlAnnouncements, 5);
            this.pnlAnnouncements.Controls.Add(this.lblAnnouncements);
            this.pnlAnnouncements.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAnnouncements.Location = new System.Drawing.Point(3, 442);
            this.pnlAnnouncements.Name = "pnlAnnouncements";
            this.pnlAnnouncements.Size = new System.Drawing.Size(1243, 19);
            this.pnlAnnouncements.TabIndex = 20;
            // 
            // lblAnnouncements
            // 
            this.lblAnnouncements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnnouncements.AutoSize = true;
            this.lblAnnouncements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAnnouncements.Location = new System.Drawing.Point(900, 0);
            this.lblAnnouncements.Margin = new System.Windows.Forms.Padding(3);
            this.lblAnnouncements.Name = "lblAnnouncements";
            this.lblAnnouncements.Size = new System.Drawing.Size(466, 16);
            this.lblAnnouncements.TabIndex = 0;
            this.lblAnnouncements.Text = "Welcome to Local Events! Check upcoming events and workshops.";
            this.lblAnnouncements.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAnnouncements.Click += new System.EventHandler(this.lblAnnouncements_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 464);
            this.Controls.Add(this.dgvEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load_1);
            this.dgvEvents.ResumeLayout(false);
            this.dgvEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSuggested)).EndInit();
            this.pnlAnnouncements.ResumeLayout(false);
            this.pnlAnnouncements.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dgvEvents;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataEvents;
        private System.Windows.Forms.DataGridView dataSuggested;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Panel pnlAnnouncements;
        private System.Windows.Forms.Label lblAnnouncements;
        private System.Windows.Forms.Timer timer1;
    }
}