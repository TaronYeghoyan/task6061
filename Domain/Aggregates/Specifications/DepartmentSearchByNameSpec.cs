using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Aggregates.Specifications
{
    internal sealed class DepartmentSearchByNameSpec : BaseSpecification<Department>
    {
        public DepartmentSearchByNameSpec(string Name) : base(x => x.Name.ToUpper().Contains(Name.ToUpper()))
        {
            AsNoTracking = true;
        }
    }
}