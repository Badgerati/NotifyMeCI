/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using System;
using System.Reflection;
using System.Windows.Forms;

namespace NotifyMeCI.GUI
{
    public static class Logger
    {

        public static string Version
        {
            get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); }
        }


        public static void ShowErrorMessage(string message, string title)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void ShowExceptionMessage(string message, Exception exception, string title)
        {
            MessageBox.Show(
                string.Format("{0}{1}{1}{2}", message, Environment.NewLine, exception.Message),
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

    }
}
