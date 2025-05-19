using BlazorApp.Bootstrap.Navs.Components.Layout;
using BlazorApp.Bootstrap.Navs.Components.Pages;
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
        [InlineData("about")]
        [InlineData("activities")]
        [InlineData("contact")]
        [InlineData("")]
        public void NavBarTopTest(string navPath)
        {
            // Arrange: render the Home.razor component
            var cut = RenderComponent<NavBarTop>();
            // Wait for the component to finish rendering
            cut.WaitForState(() => cut.FindAll("nav").Count > 0);

            // Act: find and click the <button> element to increment 
            // the counter in the <p> element
            //cut.Find("button").Click();

            // Assert: find the h1 element and check its content
            cut.Find("nav").InnerHtml.Contains($"href=\"{navPath}\"");
        }
    }
}
