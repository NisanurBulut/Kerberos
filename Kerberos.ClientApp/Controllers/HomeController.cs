using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.ClientApp.ApiServices.Interfaces;
using Kerberos.DataTransferObject;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kerberos.ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;  
        }
        [JwtAuthorize(Roles ="Admin, Member")]
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }
        [JwtAuthorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProductDto model)
        {
            if(ModelState.IsValid)
            {
                await _productService.AddAsync(model);
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {   
            return View(await _productService.GetByIdAsync(id));
        }
        [HttpPost]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpDelete]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
