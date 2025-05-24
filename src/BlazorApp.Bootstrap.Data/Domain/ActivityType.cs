using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Bootstrap.Data.Domain
{
    public class ActivityType : DomainEntityWithId
    {
        protected ActivityType() { }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int OrderedBy { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }


        #region Configuration
        internal class Mapping : IEntityTypeConfiguration<ActivityType>
        {
            public void Configure(EntityTypeBuilder<ActivityType> builder)
            {
                builder.ToTable("ActivityType", "Dojo");
                builder.HasKey(u => u.Id);  // PK.
                builder.Property(p => p.Id).HasColumnName("Id");

                builder.Property(p => p.CreatedOn).IsRequired();
                builder.Property(p => p.ModifiedOn).IsRequired();
                builder.Property(p => p.Name).HasMaxLength(128).IsRequired();
                builder.Property(p => p.Description).HasMaxLength(1024).IsRequired();
                builder.Property(p => p.OrderedBy).IsRequired();

            }
        }
        #endregion //config

    }
}
