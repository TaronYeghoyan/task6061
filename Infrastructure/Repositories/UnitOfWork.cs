using Domain.Interfaces.Repositories;
using Domain.SeedWork;
using Infrastructure.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _dbContext;

        public UnitOfWork(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //  public IEntityReposiory AccountRepository => new IEntityReposiory(_dbContext);
        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_dbContext);

        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_dbContext);

        public IProductRepository ProductRepository => new ProductRepository(_dbContext);

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}