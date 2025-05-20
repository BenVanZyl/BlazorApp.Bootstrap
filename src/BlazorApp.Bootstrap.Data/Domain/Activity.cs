using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Bootstrap.Data.Dtos;

namespace BlazorApp.Bootstrap.Data.Domain
{
    public class Activity: DomainEntityWithId
    {
        protected Activity() { }

        public long ActivityTypeId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("ActivityTypeId")]
        public Region ActivityType { get; private set; }
        
        public DateTime CreatedOn { get; private set; }
        
        public DateTime ModifiedOn { get; private set; }

        public static async Task<Activity> Create(ActivityDto data)
        {
            var newItem = new Activity();
            newItem.Save(data);
            return newItem; 
        }

        public void Save(ActivityDto data)
        {
            throw new NotImplementedException();
        }



        #region Configuration
        internal class Mapping : IEntityTypeConfiguration<Activity>
        {
            public void Configure(EntityTypeBuilder<Activity> builder)
            {
                builder.ToTable("Activity", "Dojo");
                builder.HasKey(u => u.Id);  // PK.
                builder.Property(p => p.Id).HasColumnName("Id");

                builder.Property(p => p.CreatedOn).IsRequired();
                builder.Property(p => p.ModifiedOn).IsRequired();
                builder.Property(p => p.ActivityTypeId).IsRequired();
                builder.Property(p => p.ActivityDate).IsRequired();
                builder.Property(p => p.Notes).HasMaxLength(4096);


            }
        }
        #endregion //config
    }
}
