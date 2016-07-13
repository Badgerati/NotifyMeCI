/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using NotifyMeCI.Engine.Managers;
using NotifyMeCI.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NotifyMeCI.GUI
{
    public partial class SettingsForm : Form
    {

        #region Fields

        private SettingManager _settings = SettingManager.Instance;

        #endregion

        #region Constructor

        public SettingsForm()
        {
            InitializeComponent();
            SetupBuildStatusTable();
            Initialise();
        }

        private void Initialise()
        {
            MinimizeChkBox.Checked = _settings.Minimize;
            AbortedEqualsFailedChkBox.Checked = _settings.AbortedEqualsFailed;
        }

        #endregion

        #region Events

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveBuildStatuses();
                _settings.Save();
                Close();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.ShowExceptionMessage("There was a fatal issue saving the settings:", ex, "Error Saving Settings");
                return;
            }
        }

        private void MinimizeChkBox_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Minimize = MinimizeChkBox.Checked;
        }

        private void AbortedEqualsFailedChkBox_CheckedChanged(object sender, EventArgs e)
        {
            _settings.AbortedEqualsFailed = AbortedEqualsFailedChkBox.Checked;
        }

        private void ColourBtn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (ColourPicker.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = ColourPicker.Color;
            }
        }

        #endregion

        #region Setup

        private void SetupBuildStatusTable()
        {
            // get all status enum values
            var statuses = Enum.GetNames(typeof(BuildStatusType));
            var rows = statuses.Length + 1;

            // setup the table size
            BuildStatusTable.RowCount = rows;
            BuildStatusTable.MaximumSize = new Size(BuildStatusTable.Width, 0);
            BuildStatusTable.AutoSize = true;

            // initialise the table's header
            var font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            BuildStatusTable.Controls.Add(new Label() { Text = "Status Type", Font = font }, 0, 0);
            BuildStatusTable.Controls.Add(new Label() { Text = "Order", Font = font }, 1, 0);
            BuildStatusTable.Controls.Add(new Label() { Text = "Colour", Font = font }, 2, 0);
            BuildStatusTable.Controls.Add(new Label() { Text = "Visible", Font = font }, 3, 0);

            // grab all build statuses that have actually been saved
            var buildStatuses = _settings.BuildStatuses;
            var buildStatus = default(BuildStatus);

            // setup the rest of the table
            for (var i = 1; i <= statuses.Length; i++)
            {
                BuildStatusTable.Controls.Add(new Label() { Text = statuses[i - 1], Margin = new Padding(0, 7, 0, 0) }, 0, i);

                if (buildStatuses.ContainsKey(BuildStatusTypeHelper.Parse(statuses[i - 1])))
                {
                    buildStatus = buildStatuses[BuildStatusTypeHelper.Parse(statuses[i - 1])];
                    BuildStatusTable.Controls.Add(new NumericUpDown() { Minimum = 0, Maximum = 100, Value = buildStatus.OrderPosition }, 1, i);

                    var colourBtn = new Button() { BackColor = Color.FromArgb(buildStatus.ColorA, buildStatus.ColorR, buildStatus.ColorG, buildStatus.ColorB) };
                    colourBtn.Margin = new Padding(0, 1, 0, 0);
                    colourBtn.Click += ColourBtn_Click;
                    BuildStatusTable.Controls.Add(colourBtn, 2, i);

                    BuildStatusTable.Controls.Add(new CheckBox() { Checked = buildStatus.Visible, Text = string.Empty, Margin = new Padding(20, 1, 0, 0) }, 3, i);
                }
                else
                {
                    BuildStatusTable.Controls.Add(new NumericUpDown() { Minimum = 0, Maximum = 100, Value = (i - 1) }, 1, i);

                    var colourBtn = new Button() { BackColor = Color.Transparent };
                    colourBtn.Margin = new Padding(0, 1, 0, 0);
                    colourBtn.Click += ColourBtn_Click;
                    BuildStatusTable.Controls.Add(colourBtn, 2, i);

                    BuildStatusTable.Controls.Add(new CheckBox() { Checked = true, Text = string.Empty, Margin = new Padding(20, 1, 0, 0) }, 3, i);
                }
            }
        }

        private void SaveBuildStatuses()
        {
            var statuses = new List<BuildStatus>(BuildStatusTable.RowCount - 1);

            for (var r = 1; r < BuildStatusTable.RowCount; r++)
            {
                var status = new BuildStatus();
                status.BuildStatusType = BuildStatusTypeHelper.Parse(BuildStatusTable.GetControlFromPosition(0, r).Text);
                status.OrderPosition = (int)((NumericUpDown)BuildStatusTable.GetControlFromPosition(1, r)).Value;
                status.Visible = ((CheckBox)BuildStatusTable.GetControlFromPosition(3, r)).Checked;

                var color = BuildStatusTable.GetControlFromPosition(2, r).BackColor;
                status.ColorA = color.A;
                status.ColorR = color.R;
                status.ColorG = color.G;
                status.ColorB = color.B;

                statuses.Add(status);
            }

            foreach (var status in statuses)
            {
                if (_settings.BuildStatuses.ContainsKey(status.BuildStatusType))
                {
                    var currentStatus = _settings.BuildStatuses[status.BuildStatusType];
                    currentStatus.ColorA = status.ColorA;
                    currentStatus.ColorR = status.ColorR;
                    currentStatus.ColorG = status.ColorG;
                    currentStatus.ColorB = status.ColorB;
                    currentStatus.OrderPosition = status.OrderPosition;
                    currentStatus.Visible = status.Visible;
                }
                else
                {
                    _settings.BuildStatuses.Add(status.BuildStatusType, status);
                }
            }
        }

        #endregion

    }
}
