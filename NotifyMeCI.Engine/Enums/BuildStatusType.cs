/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

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

    public class BuildStatusComparer : IComparer<BuildStatusType>
    {
        private readonly bool _abortedEqualsFailed;

        public BuildStatusComparer(bool AbortedEqualsFailed)
        {
            _abortedEqualsFailed = AbortedEqualsFailed;
        }

        public int Compare(BuildStatusType x, BuildStatusType y)
        {
            if (x == BuildStatusType.Aborted && !_abortedEqualsFailed)
                x++;
            else if (x == BuildStatusType.Success && !_abortedEqualsFailed)
                x--;

            if (y == BuildStatusType.Aborted && !_abortedEqualsFailed)
                y++;
            else if (y == BuildStatusType.Success && !_abortedEqualsFailed)
                y--;

            return x - y;
        }
    }
}
