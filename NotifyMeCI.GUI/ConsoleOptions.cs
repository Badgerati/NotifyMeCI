/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using CommandLine;
using CommandLine.Text;

namespace NotifyMeCI.GUI
{
    public class ConsoleOptions
    {

        [Option('m', "minimize", Required = false, DefaultValue = false, HelpText = "Specified whether the application should start minimized to teh System Tray.")]
        public bool Minimize { get; set; }

    }
}
