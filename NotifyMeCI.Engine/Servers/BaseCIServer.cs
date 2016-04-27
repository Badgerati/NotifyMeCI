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

namespace NotifyMeCI.Engine.Servers
{
    public class BaseCIServer : ICIServer
    {

        #region Public Helpers

        public virtual IList<CIJob> GetJobs(CIServer server)
        {
            return default(IList<CIJob>);
        }

        #endregion

        #region Protected Helpers

        protected int GetInt(object value)
        {
            if (value == default(object))
            {
                return 0;
            }

            return int.Parse(value.ToString(), CultureInfo.InvariantCulture);
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

            return long.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }

        protected DateTime GetDateTime(object value)
        {
            if (value == default(object))
            {
                return DateTime.MinValue;
            }

            return DateTime.Parse(value.ToString());
        }

        #endregion

    }
}
