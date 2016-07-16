/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Injector;
using System;
using System.Linq;
using System.Collections.Generic;
using NotifyMeCI.Engine.Enums;
using NotifyMeCI.Engine.Objects;

namespace NotifyMeCI.Engine.Repositories
{
    [InjectionInterface(typeof(IBuildStatusRepository))]
    public class BuildStatusRepository : Repository<BuildStatus>, IBuildStatusRepository
    {

        #region Public Methods

        public void Insert(BuildStatus buildStatus)
        {
            buildStatus.LastUpdated = DateTime.Now;
            Collection.Insert(buildStatus);
        }

        public BuildStatus Update(BuildStatus buildStatus)
        {
            return UpdateMany(new List<BuildStatus>(1) { buildStatus }).FirstOrDefault();
        }

        public IList<BuildStatus> UpdateMany(IList<BuildStatus> buildStatuses)
        {
            var now = DateTime.Now;
            buildStatuses.ToList().ForEach(x => x.LastUpdated = now);

            var newBuildStatuses = buildStatuses.Where(x => x._id == 0).ToArray();
            var oldBuildStatuses = buildStatuses.Where(x => x._id > 0).ToArray();

            var oldUpdatedBuildStatuses = Collection.UpdateMany(oldBuildStatuses) ?? new List<BuildStatus>();
            var newUpdatedBuildStatuses = Collection.InsertMany(newBuildStatuses) ?? new List<BuildStatus>();

            oldUpdatedBuildStatuses.ToList().AddRange(newUpdatedBuildStatuses);
            return oldUpdatedBuildStatuses;
        }

        public BuildStatus FindByType(BuildStatusType type)
        {
            return Collection.Find("$[?(@.BuildStatusType == '" + type + "')]");
        }

        #endregion

    }
}
