// Ignore Spelling: queryable Blazor App

using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Dtos;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Bootstrap.Business.Queries.Regions
{
    public class ManageRegionQuery(RegionDto data) : IQueryResult<Region>
    {
        private readonly RegionDto _data = data;

        public async Task Delete(IQueryableProvider queryableProvider)
        {
            var query = await queryableProvider.Query<Region>()
                .Where(w => w.Id == _data.Id)
                .ExecuteDeleteAsync();
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