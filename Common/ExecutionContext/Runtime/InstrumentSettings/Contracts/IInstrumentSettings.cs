using System;
namespace Infrastructure.ExecutionContext.Runtime.InstrumentSettings.Contracts
{
    public interface IInstrumentationSettings
    {
        bool LogFilePerTest { get; }
    }
}
