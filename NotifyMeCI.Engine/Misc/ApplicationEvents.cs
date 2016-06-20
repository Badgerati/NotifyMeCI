/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using System;
using System.IO;
using System.Reflection;

namespace NotifyMeCI.Engine.Misc
{
    public class ApplicationEvents
    {

        #region Lazy

        private static Lazy<ApplicationEvents> _lazy = new Lazy<ApplicationEvents>(() => new ApplicationEvents());
        public static ApplicationEvents Instance
        {
            get { return _lazy.Value; }
        }

        #endregion

        #region Events

        public void Start()
        {
            var assembly = Assembly.GetExecutingAssembly();

            if (assembly == default(Assembly))
            {
                throw new ApplicationException("Invalid assembly, cannot be null.");
            }

            var location = Path.GetDirectoryName(assembly.Location);
            IcarusClient.Instance.Initialise(location, true);
        }

        #endregion

    }
}
