using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Infrastructure
{
    public static class Setup
    {
        public static void AddSnowStorm(this IServiceCollection services, string connectionString)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IQueryableProvider, QueryableProvider>();
            services.AddScoped<QueryRunner>();

            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });
        }
    }
}
