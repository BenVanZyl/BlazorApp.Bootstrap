using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Dtos;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;

namespace BlazorApp.Bootstrap.Business.Queries
{
    public class GetActivitiesQuery(ActivitiesFilterDto? filter = null) : IQueryResultList<Activity>
    {
        public GetActivitiesQuery WithYear(int value)
        {
            if (_filter == null)
                _filter = new();

            if (value == 0)
                _filter.Year = null;
            else
                _filter.Year = value;

            return this;
        }

        public GetActivitiesQuery WithMonth(int value)
        {
            if (_filter == null)
                _filter = new();

            if (value == 0)
                _filter.Month = null;
            else
                _filter.Month = value;

            return this;
        }

        private ActivitiesFilterDto? _filter = filter;

        public IQueryable<Activity> Get(IQueryableProvider queryableProvider)
        {
            //get all
            var query = queryableProvider.Query<Activity>();

            if (_filter != null)
            {
                if (_filter.Year.HasValue && !_filter.Month.HasValue)
                    query = query.Where(w => w.ActivityDate.Year == _filter.Year);

                if (_filter.Year.HasValue && _filter.Month.HasValue)
                    query = query.Where(w => w.ActivityDate.Year == _filter.Year && w.ActivityDate.Month == _filter.Month);

                if (_filter.ActivityTypeId.HasValue)
                    query = query.Where(w => w.ActivityTypeId == _filter.ActivityTypeId);
            } 

            return query.OrderByDescending(o => o.ActivityDate);
        }
    }
}
