using Domain.Entities;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService : IService<Employee>
    {
        Task<IEnumerable<Employee>> SearchByFLDName(string search, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetIncludeList(CancellationToken cancellationToken = default);

        Task<Employee> GetByIdNoTrackingWhitIncludeAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Employee> GetByFnOrLn(string firstName, string lastName, CancellationToken cancellationToken = default);

        Task<IEnumerable<Employee>> GetReportByParams(int ws, int wd, string dn, CancellationToken cancellationToken = default);
    }
}