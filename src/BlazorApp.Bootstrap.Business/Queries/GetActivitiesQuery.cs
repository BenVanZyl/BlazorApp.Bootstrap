using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Infrastructure;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;

namespace BlazorApp.Bootstrap.Business.Queries
{
    public class GetActivitiesQuery : IQueryResultList<Activity>
    {
        public GetActivitiesQuery WithYear(int value)
        {
            if (value == 0)
                _year = null;
            else
                _year = value;

            return this;
        }

        public GetActivitiesQuery WithMonth(int value)
        {
            if (value == 0)
                _month = null;
            else
                _month = value;

            return this;
        }

        private int? _year;
        private int? _month;

        public IQueryable<Activity> Get(IQueryableProvider queryableProvider)
        {
            //get all
            var query = queryableProvider.Query<Activity>();

            if (_year.HasValue && !_month.HasValue)
                query = query.Where(w => w.ActivityDate.Year == _year);

            if (_year.HasValue && _month.HasValue)
                query = query.Where(w => w.ActivityDate.Year == _year && w.ActivityDate.Month == _month);

            return query.OrderByDescending(o => o.ActivityDate);
        }
    }
}
