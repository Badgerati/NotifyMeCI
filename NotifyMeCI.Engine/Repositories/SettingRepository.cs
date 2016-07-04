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
using System.Linq;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories
{
    [InjectionInterface(typeof(ISettingRepository))]
    public class SettingRepository : ISettingRepository
    {

        #region Properties

        private const string _collectionName = "Setting";
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

        public void Insert(Setting setting)
        {
            setting.LastUpdated = DateTime.Now;

            IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<Setting>(_collectionName)
                .Insert(setting);
        }

        public Setting Update(Setting setting)
        {
            return UpdateMany(new List<Setting>(1) { setting }).FirstOrDefault();
        }

        public IList<Setting> UpdateMany(IList<Setting> settings)
        {
            var now = DateTime.Now;
            settings.ToList().ForEach(x => x.LastUpdated = now);

            var newSettings = settings.Where(x => x._id == 0).ToArray();
            var oldSettings = settings.Where(x => x._id > 0).ToArray();

            var collection = IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<Setting>(_collectionName);

            var oldUpdatedSettings = collection.UpdateMany(oldSettings) ?? new List<Setting>();
            var newUpdatedSettings = collection.InsertMany(newSettings) ?? new List<Setting>();

            oldUpdatedSettings.ToList().AddRange(newUpdatedSettings);
            return oldUpdatedSettings;
        }

        public Setting Remove(Setting setting)
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<Setting>(_collectionName)
                .Remove(setting._id);
        }

        public IList<Setting> All()
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<Setting>(_collectionName)
                .All();
        }

        public Setting FindByName(string name)
        {
            return IcarusClient.Instance
                .GetDataStore(_dataStore)
                .GetCollection<Setting>(_collectionName)
                .Find("$[?(@.Name == '" + name + "')]");
        }

        #endregion

    }
}
