using System;
using Common.ElementOperations.Contracts;
using Common.ExecutionContext.Runtime.ControlSettings;
using Common.ExecutionContext.Runtime.EnvironmentSettings;

namespace Common.SessionManagement.Contracts
{
    public interface IDriverSession
    {
            EnvironmentSettings EnvironmentSettings { get; }
            IControlSettings ControlSettings { get; }
            IWaiter Waiter { get; }
            IDecoratedWebDriver WebDriver { get; }
    }
}
