using OpenQA.Selenium;

namespace Common.ElementOperations.Contracts
{
    /// <summary>
    /// Interface made available to all tests view the WebDriver property.
    /// </summary>
    public interface IDecoratedWebDriver : IWebDriver
    {
        IWebDriverAssertions Assert { get; }
    }
}
