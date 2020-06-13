using System;
using Common.ExecutionContext.Contracts;

namespace Common.ExecutionContext.Runtime.EnvironmentSettings
{
    public class EnvironmentSettings : ICleanse
    {
        public string BaseUrl { get; set; }

        public void Cleanse()
        {
            if (BaseUrl == null) BaseUrl = "http://localhost/you-need-to-set-environment-base-url";
        }
    }
}
