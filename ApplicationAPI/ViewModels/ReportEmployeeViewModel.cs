using Domain.POCO.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationAPI.ViewModels
{
    public class ReportEmployeeViewModel
    {
        public ReportEmployeeViewModel(PagingViewModel<CalculateReportEmployeeDto> reportList, ReportEmployeeDto search, SelectList departmentNames)
        {
            ReportList = reportList;
            Search = search;
            DepartmentNames = departmentNames;
        }

        public PagingViewModel<CalculateReportEmployeeDto> ReportList { get; private set; }
        public ReportEmployeeDto Search { get; private set; }
        public SelectList DepartmentNames { get; private set; }
    }
}