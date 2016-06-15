/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

namespace NotifyMeCI.Engine.Servers
{
    public class BaseCIServer : ICIServer
    {

        #region Public Helpers

        public virtual IList<CIJob> GetJobs(CIServer server)
        {
            return default(IList<CIJob>);
        }

        public virtual bool ValidateUrl(string url, string token, out string error)
        {
            error = string.Empty;

            try
            {
                var request = WebRequest.Create(url);
                using (var response = request.GetResponse()) { }
                return true;
            }
            catch (Exception ex)
            {
                error = string.Format("Error connecting to Server URL provided:{0}{0}{1}", Environment.NewLine, ex.Message);
                return false;
            }
        }

        #endregion

        #region Protected Helpers

        protected string GetBase64String(string token)
        {
            var bytes = Encoding.UTF8.GetBytes(token);
            return Convert.ToBase64String(bytes);
        }

        protected int GetInt(object value)
        {
            if (value == default(object))
            {
                return 0;
            }

            var _value = 0;
            int.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out _value);
            return _value;
        }

        protected bool GetBool(object value)
        {
            if (value == default(object))
            {
                return false;
            }

            var _value = false;
            bool.TryParse(value.ToString(), out _value);
            return _value;
        }

        protected string GetString(object value)
        {
            if (value == default(object))
            {
                return string.Empty;
            }

            return value.ToString();
        }

        protected long GetLong(object value)
        {
            if (value == default(object))
            {
                return 0;
            }

            var _value = 0L;
            long.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out _value);
            return _value;
        }

        protected DateTime GetDateTime(object value)
        {
            if (value == default(object))
            {
                return DateTime.MinValue;
            }

            var _value = DateTime.MinValue;
            DateTime.TryParse(value.ToString(), out _value);
            return _value;
        }

        #endregion

    }
}
