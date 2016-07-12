/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Managers;
using System;
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

        #endregion

    }
}
