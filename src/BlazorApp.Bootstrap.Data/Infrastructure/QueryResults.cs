using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Data.Infrastructure.QueryResults
{
    public interface IQueryResult<T>
    {
        Task<T> Get(IQueryableProvider queryableProvider);
    }

    public interface IQueryResultList<out T> where T : class, IDomainEntity
    {
        IQueryable<T> Get(IQueryableProvider queryableProvider);
    }

    public interface IQueryResultSingle<out T> where T : class, IDomainEntity
    {
        IQueryable<T> Get(IQueryableProvider queryableProvider);
    }
}
