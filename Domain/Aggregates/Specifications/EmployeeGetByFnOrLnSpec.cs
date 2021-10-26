using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Aggregates.Specifications
{
    internal sealed class EmployeeGetByFnOrLnSpec : BaseSpecification<Employee>
    {
        public EmployeeGetByFnOrLnSpec(string firstName, string lastName)
            : base(x => x.FirstName.ToUpper().Contains(firstName.ToUpper()) && x.LastName.ToUpper().Contains(lastName.ToUpper()))
        {
            AsNoTracking = true;
        }
    }
}