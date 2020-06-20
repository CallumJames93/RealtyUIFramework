using Common.ExecutionContext.Contracts;
using Infrastructure.ExecutionContext.Runtime.InstrumentSettings.Contracts;

namespace Infrastructure.ExecutionContext.Runtime.InstrumentSettings
{
    /// <summary>
    /// Placeholder for controlling things such as: reporting and logging storage. 
    /// </summary>
    public class InstrumentationSettings : IInstrumentationSettings, ICleanse
    {
        public InstrumentationSettings()
        {

        }

        public bool LogFilePerTest { get; set; }
        public void Cleanse()
        {
        }
    }
}
