﻿using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Common.Drivers
{
    /// <summary>
    /// Allows us to attach to a running Driver instance / Selenium Session
    /// </summary>
    public class AttachableRemoteWebDriver : RemoteWebDriver
    {
        public AttachableRemoteWebDriver(Uri remoteUri, DriverOptions options) : base(remoteUri, options)
        {
        }

        protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            var decoratedRemoteWebDriver = new RemoteDriverDecorator(this, "REMOTE", Directory.GetCurrentDirectory());
            decoratedRemoteWebDriver.AssertSeleniumVersionIsCompatible();

            return decoratedRemoteWebDriver.Execute(driverCommandToExecute, parameters, Executor);
        }

        private Response Executor(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            // We need access to base.Execute as there is no clear way to 'hook in' to the web driver architecture the way I need to
            return base.Execute(driverCommandToExecute, parameters);
        }
    }
}
