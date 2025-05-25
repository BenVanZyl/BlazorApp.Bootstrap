// Ignore Spelling: Nav Blazor App

using BlazorApp.Bootstrap.Ui.Components.Layout;
using BlazorApp.Bootstrap.Ui.Components.Pages;
using BlazorApp.Bootstrap.Testing.Infrastrcuture;
using Bunit;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Testing.IntegrationTests
{
    public class WebPagesTests : BaseIntegrationTests
    {
        [Fact]
        public void HomePageLoadTest()
        {
            // Arrange: render the Home.razor component
            var cut = RenderComponent<Home>();
            // Wait for the component to finish rendering
            cut.WaitForState(() => cut.FindAll("h1").Count > 0);

            // Assert: find the h1 element and check its content
            cut.Find("h1").MarkupMatches("<h1>Hello, world!</h1>");
        }

        [Theory]
        [InlineData("home")]
        [InlineData("about")]
        [InlineData("contact")]
        [InlineData("weather-forecasts")]
        [InlineData("regions")]
        [InlineData("play-page")]
        public void NavBarTopTest(string navPath)
        {
            // Arrange: render the Home.razor component
            var cut = RenderComponent<NavBarTop>();

            // Wait for the component to finish rendering
            cut.WaitForState(() => cut.FindAll("nav").Count > 0);

            // Assert: find the nav element and check its content
            cut.Find("nav").InnerHtml.Contains($"href=\"{navPath}\"");
        }
    }
}
