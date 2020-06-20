using System;
namespace Infrastructure.Reporting.Contracts
{
    public interface ITestCaseReporterContext
    {
        public string LogPath { get; }
    }
}
