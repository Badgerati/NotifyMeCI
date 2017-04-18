/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using System;
using System.Drawing;

namespace NotifyMeCI.Engine
{
    public static class Preferences
    {

        public static readonly Color BUILDING_COLOR = Color.CadetBlue;
        public static readonly Color SUCCESS_COLOR = Color.LimeGreen;
        public static readonly Color FAIL_COLOR = Color.IndianRed;
        public static readonly Color UNSTABLE_COLOR = Color.LightGoldenrodYellow;
        public static readonly Color DISABLED_COLOR = Color.LightGray;

        public static readonly DateTime EPOCH_DATE = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public const int MIN_POLL_TIME = 10;
        public const int MIN_DURATION_THRESHOLD_TIME = 0;

        public const string GREEN_ICON = "green_icon.ico";
        public const string RED_ICON = "red_icon.ico";
        public const string YELLOW_ICON = "yellow_icon.ico";

    }
}
