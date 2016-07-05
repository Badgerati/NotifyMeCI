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

        [Option('m', "minimize", Required = false, DefaultValue = false, HelpText = "Specify whether the application should start minimized to the System Tray.")]
        public bool Minimize { get; set; }

    }
}
