using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;

// TODO: Move to SnowStorm component

namespace BlazorApp.Bootstrap.Data.Infrastructure
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        /// <summary>
        /// Get the underlaying connection string for this DB Context
        /// </summary>
        public string? ConnectionString => Database != null ? Database.GetConnectionString() : "not provided!";

        /// <summary>
        /// Get the underlaying connection for this DB Context
        /// </summary>
        public DbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
