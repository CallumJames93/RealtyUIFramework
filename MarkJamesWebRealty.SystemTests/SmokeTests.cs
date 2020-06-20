using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkJamesWebRealty.SystemTests
{
    [TestClass]
    public class SmokeTests : SeleniumTestBase
    {
        protected override string BaseUrl => DriverSession.EnvironmentSettings.BaseUrl;


        [TestMethod]
        public void SomeTestGoHere()
        {
        }
    }
}
