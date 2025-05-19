using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Net.Http;
using Xunit;

namespace BlazorApp.Bootstrap.Testing.Infrastrcuture
{
    [Collection("All Tests Complete")]
    public class BaseIntegrationTests : ICollectionFixture<AllTestsCompleteFixture>
    {
        public BaseIntegrationTests()
        {
            Factory = new TestAppFactory();
            Http = Factory.CreateClient();

            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            Driver = new EdgeDriver(options);
        }

        public TestAppFactory Factory { get; set; }
        public HttpClient Http { get; set; }

        public EdgeDriver Driver { get; set; }

    }
}
