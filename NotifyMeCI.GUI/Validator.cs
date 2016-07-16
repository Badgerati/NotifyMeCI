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
using System.Net;
using NotifyMeCI.Engine.Servers;
using NotifyMeCI.Engine;

namespace NotifyMeCI.GUI
{
    public static class Validator
    {

        #region Repositories

        private static ICIServerRepository CIServerRepository
        {
            get { return DIContainer.Instance.Get<ICIServerRepository>(); }
        }

        #endregion

        #region Helpers

        public static string ValidateServerValues(string serverType, string name, string url, int poll, string apiToken, bool uniqueName = true)
        {
            try
            {
                // check server type
                var _serverType = default(CIServerType);
                if (!Enum.TryParse<CIServerType>(serverType, true, out _serverType))
                {
                    return string.Format("Invalid Server Type selected when adding new server: '{0}'", serverType);
                }

                // check name is unique
                if (string.IsNullOrWhiteSpace(name))
                {
                    return string.Format("Invalid Server Name supplied: '{0}'", name);
                }

                if (uniqueName && CIServerRepository.FindByName(name) != default(CIServer))
                {
                    return string.Format("Server with name '{0}' already exists. Server names must be unique.", name);
                }

                // check polling value
                if (poll < Preferences.MIN_POLL_TIME)
                {
                    return string.Format("Polling interval must be greater than or equal to {0} seconds, but got: {1}", Preferences.MIN_POLL_TIME, poll);
                }

                // check API token
                if (!string.IsNullOrWhiteSpace(apiToken))
                {
                    apiToken = apiToken.Trim();
                }

                switch (_serverType)
                {
                    case CIServerType.AppVeyor:
                        if (string.IsNullOrWhiteSpace(apiToken))
                        {
                            return string.Format("Invalid API Token supplied: '{0}'", apiToken);
                        }
                        break;
                }

                // check URL is reachable
                if (string.IsNullOrWhiteSpace(url))
                {
                    return string.Format("Invalid Server URL when adding new server: '{0}'", url);
                }

                var server = CIServerFactory.Instance.Get(_serverType);
                var error = string.Empty;

                if (!server.ValidateUrl(url, apiToken, out error))
                {
                    return error;
                }
            }
            catch (Exception ex)
            {
                return string.Format("There was a fatal issue when validating the server information:{0}{0}{1}", Environment.NewLine, ex.Message);
            }

            return string.Empty;
        }

        #endregion

    }
}
