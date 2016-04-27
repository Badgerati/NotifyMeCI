/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Objects;
using System.Collections.Generic;

namespace NotifyMeCI.Engine.Servers
{

    public interface ICIServer
    {

        IList<CIJob> GetJobs(CIServer server);

    }

}
