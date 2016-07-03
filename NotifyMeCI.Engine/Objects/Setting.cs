/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using System;

namespace NotifyMeCI.Engine.Objects
{
    public class Setting : IcarusObject
    {

        public string Name { get; set; }
        public bool BooleanValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public decimal DecimalValue { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
