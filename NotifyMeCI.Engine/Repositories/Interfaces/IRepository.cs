/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories.Interfaces
{
    public interface IRepository<T> where T : IIcarusObject
    {

        string CollectionName { get; }
        string DataStore { get; }
        IIcarusCollection<T> Collection { get; }

        IList<T> All();

    }
}
