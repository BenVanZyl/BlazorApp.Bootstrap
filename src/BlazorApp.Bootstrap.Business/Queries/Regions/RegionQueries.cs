// Ignore Spelling: queryable Blazor App

using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Dtos;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Bootstrap.Business.Queries.Regions
{
    public class RegionQueries(RegionDto data) : IQueryResultSingle<Region>
    {
        private readonly RegionDto _data = data;

        public async Task Delete(IQueryableProvider queryableProvider)
        {
            var query = await queryableProvider.Query<Region>()
                .Where(w => w.Id == _data.Id)
                .ExecuteDeleteAsync();
        }

        public IQueryable<Region> Get(IQueryableProvider queryableProvider)
        {
            var query = queryableProvider.Query<Region>()
                .Where(w => w.Id == _data.Id);

            return query;
        }

        public async Task Update(IQueryableProvider queryableProvider)
        {
            var query = await queryableProvider.Query<Region>()
                .Where(w => w.Id == _data.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(setters => setters.RegionName, _data.RegionName)
                    .SetProperty(setters => setters.ModifiedOn, DateTime.Now)
                );
        }
    }
}