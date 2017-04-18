/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using System;

namespace NotifyMeCI.Engine.Objects
{
    public class CIJob
    {

        public CIServerType ServerType { get; set; }
        public string ServerName { get; set; }
        public string BuildId { get; set; }
        public int Duration { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public BuildStatusType BuildStatus { get; set; }

    }
}
