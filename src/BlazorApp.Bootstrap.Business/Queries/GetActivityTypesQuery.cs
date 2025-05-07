using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Business.Queries
{
    public class GetActivityTypesQuery : IQueryResultList<ActivityType>
    {
        public IQueryable<ActivityType> Get(IQueryableProvider queryableProvider)
        {
            var query = queryableProvider.Query<ActivityType>();
            return query.OrderBy(o => o.OrderedBy);
        }
    }
}
