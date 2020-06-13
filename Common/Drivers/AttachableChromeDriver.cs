

using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Common.Drivers
{
    /// <summary>
    /// Allows us to attach to a running chrome driver instance
    /// </summary>
    public class AttachableChromeDriver : ChromeDriver
    {
        public AttachableChromeDriver(ChromeOptions options) : base(options)
        {

        }

        protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            return base.Execute(driverCommandToExecute, parameters);
        }

        private Response Executor(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            return base.Execute(driverCommandToExecute, parameters);
        }
    }
}
