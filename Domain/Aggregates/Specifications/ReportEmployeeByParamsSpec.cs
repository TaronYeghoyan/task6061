using Domain.Entities;
using Domain.SeedWork;

namespace Domain.Aggregates.Specifications
{
    internal sealed class ReportEmployeeByParamsSpec : BaseSpecification<Employee>
    {
        public ReportEmployeeByParamsSpec(int ws, int wd, string dn) : base
            (x => x.Wage > ws && x.Wage < (wd == 0 ? 1001 : wd) &&
            (dn != "All" ? x.Department.Name.ToUpper().Contains(dn.ToUpper()) : true))
        {
            AsNoTracking = true;
            AddInclude(x => x.Department);
        }
    }
}