/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Enums;
using NotifyMeCI.Engine.Objects;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Repositories.Interfaces
{
    public interface IBuildStatusRepository : IRepository<BuildStatus>
    {

        void Insert(BuildStatus buildStatus);
        BuildStatus Update(BuildStatus buildStatus);
        IList<BuildStatus> UpdateMany(IList<BuildStatus> buildStatuses);
        BuildStatus FindByType(BuildStatusType type);

    }
}
