using BlazorApp.Bootstrap.Testing.Infrastrcuture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading.Tasks;
using Xunit;

namespace BlazorApp.Bootstrap.Testing
{
    [TestClass]
    public class EdgeDriverTest : BaseIntegrationTests
    {
        // In order to run the below test(s), 
        // please follow the instructions from https://docs.microsoft.com/en-us/microsoft-edge/webdriver-chromium
        // to install Microsoft Edge WebDriver.

        //private EdgeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            //// Initialize edge driver 
            //var options = new EdgeOptions
            //{
            //    PageLoadStrategy = PageLoadStrategy.Normal
            //};
            //_driver = new EdgeDriver(options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            Driver.Url = "https://www.bing.com";
            Assert.AreEqual("Search - Microsoft Bing", Driver.Title);
        }

        [TestMethod]
        public async Task HomePageOpenSuccessTest()
        {
            Driver.Url = Http.BaseAddress.ToString();

        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            Driver.Quit();
        }
    }
}
