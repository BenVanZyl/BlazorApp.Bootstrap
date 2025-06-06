using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Ui.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlazorApp.Bootstrap.Ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // add data
            string dataConnectionString = builder.Configuration.GetConnectionString("Database") ?? throw new NullReferenceException("Missing Data connection string!");
            builder.Services.AddSnowStorm(dataConnectionString);

            // commands - mediatR
            var businessAssembly = Assembly.Load("BlazorApp.Bootstrap.Business");
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(businessAssembly));            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
