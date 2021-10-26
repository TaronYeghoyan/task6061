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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = unitOfWork.EmployeeRepository;
        }

        public async Task<IEnumerable<Employee>> All(CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.ListAllAsync(cancellationToken);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _employeeRepository.GetByIdAsync(id, cancellationToken);
            await _employeeRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _employeeRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<Employee> GetByIdNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var spec = new GetByIdNoTracingSpec<Employee>(id);
            return await _employeeRepository.FirstOrDefaultAsync(spec, cancellationToken);
        }

        public async Task<Employee> GetByIdNoTrackingWhitIncludeAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var spec = new EmployeeGetByIdWithIncludeSpec(id);
            return await _employeeRepository.FirstOrDefaultAsync(spec, cancellationToken);
        }

        public async Task<IEnumerable<Employee>> GetIncludeList(CancellationToken cancellationToken = default)
        {
            var spec = new EmployeeIncludeDepartmentSpec();
            return await _employeeRepository.ListAsync(spec, cancellationToken);
        }

        public async Task<Employee> GetByFnOrLn(string firstName, string lastName, CancellationToken cancellationToken = default)
        {
            var spec = new EmployeeGetByFnOrLnSpec(firstName, lastName);
            return await _employeeRepository.FirstOrDefaultAsync(spec, cancellationToken);
        }

        public async Task<IEnumerable<Employee>> SearchByFLDName(string search, CancellationToken cancellationToken = default)
        {
            var spec = new EmployeeSearchByFLDNameSpec(search);
            return await _employeeRepository.ListAsync(spec, cancellationToken);
        }

        public async Task<bool> Set(Employee entity, CancellationToken cancellationToken = default)
        {
            await _employeeRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Employee entity, CancellationToken cancellationToken = default)
        {
            await _employeeRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetReportByParams(int ws, int wd, string dn, CancellationToken cancellationToken = default)
        {
            var spec = new ReportEmployeeByParamsSpec(ws, wd, dn);
            return await _employeeRepository.ListAsync(spec, cancellationToken);
        }
    }
}