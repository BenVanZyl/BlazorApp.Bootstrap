using BlazorApp.Bootstrap.Data.Dtos;
using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.InteropServices;

namespace BlazorApp.Bootstrap.Data.Domain
{
    public class Region : DomainEntityWithId
    {
        public string RegionName { get; private set; } = null!;
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }


        #region

        protected Region() { }

        public Region(string regionName)
        {
            Save(regionName);
            CreatedOn = DateTime.Now;
        }

        public bool Save(string regionName)
        {
            RegionName = regionName;
            ModifiedOn = DateTime.Now;
            return true;
        }


        #endregion
        #region Configuration
        internal class Mapping : IEntityTypeConfiguration<Region>
        {
            public void Configure(EntityTypeBuilder<Region> builder)
            {
                builder.ToTable("Region", "dbo");
                builder.HasKey(u => u.Id);  // PK.
                builder.Property(p => p.Id).HasColumnName("Id");

                builder.Property(p => p.CreatedOn).IsRequired();
                builder.Property(p => p.ModifiedOn).IsRequired();

            }
        }
        #endregion //config

    }
}
