using Blog.External.Infrastructure.Persistences.Contexts;
using Blog.Intenal.Domains.Core.Abstractions;
using Blog.Intenal.Domains.Core.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Blog.External.Infrastructures.Persistences.Abstractions
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal readonly MainContext _context;
        internal readonly ILogger<TEntity> _logger;

        public BaseRepository(ILogger<TEntity> logger,
            MainContext queroGasContext
            )
        {
            _logger = logger;
            _context = queroGasContext;
        }


        public async Task<CustomResult> GetsAsync(
            CancellationToken cancellationToken)
        {
            var response = await _context.Set<TEntity>()
                .ToListAsync(cancellationToken);

            var result = CustomResult.GetResponse(response);

            return result;
        }

        public async Task<CustomResult> GetByIdAsync<T>(
            T primaryKey, CancellationToken cancellationToken)
        {
            var response = await _context.Set<TEntity>().FindAsync(
                primaryKey, cancellationToken);

            var result = CustomResult.GetResponse(response);

            return result;
        }

        public async Task<CustomResult> GetQueryableAsync()
        {
            var response = _context.Set<TEntity>();

            await Task.Delay(0);

            var result = CustomResult.GetResponse(response);

            return result;
        }

        public async Task<CustomResult> CreateAsync(
            TEntity entity, CancellationToken cancellationToken)
        {
            var response = await _context.Set<TEntity>()
                .AddAsync(entity, cancellationToken);

            var result = CustomResult.GetResponse(response);

            return result;
        }

        public async Task<CustomResult> UpdateAsync(
            TEntity entity, CancellationToken cancellationToken)
        {
            var response = _context.Set<TEntity>().Update(entity);

            await Task.Delay(0, cancellationToken);

            var result = CustomResult.GetResponse(response);

            return result;
        }

        public async Task<CustomResult> DeleteAsync(
            TEntity entity, CancellationToken cancellationToken)
        {
            var response = await UpdateAsync(entity, cancellationToken);

            var result = CustomResult.GetResponse(response);

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.Collect();
        }
    }
}

