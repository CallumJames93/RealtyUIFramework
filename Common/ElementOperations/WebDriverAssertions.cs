﻿using Common.ElementOperations.Contracts;
using Common.ExecutionContext.Runtime.ControlSettings;
using OpenQA.Selenium;
using System;
using System.Linq;


namespace Common.ElementOperations
{
    public class WebDriverAssertions : IWebDriverAssertions
    {
        private readonly IDecoratedWebDriver _webDriver;
        private readonly IControlSettings _controlSettings;

        public WebDriverAssertions(IDecoratedWebDriver webDriver, IControlSettings controlSettings)
        {
            _webDriver = webDriver;
            _controlSettings = controlSettings;
        }

        public IWebElement Click(By locator)
        {
            return Click(locator, because: $"{typeof(IWebDriverAssertions).Name}.Click({locator})");
        }

        public IWebElement Click(By locator, string because)
        {
            IWebElement element = default;

            AssertThatEventually(driver =>
            {
                element = AssertExactlyOneElementExists(_webDriver, locator);

                element.Click();
            });

            return element;
        }

        private IWebElement AssertExactlyOneElementExists(IDecoratedWebDriver webDriver, By locator)
        {
            var elements = webDriver.FindElements(locator);
            if (elements.Count() == 0) throw new NotFoundException($"The element {locator} could not be found. ");
            if (elements.Count() > 1) throw new NotFoundException($"The element {locator} was found {elements.Count()} times instead of exactly once. ");

            return elements.Single();
        }

        /// <summary>
        /// Wait until the expected callback DOES NOT throw an exception. 
        /// The callback usually contains one or more assertions. 
        /// </summary>
        /// <param name="callback"></param>
        private void AssertThatEventually(Action<IDecoratedWebDriver> callback)
        {
            if (null == callback) throw new System.ArgumentNullException(nameof(callback));

            DateTime endMatch = DateTime.Now.AddSeconds(_controlSettings.WaitUntilTimeoutInSeconds);
            Exception lastException = default(Exception);

            do
            {
                try
                {
                    callback(_webDriver);
                    return;
                }
                catch (Exception ex)
                {
                    lastException = ex;
                }

                System.Threading.Thread.Sleep(_controlSettings.PollingTimeInMilliseconds);

            } while (DateTime.Now < endMatch);

            throw lastException;
        }
    }
}
