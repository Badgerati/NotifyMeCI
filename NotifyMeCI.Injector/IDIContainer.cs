/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using System;
using System.Collections.Generic;

namespace NotifyMeCI.Injector
{
    public interface IDIContainer : IDisposable
    {

        void ClearCache();
        void Bind(Type binder, Type bindee);
        void Bind<T, U>() where U : T;
        T BindAndCache<T, U>(IDictionary<string, object> parameters) where U : T;
        T BindAndCacheInstance<T>(T instance);
        void Unbind<T>();
        T Get<T>(IDictionary<string, object> parameters = null, bool overwrite = false);

    }
}
