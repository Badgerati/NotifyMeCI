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
    public class CIServerRepository : ICIServerRepository
    {

        #region Properties

        private const string _collectionName = "CIServer";
        public string CollectionName
        {
            get { return _collectionName; }
        }

        private const string _dataStore = "NotifyMeCI";
        public string DataStore
        {
            get { return _dataStore; }
        }

        #endregion

        #region Public Methods

        public void Insert(CIServer server)
        {
            var now = DateTime.Now;
            server.CreateDate = now;
            server.LastUpdated = now;
            server.LastPollDate = now;
            server.NextPollDate = now;

            IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<CIServer>(_collectionName)
                .Insert(server);
        }

        public CIServer Update(CIServer server)
        {
            server.LastUpdated = DateTime.Now;

            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<CIServer>(_collectionName)
                .Update(server);
        }

        public CIServer Remove(CIServer server)
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<CIServer>(_collectionName)
                .Remove(server._id);
        }

        public IList<CIServer> All()
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<CIServer>(_collectionName)
                .All();
        }

        public CIServer FindByName(string name)
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<CIServer>(_collectionName)
                .Find("$[?(@.Name == '" + name + "')]");
        }

        public IList<CIServer> FindByNextPollDate()
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<CIServer>(_collectionName)
                .FindMany("NextPollDate", DateTime.Now, IcarusEqualityFilter.LessThanOrEqual);
        }

        #endregion

    }
}
