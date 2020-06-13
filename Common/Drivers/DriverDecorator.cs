using System;
using OpenQA.Selenium.Remote;

namespace Common.Drivers
{
    public class DriverDecorator
    {
        public const string IMPLEMENTATION_NOTE = "This implementation is for Selenium 3.141 you may need to update and add your custom adaptor";

        private readonly RemoteWebDriver _remoteWebDriver;
        private readonly string _browserName;
        private readonly string _targetFolder;

        public DriverDecorator(RemoteWebDriver remoteWebDriver, string browserName, string targetFolder)
        {
            if (null == remoteWebDriver) throw new ArgumentNullException(nameof(remoteWebDriver));
            if (null == browserName) throw new ArgumentNullException(nameof(browserName));
            if (null == targetFolder) throw new ArgumentNullException(nameof(targetFolder));

            _remoteWebDriver = remoteWebDriver;
            _browserName = browserName;
            _targetFolder = targetFolder;
        }

        public void AssertSeleniumVersionIsCompatible()
        {
            var seleniumVersion = typeof(RemoteWebDriver).Assembly.GetName().Version.ToString();
            if (seleniumVersion != "3.0.0.0" && seleniumVersion != "3.141.0.0")
            {
                throw new NotSupportedException($"{IMPLEMENTATION_NOTE}");
            }
        }

        public string GetRemoteServerUri()
        {
            var commandExecutor = GetCommandExecutor(_remoteWebDriver);

            var httpExecutorProperty = commandExecutor.GetType().GetProperty("HttpExecutor");
            if (null == httpExecutorProperty) throw new InvalidOperationException("remoteWebDriver.Command executor should exist check your selenium version");

            var executor = httpExecutorProperty.GetValue(commandExecutor);
            if (null == executor) throw new InvalidOperationException("executor should exist check your selenium version");

            var remoteServerUriField = executor.GetType().GetField("remoteServerUri", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (null == remoteServerUriField) throw new InvalidOperationException("remoteServerUriField.CommandExecutor should exist, check your selenium version");


            var remoteServerUri = remoteServerUriField.GetValue(executor);
            if (null == remoteServerUriField) throw new InvalidOperationException("remoteServerUriField.CommandExecutor should exist, check your selenium version");

            return remoteServerUri.ToString();
        }

        public void SetRemoteServerUri(string value)
        {
            var commandExecutor = GetCommandExecutor(_remoteWebDriver);

            var httpExecutorProperty = commandExecutor.GetType().GetProperty("HttpExecutor");
            if (null == httpExecutorProperty) throw new InvalidOperationException("remoteWebDriver.Command executor should exist check your selenium version");

            var executor = httpExecutorProperty.GetValue(commandExecutor);
            if (null == httpExecutorProperty) throw new InvalidOperationException("remoteWebDriver.Command executor should exist check your selenium version");

            var remoteServerUriField = executor.GetType().GetField("remoteServerUri", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (null == remoteServerUriField) throw new InvalidOperationException("remoteServerUriField.CommandExecutor should exist, check your selenium version");
        }

        private ICommandExecutor GetCommandExecutor (RemoteWebDriver remoteWebDriver)
        {
            var commandExecutorProperty = remoteWebDriver.GetType().GetProperty("CommandExecutor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (null == commandExecutorProperty) throw new InvalidOperationException($"remoteWebDriver.CommandExcutor property should exist");

            var commandExecutor = commandExecutorProperty.GetValue(remoteWebDriver) as ICommandExecutor;
            if (null == commandExecutorProperty) throw new InvalidOperationException($"remoteWebDriver.CommandExcutor property should exist");

            return commandExecutor;
        }
    }
}
