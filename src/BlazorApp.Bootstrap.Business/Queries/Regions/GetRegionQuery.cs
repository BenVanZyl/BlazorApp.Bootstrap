using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Business.Queries.Regions
{
    public class GetRegionQuery(long id) : IQueryResultSingle<Region>
    {
        private readonly long _id = id;

        public IQueryable<Region> Get(IQueryableProvider queryableProvider)
        {
            var query = queryableProvider.Query<Region>()
                .Where(w => w.Id == _id);

            return query;
        }
    }
}
