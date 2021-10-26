using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Aggregates.Specifications
{
    internal sealed class EmployeeIncludeDepartmentSpec : BaseSpecification<Employee>
    {
        public EmployeeIncludeDepartmentSpec() : base(x => x != null)
        {
            AsNoTracking = true;
            AddInclude(x => x.Department);
        }
    }
}