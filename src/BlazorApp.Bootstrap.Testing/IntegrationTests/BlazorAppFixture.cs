using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class BlazorAppFixture : IAsyncLifetime
{
    private WebApplicationFactory<BlazorApp.Bootstrap.Ui.Program> _factory;
    public string AppUrl { get; private set; }
    public HttpClient Client { get; private set; }

    public async Task InitializeAsync()
    {
        _factory = new WebApplicationFactory<BlazorApp.Bootstrap.Ui.Program>()
            .WithWebHostBuilder(builder =>
            {
                // Optionally configure test services here
            });

        // Start the server on a random port
        Client = _factory.CreateDefaultClient();
        AppUrl = Client.BaseAddress.ToString();

        // Optionally, wait for the app to be ready
        await Task.Delay(1000);
    }

    public Task DisposeAsync()
    {
        Client?.Dispose();
        _factory?.Dispose();
        return Task.CompletedTask;
    }
}