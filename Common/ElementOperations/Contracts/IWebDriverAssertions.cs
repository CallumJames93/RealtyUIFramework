﻿using OpenQA.Selenium;

namespace Common.ElementOperations.Contracts
{
     /// <summary>
     /// All Assertions use an implementation similar to "ImplicitWait" - in other words: the operation 
     /// </summary>
     /// <remarks>
     /// </remarks>
    public interface IWebDriverAssertions
    {
        IWebElement Click(By locator);
        IWebElement Click(By locator, string because);
    }
}
