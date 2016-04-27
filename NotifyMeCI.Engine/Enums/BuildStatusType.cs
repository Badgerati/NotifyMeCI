/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

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

}
