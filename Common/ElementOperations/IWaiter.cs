using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Common.ElementOperations.Contracts
{
    public interface IWaiter
    {
        void AssertThatEventually(Action<IWebDriver> callback);
        void AssertThatEventually(Func<IWebDriver, bool> callback);
    }
}
