using ApplicationAPI.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.POCO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationAPI.Controllers
{
    public class ReportEmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public ReportEmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        // GET: ReportEmployeeController
        [HttpGet]
        public async Task<ActionResult> Report(string ds, string de, int ws, int we, string dn, int? page)
        {
            var isDateStart = DateTime.TryParse(ds, out DateTime dateStart);
            var isDateEnd = DateTime.TryParse(de, out DateTime dateEnd);

            if (!isDateStart || !isDateEnd || dateEnd.Subtract(dateStart).Ticks <= 0) return BadRequest("DateTime not Correct");

            if (dn == null) return BadRequest("dn Parametr can't be null");
            if (ws < 0 || we < 0) return BadRequest("Start Wage or End Wage not Correct");
            if (dn != "All")
            {
                if (await departmentService.GetByNameAsync(dn) == null) return BadRequest($"{dn} not correct");
            }
            var departments = await departmentService.All();
            var departmentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);
            var dpartmentNames = new SelectList(departmentDtos, "n", "n");

            IEnumerable<Employee> employees = await employeeService.GetReportByParams(ws, we, dn);
            var employeeDtos = mapper.Map<IEnumerable<CalculateReportEmployeeDto>>(employees);

            var days = dateEnd.Subtract(dateStart).TotalDays;
            var weeks = days / 7;

            var l = PagingViewModel<CalculateReportEmployeeDto>.Create(employeeDtos, page ?? 1);
            l.ForEach(x =>
            {
                x.wdt = Convert.ToUInt32(weeks * x.wdt);
                x.st = Convert.ToUInt32(days * x.w / 30);
            });

            var view = new ReportEmployeeViewModel(l, new ReportEmployeeDto() { de = dateEnd, dn = dn, ds = dateStart, we = we, ws = ws }, dpartmentNames);

            return View(view);
        }

        public async Task<ActionResult> Index()
        {
            var departments = await departmentService.All();
            var departmentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);
            ViewBag.DepartmentName = new SelectList(departmentDtos, "n", "n");

            return View(new ReportEmployeeDto() { ds = DateTime.Today, de = DateTime.Today.AddDays(30), ws = 0, we = 0 });
        }
    }
}