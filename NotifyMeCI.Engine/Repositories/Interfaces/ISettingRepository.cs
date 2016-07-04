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
    public interface ISettingRepository
    {

        string CollectionName { get; }
        string DataStore { get; }

        void Insert(Setting setting);
        Setting Update(Setting setting);
        IList<Setting> UpdateMany(IList<Setting> settings);
        Setting Remove(Setting setting);
        Setting FindByName(string name);
        IList<Setting> All();

    }
}
