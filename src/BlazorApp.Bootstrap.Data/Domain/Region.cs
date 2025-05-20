using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Bootstrap.Data.Domain
{
    public class Region : DomainEntityWithId
    {
        protected Region() { }

        public string RegionName { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }


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
