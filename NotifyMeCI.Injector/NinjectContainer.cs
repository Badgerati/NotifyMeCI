/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NotifyMeCI.Injector
{
    public class NinjectContainer : IDIContainer
    {

        #region Properties

        private IDictionary<Type, object> KernelCache;
        private IKernel Kernel;

        #endregion

        #region Constructor

        public NinjectContainer()
        {
            Kernel = new StandardKernel();
            KernelCache = new Dictionary<Type, object>();
            Initialise();
        }

        #endregion

        #region Public Helpers

        private void Initialise()
        {
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            var engine = ass.Where(x => new AssemblyName(x.FullName).Name == "NotifyMeCI.Engine").Single();

            var injections = engine.GetTypes().Where(x => x.IsDefined(typeof(InjectionInterfaceAttribute), true));

            foreach (var injection in injections)
            {
                var _interface = injection.GetCustomAttribute<InjectionInterfaceAttribute>(true);
                Bind(_interface.Interface, injection);
            }
        }

        public void Dispose()
        {
            if (Kernel != default(IKernel))
            {
                KernelCache.Clear();
                Kernel.Dispose();
            }
        }

        public void ClearCache()
        {
            KernelCache.Clear();
        }

        public void Bind(Type binder, Type bindee)
        {
            Kernel.Rebind(binder).To(bindee);
            KernelCache.Remove(binder);
        }

        public void Bind<T, U>() where U : T
        {
            Kernel.Rebind<T>().To<U>();
            KernelCache.Remove(typeof(T));
        }

        public T BindAndCache<T, U>(IDictionary<string, object> parameters) where U : T
        {
            Kernel.Rebind<T>().To<U>();
            KernelCache.Remove(typeof(T));
            return Get<T>(parameters, true);
        }

        public T BindAndCacheInstance<T>(T instance)
        {
            KernelCache.Remove(typeof(T));
            KernelCache.Add(typeof(T), instance);
            return instance;
        }

        public void Unbind<T>()
        {
            Kernel.Unbind<T>();
            KernelCache.Remove(typeof(T));
        }

        public T Get<T>(IDictionary<string, object> parameters = null, bool overwrite = false)
        {
            if (!overwrite && KernelCache.ContainsKey(typeof(T)))
            {
                return (T)KernelCache[typeof(T)];
            }

            var args = GetParameters(parameters);
            var obj = args == default(IParameter[])
                ? Kernel.Get<T>()
                : Kernel.Get<T>(args);

            KernelCache.Add(typeof(T), obj);
            return obj;
        }

        #endregion

        #region Private Helpers

        private IParameter[] GetParameters(IDictionary<string, object> parameters)
        {
            return parameters == default(IDictionary<string, object>)
                ? default(IParameter[])
                : parameters.Select(x => new ConstructorArgument(x.Key, x.Value)).ToArray();
        }

        #endregion

    }
}
