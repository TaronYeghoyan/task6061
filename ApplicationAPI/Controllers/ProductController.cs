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
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(int? page)
        {
            var products = await productService.All();
            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);
            var listProduct = PagingViewModel<ProductDto>.Create(productDtos, page ?? 1);

            return View(listProduct);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var product = await productService.GetByIdNoTrackingAsync(id);
            if (product == null)
            {
                return NotFound($"{id} not found");
            }
            var productDto = mapper.Map<ProductDto>(product);
            return View(productDto);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Created([Bind("n,p,bc,plu")] ProductDto productDto)
        {
            try
            {
                var product = mapper.Map<Product>(productDto);
                var isSet = await productService.Set(product);
                if (!isSet)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = productDto
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                return BadRequest(json);
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var product = await productService.GetByIdNoTrackingAsync(id);
            if (product == null)
            {
                return NotFound($"{id} not found");
            }
            var productDto = mapper.Map<ProductDto>(product);
            return View(productDto);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edited(Guid id, [Bind("n,p,bc,plu")] ProductDto productDto)
        {
            try
            {
                var findproduct = await productService.GetByIdNoTrackingAsync(id);
                if (findproduct == null)
                {
                    return NotFound($"{id} not found");
                }
                productDto.id = id;
                var product = mapper.Map<Product>(productDto);
                var isUpdate = await productService.Update(product);
                if (!isUpdate)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = productDto
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                return BadRequest(json);
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await productService.GetByIdNoTrackingAsync(id);
            if (product == null)
            {
                return NotFound($"{id} not found");
            }
            var productDto = mapper.Map<ProductDto>(product);
            return View(productDto);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(Guid id)
        {
            try
            {
                var firstProduct = await productService.GetByIdNoTrackingAsync(id);
                if (firstProduct == null)
                {
                    return NotFound($"{id} not found");
                }

                var isUpdate = await productService.Delete(id);
                if (!isUpdate)
                {
                    return BadRequest();
                }
                var productDto = mapper.Map<ProductDto>(firstProduct);
                return View(productDto);
            }
            catch
            {
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = $"Product Can't Deletid by {id}"
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                return BadRequest(json);
            }
        }
    }
}