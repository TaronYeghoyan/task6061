using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> All(CancellationToken cancellationToken = default);

        Task<T> GetById(Guid id, CancellationToken cancellationToken = default);

        Task<bool> Set(T entity, CancellationToken cancellationToken = default);

        Task<bool> Update(T entity, CancellationToken cancellationToken = default);

        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);

        Task<T> GetByIdNoTrackingAsync(Guid id, CancellationToken cancellationToken = default);
    }
}