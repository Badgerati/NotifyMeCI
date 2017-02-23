namespace NotifyMeCI.GUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.JobsTab = new System.Windows.Forms.TabPage();
            this.JobListView = new System.Windows.Forms.ListView();
            this.JobList_BuildIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobList_JobNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobList_ServerNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobList_TimeStampColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobList_DurationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JobList_StatusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServersTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ApiTokenLbl = new System.Windows.Forms.Label();
            this.ApiTokenTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PollIntervalNbr = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerUrlTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerNameTxt = new System.Windows.Forms.TextBox();
            this.ServerTypeDdl = new System.Windows.Forms.ComboBox();
            this.AddServerBtn = new System.Windows.Forms.Button();
            this.ServerListView = new System.Windows.Forms.ListView();
            this.ServerList_NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerList_TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerList_UrlColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerList_PollColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerList_LastPollColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerList_EnabledColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskbarNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.JobsTab.SuspendLayout();
            this.ServersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PollIntervalNbr)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.JobsTab);
            this.tabControl1.Controls.Add(this.ServersTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 484);
            this.tabControl1.TabIndex = 1;
            // 
            // JobsTab
            // 
            this.JobsTab.Controls.Add(this.JobListView);
            this.JobsTab.Location = new System.Drawing.Point(4, 22);
            this.JobsTab.Name = "JobsTab";
            this.JobsTab.Padding = new System.Windows.Forms.Padding(3);
            this.JobsTab.Size = new System.Drawing.Size(883, 458);
            this.JobsTab.TabIndex = 0;
            this.JobsTab.Text = "Jobs";
            this.JobsTab.UseVisualStyleBackColor = true;
            // 
            // JobListView
            // 
            this.JobListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JobList_BuildIdColumn,
            this.JobList_JobNameColumn,
            this.JobList_ServerNameColumn,
            this.JobList_TimeStampColumn,
            this.JobList_DurationColumn,
            this.JobList_StatusColumn});
            this.JobListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobListView.FullRowSelect = true;
            this.JobListView.GridLines = true;
            this.JobListView.Location = new System.Drawing.Point(3, 3);
            this.JobListView.Name = "JobListView";
            this.JobListView.Size = new System.Drawing.Size(877, 452);
            this.JobListView.TabIndex = 0;
            this.JobListView.UseCompatibleStateImageBehavior = false;
            this.JobListView.View = System.Windows.Forms.View.Details;
            this.JobListView.DoubleClick += new System.EventHandler(this.JobListView_DoubleClick);
            // 
            // JobList_BuildIdColumn
            // 
            this.JobList_BuildIdColumn.Text = "Build ID";
            this.JobList_BuildIdColumn.Width = 70;
            // 
            // JobList_JobNameColumn
            // 
            this.JobList_JobNameColumn.Text = "Job Name";
            this.JobList_JobNameColumn.Width = 240;
            // 
            // JobList_ServerNameColumn
            // 
            this.JobList_ServerNameColumn.Text = "Server Name";
            this.JobList_ServerNameColumn.Width = 200;
            // 
            // JobList_TimeStampColumn
            // 
            this.JobList_TimeStampColumn.Text = "TimeStamp";
            this.JobList_TimeStampColumn.Width = 190;
            // 
            // JobList_DurationColumn
            // 
            this.JobList_DurationColumn.Text = "Duration";
            this.JobList_DurationColumn.Width = 90;
            // 
            // JobList_StatusColumn
            // 
            this.JobList_StatusColumn.Text = "Status";
            this.JobList_StatusColumn.Width = 80;
            // 
            // ServersTab
            // 
            this.ServersTab.Controls.Add(this.splitContainer1);
            this.ServersTab.Location = new System.Drawing.Point(4, 22);
            this.ServersTab.Name = "ServersTab";
            this.ServersTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServersTab.Size = new System.Drawing.Size(883, 458);
            this.ServersTab.TabIndex = 1;
            this.ServersTab.Text = "Servers";
            this.ServersTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ApiTokenLbl);
            this.splitContainer1.Panel1.Controls.Add(this.ApiTokenTxt);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.PollIntervalNbr);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.ServerUrlTxt);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ServerNameTxt);
            this.splitContainer1.Panel1.Controls.Add(this.ServerTypeDdl);
            this.splitContainer1.Panel1.Controls.Add(this.AddServerBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ServerListView);
            this.splitContainer1.Size = new System.Drawing.Size(877, 452);
            this.splitContainer1.TabIndex = 0;
            // 
            // ApiTokenLbl
            // 
            this.ApiTokenLbl.AutoSize = true;
            this.ApiTokenLbl.Location = new System.Drawing.Point(664, 3);
            this.ApiTokenLbl.Name = "ApiTokenLbl";
            this.ApiTokenLbl.Size = new System.Drawing.Size(75, 13);
            this.ApiTokenLbl.TabIndex = 11;
            this.ApiTokenLbl.Text = "Authentication";
            // 
            // ApiTokenTxt
            // 
            this.ApiTokenTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ApiTokenTxt.Location = new System.Drawing.Point(667, 24);
            this.ApiTokenTxt.Name = "ApiTokenTxt";
            this.ApiTokenTxt.Size = new System.Drawing.Size(204, 20);
            this.ApiTokenTxt.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Poll";
            // 
            // PollIntervalNbr
            // 
            this.PollIntervalNbr.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PollIntervalNbr.Location = new System.Drawing.Point(544, 24);
            this.PollIntervalNbr.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PollIntervalNbr.Name = "PollIntervalNbr";
            this.PollIntervalNbr.Size = new System.Drawing.Size(58, 20);
            this.PollIntervalNbr.TabIndex = 63;
            this.PollIntervalNbr.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Url";
            // 
            // ServerUrlTxt
            // 
            this.ServerUrlTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerUrlTxt.Location = new System.Drawing.Point(355, 24);
            this.ServerUrlTxt.Name = "ServerUrlTxt";
            this.ServerUrlTxt.Size = new System.Drawing.Size(171, 20);
            this.ServerUrlTxt.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Type";
            // 
            // ServerNameTxt
            // 
            this.ServerNameTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerNameTxt.Location = new System.Drawing.Point(210, 24);
            this.ServerNameTxt.Name = "ServerNameTxt";
            this.ServerNameTxt.Size = new System.Drawing.Size(128, 20);
            this.ServerNameTxt.TabIndex = 61;
            // 
            // ServerTypeDdl
            // 
            this.ServerTypeDdl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ServerTypeDdl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTypeDdl.FormattingEnabled = true;
            this.ServerTypeDdl.Items.AddRange(new object[] {
            "Jenkins",
            "AppVeyor",
            "TravisCI"});
            this.ServerTypeDdl.Location = new System.Drawing.Point(93, 24);
            this.ServerTypeDdl.Name = "ServerTypeDdl";
            this.ServerTypeDdl.Size = new System.Drawing.Size(101, 21);
            this.ServerTypeDdl.TabIndex = 60;
            this.ServerTypeDdl.SelectedIndexChanged += new System.EventHandler(this.ServerTypeDdl_SelectedIndexChanged);
            // 
            // AddServerBtn
            // 
            this.AddServerBtn.Location = new System.Drawing.Point(4, 3);
            this.AddServerBtn.Name = "AddServerBtn";
            this.AddServerBtn.Size = new System.Drawing.Size(75, 42);
            this.AddServerBtn.TabIndex = 99;
            this.AddServerBtn.Text = "Add Server";
            this.AddServerBtn.UseVisualStyleBackColor = true;
            this.AddServerBtn.Click += new System.EventHandler(this.AddServerBtn_Click);
            // 
            // ServerListView
            // 
            this.ServerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerList_NameColumn,
            this.ServerList_TypeColumn,
            this.ServerList_UrlColumn,
            this.ServerList_PollColumn,
            this.ServerList_LastPollColumn,
            this.ServerList_EnabledColumn});
            this.ServerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerListView.FullRowSelect = true;
            this.ServerListView.GridLines = true;
            this.ServerListView.Location = new System.Drawing.Point(0, 0);
            this.ServerListView.MultiSelect = false;
            this.ServerListView.Name = "ServerListView";
            this.ServerListView.Size = new System.Drawing.Size(875, 396);
            this.ServerListView.TabIndex = 0;
            this.ServerListView.UseCompatibleStateImageBehavior = false;
            this.ServerListView.View = System.Windows.Forms.View.Details;
            this.ServerListView.DoubleClick += new System.EventHandler(this.ServerListView_DoubleClick);
            // 
            // ServerList_NameColumn
            // 
            this.ServerList_NameColumn.Text = "Name";
            this.ServerList_NameColumn.Width = 180;
            // 
            // ServerList_TypeColumn
            // 
            this.ServerList_TypeColumn.Text = "Type";
            this.ServerList_TypeColumn.Width = 90;
            // 
            // ServerList_UrlColumn
            // 
            this.ServerList_UrlColumn.Text = "URL";
            this.ServerList_UrlColumn.Width = 300;
            // 
            // ServerList_PollColumn
            // 
            this.ServerList_PollColumn.Text = "Poll (every)";
            this.ServerList_PollColumn.Width = 80;
            // 
            // ServerList_LastPollColumn
            // 
            this.ServerList_LastPollColumn.Text = "Last Poll Time";
            this.ServerList_LastPollColumn.Width = 150;
            // 
            // ServerList_EnabledColumn
            // 
            this.ServerList_EnabledColumn.Text = "Enabled";
            this.ServerList_EnabledColumn.Width = 70;
            // 
            // TaskbarNotifier
            // 
            this.TaskbarNotifier.Icon = ((System.Drawing.Icon)(resources.GetObject("TaskbarNotifier.Icon")));
            this.TaskbarNotifier.Text = "Notify Me CI";
            this.TaskbarNotifier.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notify Me CI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.JobsTab.ResumeLayout(false);
            this.ServersTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PollIntervalNbr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage JobsTab;
        private System.Windows.Forms.TabPage ServersTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox ServerTypeDdl;
        private System.Windows.Forms.Button AddServerBtn;
        private System.Windows.Forms.Label ApiTokenLbl;
        private System.Windows.Forms.TextBox ApiTokenTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown PollIntervalNbr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerUrlTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerNameTxt;
        private System.Windows.Forms.ListView ServerListView;
        private System.Windows.Forms.ColumnHeader ServerList_NameColumn;
        private System.Windows.Forms.ColumnHeader ServerList_TypeColumn;
        private System.Windows.Forms.ColumnHeader ServerList_UrlColumn;
        private System.Windows.Forms.ColumnHeader ServerList_PollColumn;
        private System.Windows.Forms.ColumnHeader ServerList_LastPollColumn;
        private System.Windows.Forms.ColumnHeader ServerList_EnabledColumn;
        private System.Windows.Forms.ListView JobListView;
        private System.Windows.Forms.ColumnHeader JobList_BuildIdColumn;
        private System.Windows.Forms.ColumnHeader JobList_JobNameColumn;
        private System.Windows.Forms.ColumnHeader JobList_ServerNameColumn;
        private System.Windows.Forms.ColumnHeader JobList_TimeStampColumn;
        private System.Windows.Forms.ColumnHeader JobList_DurationColumn;
        private System.Windows.Forms.ColumnHeader JobList_StatusColumn;
        private System.Windows.Forms.NotifyIcon TaskbarNotifier;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

