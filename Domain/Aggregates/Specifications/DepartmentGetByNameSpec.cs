using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Aggregates.Specifications
{
    internal sealed class DepartmentGetByNameSpec : BaseSpecification<Department>
    {
        public DepartmentGetByNameSpec(string Name) : base(x => x.Name.ToUpper() == Name.ToUpper())
        {
            AsNoTracking = true;
        }
    }
}