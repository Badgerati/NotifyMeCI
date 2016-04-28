/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

using NotifyMeCI.Engine.Objects;
using System.Collections.Concurrent;
using System.Threading;

namespace NotifyMeCI.Engine.Tasks
{
    public class NotifyTask : ITask
    {

        #region Properties

        private ConcurrentQueue<CIJob> _notifyQueue;
        public ConcurrentQueue<CIJob> NotifyQueue
        {
            get { return _notifyQueue; }
        }

        private CIJob _currentNotifyJob = default(CIJob);
        public CIJob CurrentNotifyJob
        {
            get { return _currentNotifyJob; }
        }

        #endregion

        #region Delegates

        public delegate void OnJobNotify(CIJob job, int sleep);

        #endregion

        #region Fields

        private OnJobNotify JobHandler = null;
        private bool Interrupted = false;
        private int SleepTime = 2000;

        #endregion

        #region Constructor

        public NotifyTask(OnJobNotify jobHandler)
        {
            JobHandler = jobHandler;
            _notifyQueue = new ConcurrentQueue<CIJob>();
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
                if (_notifyQueue != default(ConcurrentQueue<CIJob>) && _notifyQueue.Count > 0)
                {
                    var job = default(CIJob);
                    if (_notifyQueue.TryDequeue(out job) && !Interrupted && JobHandler != null)
                    {
                        _currentNotifyJob = job;
                        JobHandler(job, SleepTime);
                    }
                }

                if (!Interrupted)
                {
                    Thread.Sleep((int)(SleepTime * 2.5));
                }
            }
        }

        #endregion

    }
}