/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using System;

namespace NotifyMeCI.Injector
{
    public class DIContainer : IDisposable
    {

        #region Properties

        public static Lazy<DIContainer> _lazy = new Lazy<DIContainer>(() => new DIContainer());
        public static IDIContainer Instance
        {
            get { return _lazy.Value.Container; }
            set { _lazy.Value.Container = value; }
        }

        public IDIContainer Container = default(IDIContainer);

        #endregion

        #region Constructor

        private DIContainer()
        {
            Container = new NinjectContainer();
        }

        #endregion

        #region Public Helpers

        public void Dispose()
        {
            if (Container != default(IDIContainer))
            {
                Container.Dispose();
            }
        }

        #endregion


    }
}
