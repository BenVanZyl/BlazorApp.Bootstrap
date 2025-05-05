using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities
{
    public interface IDomainEntity
    {
    }

    public class DomainEntity : IDomainEntity
    {
    }

    public class DomainEntityWithId : DomainEntity
    {
        public long Id { get; set; }
    }
}
