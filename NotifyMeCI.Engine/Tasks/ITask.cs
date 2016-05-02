/*
Notify Me CI is designed to be an awesome CI desktop notifier.

Copyright (c) 2016, Matthew Kelly (Badgerati)
Company: Cadaeic Studios
License: MIT (see LICENSE for details)
 */

namespace NotifyMeCI.Engine.Tasks
{
    public interface ITask
    {

        bool IsInterrupted { get; }

        void Interrupt();
        void Run();
        void CoreLogic();

    }
}
