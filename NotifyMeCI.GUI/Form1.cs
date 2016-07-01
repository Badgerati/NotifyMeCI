/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using NotifyMeCI.Engine.Misc;
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Injector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Threading.Tasks;
using NotifyMeCI.GUI.Properties;
using NotifyMeCI.Engine.Tasks;
using System.Diagnostics;

namespace NotifyMeCI.GUI
{
    public partial class Form1 : Form
    {

        #region Repositories

        private ICIServerRepository CIServerRepository
        {
            get { return DIContainer.Instance.Get<ICIServerRepository>(); }
        }

        #endregion

        #region Fields

        private IList<CIServer> Servers = new List<CIServer>(2);
        private IList<CIJob> Jobs = new List<CIJob>(10);
        private JobTask JobTask = default(JobTask);
        private NotifyTask NotifyTask = default(NotifyTask);

        #endregion

        #region Constructor

        public Form1()
        {
            // initialise
            InitializeComponent();
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Resize += Form1_Resize;

            ApplicationEvents.Instance.Start();

            // setup lists
            SetupServerList();

            // show server tab if no servers setup
            if (Servers == default(IList<CIServer>) || !Servers.Any())
            {
                tabControl1.SelectedTab = ServersTab;
            }

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            // setup notify event
            TaskbarNotifier.BalloonTipClicked += TaskbarNotifier_BalloonTipClicked;
            TaskbarNotifier.MouseDoubleClick += TaskbarNotifier_MouseDoubleClick;

            // start parallel task
            JobTask = new JobTask(UpdateJobsList);
            NotifyTask = new NotifyTask(NotifyJob);
            Task.Run(() => Parallel.ForEach(new ITask[] { JobTask, NotifyTask }, task => task.Run()));
        }

        #endregion

        #region Events

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseForm();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = tabControl1.SelectedTab;

            if (sender == default(object) || tab == default(TabPage))
            {
                return;
            }

            if (tab.Text.Equals("Servers", StringComparison.InvariantCultureIgnoreCase))
            {
                SetupServerList();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            switch (WindowState)
            {
                case FormWindowState.Minimized:
                    TaskbarNotifier.Visible = true;
                    Hide();
                    break;

                case FormWindowState.Normal:
                    if (JobTask != default(ITask) && !JobTask.IsInterrupted)
                    {
                        JobTask.CoreLogic();
                    }
                    break;
            }
        }

        private void TaskbarNotifier_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Matthew Kelly\nVersion: " + Assembly.GetEntryAssembly().GetName().Version,
                "Notify Me CI",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ServerTypeDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serverType = default(CIServerType);

            var selectedItem = ServerTypeDdl.SelectedItem;
            var serverTypeTxt = selectedItem == default(object)
                ? string.Empty
                : selectedItem.ToString();

            // toggle the API token control
            if (!Enum.TryParse<CIServerType>(serverTypeTxt, true, out serverType))
            {
                ApiTokenTxt.Visible = true;
                ApiTokenLbl.Visible = true;
                return;
            }

            switch (serverType)
            {
                case CIServerType.AppVeyor:
                    ServerUrlTxt.Text = "https://ci.appveyor.com/api/projects";
                    break;

                case CIServerType.TravisCI:
                    ServerUrlTxt.Text = "https://api.travis-ci.org/repos/<USERNAME>";
                    break;
            }

            switch (serverType)
            {
                case CIServerType.TravisCI:
                    ApiTokenTxt.Visible = false;
                    ApiTokenLbl.Visible = false;
                    break;

                default:
                    ApiTokenTxt.Visible = true;
                    ApiTokenLbl.Visible = true;
                    break;
            }
        }

