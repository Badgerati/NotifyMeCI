/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Injector;
using System;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories
{
    [InjectionInterface(typeof(ICIServerRepository))]
    public class CIServerRepository : Repository<CIServer>, ICIServerRepository
    {

        #region Public Methods

        public void Insert(CIServer server)
        {
            var now = DateTime.Now;
            server.CreateDate = now;
            server.LastUpdated = now;
            server.LastPollDate = now;
            server.NextPollDate = now;

            Collection.Insert(server);
        }

        public CIServer Update(CIServer server)
        {
            server.LastUpdated = DateTime.Now;

            return Collection.Update(server);
        }

        public CIServer Remove(CIServer server)
        {
            return Collection.Remove(server._id);
        }

        public CIServer FindByName(string name)
        {
            return Collection.Find("$[?(@.Name == '" + name + "')]");
        }

        public IList<CIServer> FindByNextPollDate()
        {
            return Collection.FindMany("NextPollDate", DateTime.Now, IcarusEqualityFilter.LessThanOrEqual);
        }

        #endregion

    }
}
