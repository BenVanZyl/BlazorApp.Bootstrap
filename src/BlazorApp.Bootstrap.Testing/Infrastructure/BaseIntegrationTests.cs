using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.Bootstrap.Testing.Infrastrcuture
{
    [Collection("All Tests Complete")]
    public class BaseIntegrationTests : TestContext
    {
        public BaseIntegrationTests()
        {
            Factory = new TestAppFactory();
            Http = Factory.CreateClient();

            Services.AddSingleton(Http);
        }

        public TestAppFactory Factory { get; set; }
        public HttpClient Http { get; set; }

        public const string appJson = "application/json";
        public const string baseAdr = "https://localhost/";

    }
}
