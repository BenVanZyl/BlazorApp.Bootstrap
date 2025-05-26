using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;

// TODO: Move to SnowStorm component

namespace BlazorApp.Bootstrap.Data.Infrastructure.QueryResults
{

    public interface IQueryResultList<out T> where T : class, IDomainEntity
    {
        IQueryable<T> Get(IQueryableProvider queryableProvider);
    }

    public interface IQueryResultSingle<out T> where T : class, IDomainEntity
    {
        IQueryable<T> Get(IQueryableProvider queryableProvider);

        Task Update(IQueryableProvider queryableProvider);

        Task Delete(IQueryableProvider queryableProvider);
    }
}
