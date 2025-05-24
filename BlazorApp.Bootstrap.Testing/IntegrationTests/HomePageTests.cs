using BlazorApp.Bootstrap.Testing.Infrastrcuture;
using System.Threading.Tasks;
using Xunit;

namespace BlazorApp.Bootstrap.Testing.IntegrationTests
{
    public class HomePageTests: BaseIntegrationTests
    {
        [Fact]
        public async Task HomePageOpenSuccessTest()
        {
            Driver.Url = Http.BaseAddress.ToString();
            
        }
    }
}
