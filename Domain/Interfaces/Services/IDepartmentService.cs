using Domain.Entities;
using Domain.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IDepartmentService : IService<Department>
    {
        Task<IEnumerable<Department>> SearchByName(string Name, CancellationToken cancellationToken = default);

        Task<Department> GetByNameAsync(string Name, CancellationToken cancellationToken = default);
    }
}