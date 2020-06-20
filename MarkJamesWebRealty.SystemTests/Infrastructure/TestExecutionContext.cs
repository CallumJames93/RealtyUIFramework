using System;
using System.Collections.Generic;

namespace MarkJamesWebRealty.SystemTests.Infrastructure
{
    public class TestExecutionContext
    {
        public TestExecutionContext()
        {
            EnvironmentVariables = new EnvironmentVariableCollection();
        }

        public EnvironmentVariableCollection EnvironmentVariables { get; set; }
    }

    public class EnvironmentVariableCollection : Dictionary<string, string>
    {
        public EnvironmentVariableCollection()
        {
        }
    }
}
