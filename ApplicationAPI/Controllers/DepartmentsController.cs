using ApplicationAPI.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.POCO.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationAPI.Controllers
{
    //[Route("[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        // GET: DepartmentsController
        public async Task<ActionResult> Index(string Search, int? page)
        {
            ViewData["Filter"] = Search;
            IEnumerable<Department> departments;
            if (!String.IsNullOrEmpty(Search))
            {
                departments = await departmentService.SearchByName(Search);
            }
            else
            {
                departments = await departmentService.All();
            }

            var departmentDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);
            var ListDepartment = PagingViewModel<DepartmentDto>.Create(departmentDtos, page ?? 1);

            return View(ListDepartment);
        }

        // GET: DepartmentsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var department = await departmentService.GetByIdNoTrackingAsync(id);
            if (department == null)
            {
                return NotFound($"{id} not found");
            }
            var departmentdto = mapper.Map<DepartmentDto>(department);
            return View(departmentdto);
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Created([Bind("n")] DepartmentDto departmentDto)
        {
            try
            {
                var department = mapper.Map<Department>(departmentDto);
                var isSet = await departmentService.Set(department);
            }
            catch
            {
                return BadRequest(departmentDto);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DepartmentsController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var department = await departmentService.GetByIdNoTrackingAsync(id);
            if (department == null)
            {
                return NotFound($"{id} not found");
            }
            var departmentdto = mapper.Map<DepartmentDto>(department);
            return View(departmentdto);
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edited(Guid id, [Bind("n")] DepartmentDto departmentDto)
        {
            try
            {
                var firstDepartment = await departmentService.GetByIdNoTrackingAsync(id);
                if (firstDepartment == null)
                {
                    return NotFound($"{id} not found");
                }
                departmentDto.id = id;
                var department = mapper.Map<Department>(departmentDto);
                var isUpdate = await departmentService.Update(department);
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

        // GET: DepartmentsController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var department = await departmentService.GetByIdNoTrackingAsync(id);
            if (department == null)
            {
                return NotFound($"{id} not found");
            }
            var departmentdto = mapper.Map<DepartmentDto>(department);
            return View(departmentdto);
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(Guid id)
        {
            try
            {
                var firstDepartment = await departmentService.GetByIdNoTrackingAsync(id);
                if (firstDepartment == null)
                {
                    return NotFound($"{id} not found");
                }

                var isUpdate = await departmentService.Delete(id);
                if (!isUpdate)
                {
                    return BadRequest();
                }
                var departmentDto = mapper.Map<DepartmentDto>(firstDepartment);
                return View(departmentDto);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}