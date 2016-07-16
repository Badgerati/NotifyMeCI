/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using NotifyMeCI.Engine.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace NotifyMeCI.Engine.Objects
{
    public class BuildStatus : IcarusObject
    {
        public BuildStatusType BuildStatusType { get; set; }
        public int OrderPosition { get; set; }
        public int ColorA { get; set; }
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
        public bool Visible { get; set; }
        public DateTime LastUpdated { get; set; }
    }


    public static class BuildStaticExtensions
    {
        public static bool IsVisible(this IDictionary<BuildStatusType, BuildStatus> src, BuildStatusType statusType)
        {
            return src.ContainsKey(statusType)
                ? src[statusType].Visible
                : true;
        }

        public static Color MapColor(this IDictionary<BuildStatusType, BuildStatus> src, BuildStatusType statusType)
        {
            if (src.ContainsKey(statusType) && src[statusType].ColorA != 0)
            {
                var status = src[statusType];
                return Color.FromArgb(status.ColorA, status.ColorR, status.ColorG, status.ColorB);
            }

            switch (statusType)
            {
                case BuildStatusType.Failed:
                    return Preferences.FAIL_COLOR;

                case BuildStatusType.Success:
                    return Preferences.SUCCESS_COLOR;

                case BuildStatusType.Unstable:
                    return Preferences.UNSTABLE_COLOR;

                case BuildStatusType.Building:
                case BuildStatusType.Pending:
                    return Preferences.BUILDING_COLOR;

                case BuildStatusType.Aborted:
                    return Preferences.FAIL_COLOR;

                case BuildStatusType.Disabled:
                case BuildStatusType.NotBuilt:
                case BuildStatusType.Unknown:
                default:
                    return Preferences.DISABLED_COLOR;
            }
        }
    }

}
