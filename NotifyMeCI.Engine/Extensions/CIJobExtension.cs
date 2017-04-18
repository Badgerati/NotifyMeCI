/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyMeCI.Engine.Extensions
{
    public static class CIJobExtension
    {

        #region Repositories

        private static ICIServerRepository CIServerRepository
        {
            get { return DIContainer.Instance.Get<ICIServerRepository>(); }
        }

        #endregion

        #region Helpers

        public static ToolTipIcon GetToolTipIcon(this CIJob job)
        {
            // build duration is over the threshold
            if (job.IsOverThreshold())
            {
                return ToolTipIcon.Warning;
            }

            // otherwise, duration is as expected
            switch (job.BuildStatus)
            {
                default:
                case BuildStatusType.Building:
                case BuildStatusType.Pending:
                case BuildStatusType.Success:
                case BuildStatusType.Disabled:
                case BuildStatusType.NotBuilt:
                case BuildStatusType.Unknown:
                    return ToolTipIcon.Info;

                case BuildStatusType.Failed:
                case BuildStatusType.Unstable:
                case BuildStatusType.Aborted:
                    return ToolTipIcon.Error;
            }
        }

        public static string GetToolTipText(this CIJob job)
        {
            return job.IsOverThreshold()
                ? string.Format("Taking longer than expected on {0}", job.ServerName)
                : string.Format("{0} on {1}", job.BuildStatus, job.ServerName);
        }

        public static bool IsOverThreshold(this CIJob job)
        {
            var server = CIServerRepository.FindByName(job.ServerName);
            return (job.BuildStatus == BuildStatusType.Building && job.Duration >= (server.DurationThreshold * 60));
        }

        #endregion

    }
}
