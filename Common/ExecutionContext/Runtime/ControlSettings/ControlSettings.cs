﻿using Common.ExecutionContext.Contracts;

namespace Common.ExecutionContext.Runtime.ControlSettings
{
    public class ControlSettings : IControlSettings, ICleanse
    {
        public ControlSettings()
        {
            PollingTimeInMilliseconds = 250;
            WaitUntilTimeoutInSeconds = 30;
            AttachToExistingSessionIfItExists = false;
        }

        public int PollingTimeInMilliseconds { get; set; }
        public int WaitUntilTimeoutInSeconds { get; set; }
        public bool AttachToExistingSessionIfItExists { get; set; }

        public void Cleanse()
        {
        }
    }
}
