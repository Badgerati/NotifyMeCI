/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */
 
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Injector;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories
{
    [InjectionInterface(typeof(ISettingRepository))]
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {

        #region Public Methods

        public void Insert(Setting setting)
        {
            setting.LastUpdated = DateTime.Now;
            Collection.Insert(setting);
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

            var oldUpdatedSettings = Collection.UpdateMany(oldSettings) ?? new List<Setting>();
            var newUpdatedSettings = Collection.InsertMany(newSettings) ?? new List<Setting>();

            oldUpdatedSettings.ToList().AddRange(newUpdatedSettings);
            return oldUpdatedSettings;
        }

        public Setting Remove(Setting setting)
        {
            return Collection.Remove(setting._id);
        }

        public Setting FindByName(string name)
        {
            return Collection.Find("$[?(@.Name == '" + name + "')]");
        }

        #endregion

    }
}
