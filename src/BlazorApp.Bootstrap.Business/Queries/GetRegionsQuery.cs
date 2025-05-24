using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;

namespace BlazorApp.Bootstrap.Business.Queries
{
    public class GetRegionsQuery : IQueryResultList<Region>
    {
        public IQueryable<Region> Get(IQueryableProvider queryableProvider)
        {
            var query = queryableProvider.Query<Region>();
            return query.OrderBy(o => o.RegionName);
        }
    }
}