        private void AddServerBtn_Click(object sender, EventArgs e)
        {
            var errorTitle = "Error Adding New Server";

            try
            {
                // validate server info
                var selectedItem = ServerTypeDdl.SelectedItem;
                var serverTypeTxt = selectedItem == default(object)
                    ? string.Empty
                    : selectedItem.ToString();

                var error = Validator.ValidateServerValues(serverTypeTxt, ServerNameTxt.Text, ServerUrlTxt.Text, (int)PollIntervalNbr.Value, ApiTokenTxt.Text);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    Logger.ShowErrorMessage(error, errorTitle);
                    return;
                }

                // get server type
                var serverType = default(CIServerType);
                Enum.TryParse<CIServerType>(serverTypeTxt, true, out serverType);

                // insert server
                var server = new CIServer()
                {
                    ServerType = serverType,
                    Name = ServerNameTxt.Text,
                    Url = ServerUrlTxt.Text,
                    PollInterval = (int)PollIntervalNbr.Value,
                    CurrentlyPolling = false,
                    Enabled = true,
                    ApiToken = ApiTokenTxt.Visible ? ApiTokenTxt.Text : string.Empty
                };

                CIServerRepository.Insert(server);

                // clear fields
                ApiTokenTxt.Text = string.Empty;
                ServerUrlTxt.Text = string.Empty;
                ServerNameTxt.Text = string.Empty;
                PollIntervalNbr.Value = 30;

                // declare success
                MessageBox.Show("New server added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh server and job lists
                SetupServerList();
            }
            catch (Exception ex)
            {
                Logger.ShowExceptionMessage("There was a fatal issue adding a new server:", ex, errorTitle);
                return;
            }
        }

