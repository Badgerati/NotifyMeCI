/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using System;

namespace NotifyMeCI.Engine.Exceptions
{
    public class NMCIException : Exception
    {

        public NMCIException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}
