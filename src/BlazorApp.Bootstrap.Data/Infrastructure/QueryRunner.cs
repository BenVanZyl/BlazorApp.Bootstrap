using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp.Bootstrap.Data.Infrastructure.DomainEntities;
using BlazorApp.Bootstrap.Data.Infrastructure.QueryResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Bootstrap.Data.Infrastructure
{
    public class QueryRunner(ILogger<QueryRunner> logger, DataContext dbcontext, IQueryableProvider queryableProvider, IMapper mapper)
    {
        private readonly ILogger<QueryRunner> _logger = logger;
        private readonly DataContext _dbcontext = dbcontext;
        private readonly IQueryableProvider _queryableProvider = queryableProvider;
        private readonly IMapper _mapper = mapper;


        public Task<T> Get<T>(IQueryResultSingle<T> query, bool defaultIfMissing = true) where T : class, IDomainEntity
        {
            try
            {
                return Get(async () =>
                {
                    try
                    {
                        var result = await query.Get(_queryableProvider).FirstOrDefaultAsync();
                        if (!defaultIfMissing && result == null)
                            throw new ArgumentNullException($"'{typeof(T).Name}': Status404 - NotFound");

                        return result;
                    }
                    catch (Exception ex)
                    {
                        string message = $"Error: DataContext.Get<T>(IQueryResultList<T>...) with sorting : {ex.Message} ";
                        _logger?.LogError(ex, message);
                        throw;
                    }
                }, _dbcontext, query);
            }
            catch (Exception ex)
            {
                string message = $"Error: DataContext.Get<T>(IQueryResultList<T>...) with sorting : {ex.Message} ";
                _logger?.LogError(ex, message);
                throw;
            }
        }

        public Task<TDto> Get<T, TDto>(IQueryResultSingle<T> query, bool defaultIfMissing = true) where T : class, IDomainEntity
        {
            try
            {
                return Get(async () =>
                {
                    var result = await query.Get(_queryableProvider).ProjectTo<TDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

                    if (!defaultIfMissing && result == null)
                        throw new NullReferenceException($"'{typeof(T).Name}': Status404 - NotFound");

                    return result;
                }, _dbcontext, query);
            }
            catch (Exception ex)
            {
                string message = $"Error: CastingBuilder.Get<T>(IQueryResultSingle<T>...) : {ex.Message} ";
                _logger?.LogError(ex, message);
                throw;
            }
        }

        public Task<List<T>> Get<T>(IQueryResultList<T> query) where T : class, IDomainEntity
        {
            return Get(async () => await query.Get(_queryableProvider).ToListAsync(), _dbcontext, query);
        }

        public Task<List<TDto>> Get<T, TDto>(IQueryResultList<T> query) where T : class, IDomainEntity
        {
            try
            {
                return Get(async () =>
                {
                    var queryable = query.Get(_queryableProvider).ProjectTo<TDto>(_mapper.ConfigurationProvider);

                    return await queryable.ToListAsync();
                }, _dbcontext, query);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"Error: Get<T,TDto>(IQueryResultList<T>...) : {ex.Message} ");
                throw;
            }
        }

        public async Task<T> GetById<T>(long id) where T : DomainEntityWithId
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            try
            {
                stopwatch.Start();
                var result = await _dbcontext.Set<T>().OrderByDescending(o => o.Id).FirstOrDefaultAsync(w => w.Id == id);
                stopwatch.Stop();
                _logger?.LogDebug(message: $"GetById query ran for {stopwatch.Elapsed.TotalSeconds} seconds.");
                //null checks to be handle by client
                return result;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger?.LogError(ex, $"Error.  GetById({id}) : {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Core method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="GetResult"></param>
        /// <param name="dbContext"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="GenericException"></exception>
        public async Task<T> Get<T>(Func<Task<T>> GetResult, DbContext dbContext, object query)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();

            if (dbContext == null)
                throw new NullReferenceException("No database connection found.");

            if (query == null)
                throw new NullReferenceException("No query object defined.");

            try
            {
                stopwatch.Start();
                _logger?.LogDebug(message: $"DataContext.Get() => {query}");
                var result = await GetResult();
                return result;
            }
            catch (Exception ex)
            {
                string message = $"DataContext.Get() failed. [{ex.Message}]";
                _logger?.LogError(exception: ex, message: message);
                throw new Exception("Error getting data.", ex);
            }
            finally
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
                string message = $"DataContext.Get() => {stopwatch.Elapsed.TotalSeconds}";
                _logger?.LogDebug(message: message);
            }
        }
    }
}