        private void ServerListView_DoubleClick(object sender, EventArgs e)
        {
            if (ServerListView.SelectedItems == null || ServerListView.SelectedItems.Count == 0)
            {
                return;
            }

            var server = Servers[ServerListView.SelectedIndices[0]];
            var edit = new EditServerForm(server);

            var result = edit.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.None)
            {
                SetupServerList();
            }
        }

        private void JobListView_DoubleClick(object sender, EventArgs e)
        {
            if (JobListView.SelectedItems == null || JobListView.SelectedItems.Count == 0)
            {
                return;
            }

            var job = Jobs[JobListView.SelectedIndices[0]];
            Process.Start(job.Url);
        }

        private void TaskbarNotifier_BalloonTipClicked(object sender, EventArgs e)
        {
            if (sender == default(object) || NotifyTask.CurrentNotifyJob == default(CIJob))
            {
                return;
            }

            Process.Start(NotifyTask.CurrentNotifyJob.Url);
        }

        #endregion

        #region Private Helpers

        private void SetupServerList()
        {
            // get all servers
            Servers = CIServerRepository.All();

            if (Servers == default(IList<CIServer>) || Servers.Count == 0)
            {
                return;
            }

            ServerListView.Items.Clear();
            ServerListView.SmallImageList = new ImageList() { ImageSize = new Size(1, 26) };

            foreach (var server in Servers)
            {
                var item = new ListViewItem(new string[]
                    {
                        server.Name,
                        server.ServerType.ToString(),
                        server.Url,
                        server.PollInterval.ToString(),
                        server.LastPollDate.ToLongDateString() + " " + server.LastPollDate.ToLongTimeString(),
                        server.Enabled.ToString()
                    });

                item.BackColor = server.Enabled ? Preferences.SUCCESS_COLOR : Preferences.FAIL_COLOR;
                item.ForeColor = Color.Black;
                ServerListView.Items.Add(item);
            }
        }

        private void UpdateJobsList(IList<CIJob> jobs)
        {
            if (jobs == default(IList<CIJob>) || !jobs.Any())
            {
                return;
            }

            var informList = new List<CIJob>(10);

            // compare these jobs to the current ones
            foreach (var job in jobs)
            {
                // fetch for the job
                var _job = Jobs.SingleOrDefault(x => x.Name == job.Name && x.ServerName == job.ServerName);

                // if the jobs exists with the same status then continue
                if (_job != default(CIJob) && _job.BuildStatus == job.BuildStatus)
                {
                    UpdateJob(_job, job);
                    continue;
                }

                // if the jobs doesn't exist add it                
                if (_job == default(CIJob))
                {
                    Jobs.Add(job);

                    // if it's failing or building inform about it
                    if (job.BuildStatus == BuildStatusType.Failed || job.BuildStatus == BuildStatusType.Building)
                    {
                        informList.Add(job);
                    }
                }

                // else, the job exists, but it's status has changed
                else
                {
                    // determine if job needs to be informed
                    if (_job.BuildStatus != job.BuildStatus)
                    {
                        informList.Add(job);
                    }

                    // update the job
                    UpdateJob(_job, job);
                }
            }

            // remove jobs from the list that no longer exist on the server
            var deadJobs = Jobs.Where(x => !jobs.Any(y => y.Name == x.Name && y.ServerName == x.ServerName));
            foreach (var job in deadJobs.ToList())
            {
                Jobs.Remove(job);
            }

            // reset ordering
            Jobs = Jobs.OrderBy(a => a.BuildStatus).ToList();

            // show the inform list
            UpdateNotifyIcon(Jobs);
            NotifyOfJobs(informList);

            // if the GUI is open, update the ListView
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                UpdateJobGui(Jobs);
            }
        }

        private void UpdateNotifyIcon(IList<CIJob> jobs)
        {
            if (jobs == default(IList<CIJob>) || !jobs.Any())
            {
                return;
            }

            if (jobs.Any(x => x.BuildStatus == BuildStatusType.Aborted || x.BuildStatus == BuildStatusType.Failed))
            {
                TaskbarNotifier.Icon = Resources.red_icon;
            }
            else if (jobs.Any(x => x.BuildStatus == BuildStatusType.Building))
            {
                TaskbarNotifier.Icon = Resources.yellow_icon;
            }
            else
            {
                TaskbarNotifier.Icon = Resources.green_icon;
            }
        }

        private void NotifyOfJobs(IList<CIJob> jobs)
        {
            jobs.ToList().ForEach(x => NotifyTask.NotifyQueue.Enqueue(x));
        }

        private void NotifyJob(CIJob job, int sleep)
        {
            TaskbarNotifier.ShowBalloonTip(sleep, job.Name, string.Format("{0} on {1}", job.BuildStatus, job.ServerName), ToolTipIcon.Info);
        }

        private void UpdateJobGui(IList<CIJob> jobs)
        {
            if (JobListView.InvokeRequired)
            {
                JobListView.Invoke((MethodInvoker)delegate { JobListView.Items.Clear(); });
            }
            else
            {
                JobListView.Items.Clear();
            }

            if (JobListView.InvokeRequired)
            {
                JobListView.Invoke((MethodInvoker)delegate { JobListView.SmallImageList = new ImageList() { ImageSize = new Size(1, 26) }; });
            }
            else
            {
                JobListView.SmallImageList = new ImageList() { ImageSize = new Size(1, 26) };
            }

            foreach (var job in jobs)
            {
                var item = new ListViewItem(new string[]
                    {
                        job.BuildId.ToString(),
                        job.Name,
                        job.ServerName,
                        job.TimeStamp.ToLongDateString() + " " + job.TimeStamp.ToLongTimeString(),
                        job.Duration + "secs",
                        job.BuildStatus.ToString()
                    });

                switch (job.BuildStatus)
                {
                    case BuildStatusType.Failed:
                        item.BackColor = Preferences.FAIL_COLOR;
                        break;

                    case BuildStatusType.Success:
                        item.BackColor = Preferences.SUCCESS_COLOR;
                        break;

                    case BuildStatusType.Unstable:
                        item.BackColor = Preferences.UNSTABLE_COLOR;
                        break;

                    case BuildStatusType.Building:
                        item.BackColor = Preferences.BUILDING_COLOR;
                        break;

                    case BuildStatusType.Disabled:
                    case BuildStatusType.NotBuilt:
                    case BuildStatusType.Unknown:
                        item.BackColor = Preferences.DISABLED_COLOR;
                        break;
                }

                item.ForeColor = Color.Black;

                if (JobListView.InvokeRequired)
                {
                    JobListView.Invoke((MethodInvoker)delegate { JobListView.Items.Add(item); });
                }
                else
                {
                    JobListView.Items.Add(item);
                }
            }
        }

        private void UpdateJob(CIJob jobToUpdate, CIJob job)
        {
            jobToUpdate.BuildId = job.BuildId;
            jobToUpdate.BuildStatus = job.BuildStatus;
            jobToUpdate.Duration = job.Duration;
            jobToUpdate.TimeStamp = job.TimeStamp;
            jobToUpdate.Url = job.Url;
        }

        private void CloseForm()
        {
            JobTask.Interrupt();
            NotifyTask.Interrupt();

            if (TaskbarNotifier != default(NotifyIcon))
            {
                TaskbarNotifier.Visible = false;
                TaskbarNotifier.Icon = null;
                TaskbarNotifier.Dispose();
            }
        }

        #endregion

    }
}
