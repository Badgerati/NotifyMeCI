/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using System;

namespace NotifyMeCI.Injector
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InjectionInterfaceAttribute : Attribute
    {

        public Type Interface { get; private set; }

        public InjectionInterfaceAttribute(Type type)
        {
            if (!type.IsInterface)
            {
                throw new ArgumentException("Type passed for injection can only be an interface.");
            }

            Interface = type;
        }

    }
}
