using BlazorApp.Bootstrap.Ui;
using BlazorApp.Bootstrap.Testing.Infrastrcuture.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BlazorApp.Bootstrap.Testing.Infrastrcuture
{
    public class TestAppFactory : WebApplicationFactory<Program>
    {
        // You can override the ConfigureWebHost method to configure the test server
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            DbManager.ConfigureDatabase();

            // For example, you can use a different appsettings file for testing
            builder.ConfigureAppConfiguration((context, config) =>
            {
                //config.AddJsonFile("appsettings.Test.json");
            })
            .UseSetting("ConnectionStrings:Database", DbManager.ConnectionString)
            .UseEnvironment("Development");

            base.ConfigureWebHost(builder);
        }
    }
}