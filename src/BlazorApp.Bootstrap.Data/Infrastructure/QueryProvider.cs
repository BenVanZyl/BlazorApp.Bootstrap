
// TODO: Move to SnowStorm component


namespace BlazorApp.Bootstrap.Data.Infrastructure
{
    public interface IQueryableProvider
    {
        IQueryable<T> Query<T>() where T : class;
    }

    public class QueryableProvider(DataContext dbContext) : IQueryableProvider
    {
        private readonly DataContext _dbContext = dbContext;

        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext.Set<T>();
        }
    }
}
