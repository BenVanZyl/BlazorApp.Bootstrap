using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

// TODO: Move to SnowStorm component

namespace BlazorApp.Bootstrap.Data.Infrastructure
{
    public static class Setup
    {
        public static void AddSnowStorm(this IServiceCollection services, string connectionString)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IQueryableProvider, QueryableProvider>();
            services.AddScoped<QueryRunner>();

            services.AddDbContextFactory<DataContext>(o =>
                {
                    o.UseSqlServer(connectionString);

                },
                ServiceLifetime.Scoped
            );
        }
    }
}
