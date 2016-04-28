/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using System;

namespace NotifyMeCI.Engine.Servers
{
    public class CIServerFactory
    {

        #region Lazy

        private static Lazy<CIServerFactory> _lazy = new Lazy<CIServerFactory>(() => new CIServerFactory());
        public static CIServerFactory Instance
        {
            get { return _lazy.Value; }
        }

        #endregion

        #region Public Helpers

        public ICIServer Get(CIServerType serverType)
        {
            switch (serverType)
            {
                case CIServerType.Jenkins:
                    return new JenkinsCIServer();

                case CIServerType.AppVeyor:
                    return new AppVeyorCIServer();

                case CIServerType.TravisCI:
                    return new TravisCIServer();

                default:
                    throw new ArgumentException("Unexpected server type passed: " + serverType);
            }
        }

        #endregion

    }
}
