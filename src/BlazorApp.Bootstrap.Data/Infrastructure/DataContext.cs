using Microsoft.EntityFrameworkCore;
using System.Reflection;

// TODO: Move to SnowStorm component

namespace BlazorApp.Bootstrap.Data.Infrastructure
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
