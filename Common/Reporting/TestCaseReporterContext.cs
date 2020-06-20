using System;
using Infrastructure.Reporting.Contracts;

namespace Infrastructure.Reporting
{
    public class TestCaseReporterContext : ITestCaseReporterContext
    {
        public TestCaseReporterContext(string logPath)
        {
            LogPath = logPath ?? throw new ArgumentNullException(nameof(logPath));
        }

        public string LogPath { get; }
    }
}
