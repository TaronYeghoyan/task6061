using Domain.Aggregates.Specifications;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = unitOfWork.DepartmentRepository;
        }

        public async Task<IEnumerable<Department>> All(CancellationToken cancellationToken = default)
        {
            return await _departmentRepository.ListAllAsync(cancellationToken);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _departmentRepository.GetByIdAsync(id, cancellationToken);
            await _departmentRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Department> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _departmentRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<Department> GetByIdNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var spec = new GetByIdNoTracingSpec<Department>(id);
            return await _departmentRepository.FirstOrDefaultAsync(spec, cancellationToken);
        }

        public async Task<Department> GetByNameAsync(string Name, CancellationToken cancellationToken = default)
        {
            var spec = new DepartmentGetByNameSpec(Name);
            return await _departmentRepository.FirstOrDefaultAsync(spec, cancellationToken);
        }

        public async Task<IEnumerable<Department>> SearchByName(string Name, CancellationToken cancellationToken = default)
        {
            var spec = new DepartmentSearchByNameSpec(Name);
            return await _departmentRepository.ListAsync(spec, cancellationToken);
        }

        public async Task<bool> Set(Department entity, CancellationToken cancellationToken = default)
        {
            await _departmentRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Department entity, CancellationToken cancellationToken = default)
        {
            await _departmentRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}