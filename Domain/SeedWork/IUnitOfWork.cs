using Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        // IRepository  entityRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        IDepartmentRepository DepartmentRepository { get; }
        IProductRepository ProductRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}