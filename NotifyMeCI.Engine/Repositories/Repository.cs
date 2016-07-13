/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using Icarus.Core;
using NotifyMeCI.Engine.Repositories.Interfaces;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories
{
    public class Repository<T> : IRepository<T> where T : IIcarusObject
    {

        #region Properties

        public IIcarusCollection<T> Collection
        {
            get
            {
                return IcarusClient.Instance.GetDataStore(DataStore).GetCollection<T>(CollectionName);
            }
        }

        public virtual string CollectionName
        {
            get
            {
                return typeof(T).Name;
            }
        }

        public virtual string DataStore
        {
            get
            {
                return "NotifyMeCI";
            }
        }

        #endregion

        #region Public Methods

        public IList<T> All()
        {
            return Collection.All();
        }

        #endregion

    }
}
