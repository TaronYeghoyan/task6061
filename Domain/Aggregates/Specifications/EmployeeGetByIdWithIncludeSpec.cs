using Domain.Entities;
using Domain.SeedWork;
using System;

namespace Domain.Aggregates.Specifications
{
    internal sealed class EmployeeGetByIdWithIncludeSpec : BaseSpecification<Employee>
    {
        public EmployeeGetByIdWithIncludeSpec(Guid id) : base(x => x.Id == id)
        {
            AsNoTracking = true;
            AddInclude(x => x.Department);
        }
    }
}