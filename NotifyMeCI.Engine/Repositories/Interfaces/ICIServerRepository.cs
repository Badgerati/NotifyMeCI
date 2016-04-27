/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Objects;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories.Interfaces
{
    public interface ICIServerRepository
    {

        string CollectionName { get; }
        string DataStore { get; }

        void Insert(CIServer server);
        CIServer Update(CIServer server);
        CIServer Remove(CIServer server);
        CIServer FindByName(string name);
        IList<CIServer> FindByNextPollDate();
        IList<CIServer> All();

    }
}
