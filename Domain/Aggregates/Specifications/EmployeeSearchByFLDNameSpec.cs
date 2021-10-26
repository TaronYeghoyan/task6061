using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Aggregates.Specifications
{
    internal sealed class EmployeeSearchByFLDNameSpec : BaseSpecification<Employee>
    {
        public EmployeeSearchByFLDNameSpec(string Search) : base(x => x.FirstName.ToUpper().Contains(Search.ToUpper()) || x.LastName.ToUpper().Contains(Search.ToUpper()) || x.Department.Name.ToUpper().Contains(Search.ToUpper()))
        {
            AsNoTracking = true;
            AddInclude(x => x.Department);
        }
    }
}