using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace BlazorApp.Bootstrap.Testing.IntegrationTests
{
    public class PlaywrightTests : IClassFixture<BlazorAppFixture>, IAsyncLifetime
    {
        private readonly BlazorAppFixture _appFixture;
        private IPlaywright _playwright;
        private IBrowser _browser;

        public PlaywrightTests(BlazorAppFixture appFixture)
        {
            _appFixture = appFixture;
        }

        public async Task InitializeAsync()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        }

        public async Task DisposeAsync()
        {
            await _browser.DisposeAsync();
            _playwright.Dispose();
        }

        [Fact]
        public async Task HomePage_Should_Display_HelloWorld()
        {
            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync(_appFixture.AppUrl);

            var h1 = await page.Locator("h1").InnerTextAsync();
            Assert.Equal("Hello, world!", h1);

            await context.CloseAsync();
        }
    }
}
