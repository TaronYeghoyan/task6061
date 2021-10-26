using Domain.SeedWork;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private protected readonly MyDBContext _dbContext;
        private protected readonly DbSet<T> _entites;

        public BaseRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
            _entites = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await _entites.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var keyValues = new object[] { id };
            return await _entites.FindAsync(keyValues, cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            _entites.Add(entity);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _entites.Update(entity);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _entites.Remove(entity);
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await SpecResult(spec).FirstOrDefaultAsync<T>(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await SpecResult(spec).ToListAsync<T>(cancellationToken);
        }

        private IQueryable<T> SpecResult(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes.Aggregate(_entites.AsQueryable(), (current, NextInclude) => current.Include(NextInclude));
            var secondaryResult = spec.IncludeStrings.Aggregate(queryableResultWithIncludes, (current, NextInclude) => current.Include(NextInclude));
            var queryCriteria = secondaryResult.Where(spec.Criteria);
            return spec.AsNoTracking ? queryCriteria.AsNoTracking() : queryCriteria;
        }
    }
}