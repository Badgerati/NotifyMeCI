/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Objects;
using NotifyMeCI.Engine.Repositories.Interfaces;
using NotifyMeCI.Injector;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using NotifyMeCI.Engine.Servers;
using System;

namespace NotifyMeCI.Engine.Tasks
{
    public class JobTask : ITask
    {

        #region Repositories

        private ICIServerRepository CIServerRepository
        {
            get { return DIContainer.Instance.Get<ICIServerRepository>(); }
        }

        #endregion

        #region Delegates

        public delegate void OnJobUpdate(IList<CIJob> jobs);

        #endregion

        #region Fields

        private OnJobUpdate JobHandler = null;
        private bool Interrupted = false;
        private bool IsFirstRun = false;

        #endregion

        #region Constructor

        public JobTask(OnJobUpdate jobHandler)
        {
            JobHandler = jobHandler;
            IsFirstRun = true;
        }

        #endregion

        #region Public Helpers

        public void Interrupt()
        {
            Interrupted = true;
        }

        public void Run()
        {
            while (!Interrupted)
            {
                // get all the servers that need updating
                var servers = IsFirstRun
                    ? CIServerRepository.All()
                    : CIServerRepository.FindByNextPollDate();

                if (servers != default(IList<CIServer>) && servers.Any())
                {
                    // only the servers that are active
                    servers = servers.Where(x => x.Enabled).ToList();
                    var allJobs = new List<CIJob>();

                    // get each job from each server
                    for (var i = 0; i < servers.Count; i++)
                    {
                        if (Interrupted)
                        {
                            break;
                        }

                        var process = CIServerFactory.Instance.Get(servers[i].ServerType);

                        var jobs = process.GetJobs(servers[i]);
                        if (jobs == default(IList<CIJob>))
                        {
                            continue;
                        }

                        // add the jobs to be returned
                        allJobs.AddRange(jobs);

                        // update the servers polling
                        if (!IsFirstRun)
                        {
                            servers[i].LastPollDate = servers[i].NextPollDate;
                            servers[i].NextPollDate = DateTime.Now.AddSeconds(servers[i].PollInterval);
                            CIServerRepository.Update(servers[i]);
                        }
                    }

                    // inform the UI of the jobs
                    if (!Interrupted && JobHandler != null)
                    {
                        JobHandler(allJobs);
                    }

                    if (IsFirstRun)
                    {
                        IsFirstRun = false;
                    }
                }

                // sleep for 10 secs to reduce load
                if (!Interrupted)
                {
                    Thread.Sleep(10000);
                }
            }
        }

        #endregion

    }
}
