/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Injector;
using System;
using System.Windows.Forms;

namespace NotifyMeCI.GUI
{
    public partial class EditServerForm : Form
    {

        #region Repositories

        private ICIServerRepository CIServerRepository
        {
            get { return DIContainer.Instance.Get<ICIServerRepository>(); }
        }

        #endregion

        #region Fields

        private CIServer _server = default(CIServer);

        #endregion

        #region Constructor

        public EditServerForm(CIServer server)
        {
            InitializeComponent();

            _server = server;
            if (_server == default(CIServer))
            {
                Close();
            }

            Text = string.Format("Edit Server - {0}", server.Name);

            ServerTypeDdl.SelectedItem = _server.ServerType.ToString();
            ServerNameTxt.Text = _server.Name;
            ServerUrlTxt.Text = _server.Url;
            ServerApiTokenTxt.Text = _server.ApiToken;
            ServerPollNum.Value = _server.PollInterval;
            ServerEnabledChk.Checked = _server.Enabled;
        }

        #endregion

        #region Events

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
                ServerApiTokenTxt.Visible = true;
                ServerApiTokenLbl.Visible = true;
                return;
            }

            switch (serverType)
            {
                case CIServerType.TravisCI:
                    ServerApiTokenTxt.Visible = false;
                    ServerApiTokenLbl.Visible = false;
                    break;

                default:
                    ServerApiTokenTxt.Visible = true;
                    ServerApiTokenLbl.Visible = true;
                    break;
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            var errorTitle = "Error Updating Server";

            try
            {
                // validate server info
                var selectedItem = ServerTypeDdl.SelectedItem;
                var serverTypeTxt = selectedItem == default(object)
                    ? string.Empty
                    : selectedItem.ToString();

                var error = Validator.ValidateServerValues(serverTypeTxt, ServerNameTxt.Text, ServerUrlTxt.Text, (int)ServerPollNum.Value, ServerApiTokenTxt.Text, false);
                if (!string.IsNullOrWhiteSpace(error))
                {
                    Logger.ShowErrorMessage(error, errorTitle);
                    return;
                }

                // get server type
                var serverType = default(CIServerType);
                Enum.TryParse<CIServerType>(serverTypeTxt, true, out serverType);

                // update server
                _server.ServerType = serverType;
                _server.Name = ServerNameTxt.Text;
                _server.Url = ServerUrlTxt.Text;
                _server.PollInterval = (int)ServerPollNum.Value;
                _server.Enabled = ServerEnabledChk.Checked;
                _server.ApiToken = ServerApiTokenTxt.Visible ? ServerApiTokenTxt.Text : string.Empty;

                CIServerRepository.Update(_server);

                // inform
                MessageBox.Show("Server updated.", "Update Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.ShowExceptionMessage("There was a fatal issue updating the server:", ex, errorTitle);
                return;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                string.Format("Are you should you would like to delete the server: {0}", _server.Name),
                "Delete Server",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    CIServerRepository.Remove(_server);
                    MessageBox.Show("Server deleted.", "Delete Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Logger.ShowExceptionMessage("There was an issue deleting the server:", ex, "Error");
                }
            }
        }

        #endregion

    }
}
