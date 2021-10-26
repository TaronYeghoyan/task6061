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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        // GET: EmployeeController
        public async Task<ActionResult> Index(string Search, int? page)
        {
            ViewData["Filter"] = Search;
            IEnumerable<Employee> employees;
            if (!String.IsNullOrEmpty(Search))
            {
                employees = await employeeService.SearchByFLDName(Search);
            }
            else
            {
                employees = await employeeService.GetIncludeList();
            }

            var employeeDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);

            var ListEmployees = PagingViewModel<EmployeeDto>.Create(employeeDtos, page ?? 1);

            return View(ListEmployees);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var employee = await employeeService.GetByIdNoTrackingWhitIncludeAsync(id);
            if (employee == null)
            {
                return NotFound($"{id} not found");
            }
            var employeeDto = mapper.Map<EmployeeDto>(employee);
            return View(employeeDto);
        }

        // GET: EmployeeController/Create
        public async Task<ActionResult> Create()
        {
            var departments = await departmentService.All();
            var departmentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);
            ViewBag.DepartmentName = new SelectList(departmentDtos, "n", "n");
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("fn,ln,d,w,wd,dn")] EmployeeDto employeeDto)
        {
            try
            {
                var employee = mapper.Map<Employee>(employeeDto);
                var ExistEmployee = await employeeService.GetByFnOrLn(employee.FirstName, employee.LastName);
                if (ExistEmployee != null)
                {
                    return BadRequest(employeeDto);
                }
                Department ExistDepartment = await departmentService.GetByNameAsync(employeeDto.dn);
                if (ExistDepartment == null)
                {
                    return BadRequest(employeeDto);
                }
                employee.DepartmentId = ExistDepartment.Id;
                employee.Department = null;
                var isSet = await employeeService.Set(employee);
                if (!isSet)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest(employeeDto);
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var departments = await departmentService.All();
            var departmentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);
            ViewBag.DepartmentName = new SelectList(departmentDtos, "n", "n");

            var employee = await employeeService.GetByIdNoTrackingAsync(id);
            if (employee == null)
            {
                return NotFound($"{id} not found");
            }
            var employeeDto = mapper.Map<EmployeeDto>(employee);
            return View(employeeDto);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edited(Guid id, [Bind("fn,ln,d,w,wd,dn")] EmployeeDto employeeDto)
        {
            try
            {
                var firstEmployee = await employeeService.GetByIdNoTrackingAsync(id);
                if (firstEmployee == null)
                {
                    return NotFound($"{id} not found");
                }
                employeeDto.id = id;
                var employee = mapper.Map<Employee>(employeeDto);

                var isUpdate = await employeeService.Update(employee);
                if (!isUpdate)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: EmployeeController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var employee = await employeeService.GetByIdNoTrackingAsync(id);
            if (employee == null)
            {
                return NotFound($"{id} not found");
            }
            var employeDto = mapper.Map<EmployeeDto>(employee);
            return View(employeDto);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(Guid id)
        {
            try
            {
                var employee = await employeeService.GetByIdNoTrackingAsync(id);
                if (employee == null)
                {
                    return NotFound($"{id} not found");
                }

                var isUpdate = await employeeService.Delete(id);
                if (!isUpdate)
                {
                    return BadRequest();
                }
                var employeDto = mapper.Map<EmployeeDto>(employee);
                return View(employeDto);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}