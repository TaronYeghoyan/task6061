using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken);

        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);

        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken);
    }
}