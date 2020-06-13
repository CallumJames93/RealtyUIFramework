using System;
using Common.ExecutionContext.Runtime.BrowserSettings.Contracts;
using Common.ExecutionContext.Runtime.ControlSettings;
using Common.ExecutionContext.Runtime.DeviceSettings.Contracts;
using Common.ExecutionContext.Runtime.EnvironmentSettings;
using Common.ExecutionContext.Runtime.RemoteWebDriverSettings;
using Serilog;

namespace Common.SessionManagement.Contracts
{
    public interface IDriverSessionFactory
    {
        // TODO: Refactor - too many params
        IDriverSession Create(IDeviceProperties deviceProperties, IBrowserProperties properties, RemoteWebDriverSettings remoteWebDriverSettings, EnvironmentSettings environmentSettings, IControlSettings controlSettings, ILogger logger);
    }
}
