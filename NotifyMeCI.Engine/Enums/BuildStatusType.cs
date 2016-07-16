/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Managers;
using System;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Enums
{

    public enum BuildStatusType
    {
        Building = 0,
        Pending = 1,
        Failed = 2,
        Unstable = 3,
        Aborted = 4,
        Success = 5,
        Disabled = 6,
        NotBuilt = 7,
        Unknown = 8
    }


    public class BuildStatusTypeComparer : IComparer<BuildStatusType>
    {
        public int Compare(BuildStatusType x, BuildStatusType y)
        {
            var statuses = SettingManager.Instance.BuildStatuses;

            var xValue = statuses.ContainsKey(x)
                ? statuses[x].OrderPosition
                : (int)x;

            var yValue = statuses.ContainsKey(y)
                ? statuses[y].OrderPosition
                : (int)y;

            return xValue - yValue;
        }
    }

    public static class BuildStatusTypeHelper
    {
        public static BuildStatusType Parse(string value)
        {
            return (BuildStatusType)Enum.Parse(typeof(BuildStatusType), value, false);
        }
    }

}
