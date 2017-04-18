/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using NotifyMeCI.Engine.Enums;
using System;

namespace NotifyMeCI.Engine.Objects
{
    public class CIServer : IcarusObject
    {

        public CIServerType ServerType { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int PollInterval { get; set; }
        public bool CurrentlyPolling { get; set; }
        public string ApiToken { get; set; }
        public bool Enabled { get; set; }
        public int DurationThreshold { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime LastPollDate { get; set; }
        public DateTime NextPollDate { get; set; }

    }
}
