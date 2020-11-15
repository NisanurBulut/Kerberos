using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.ClientApp.ApiServices.Interfaces;
using Kerberos.DataTransferObject;
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
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto model)
        {
            if(ModelState.IsValid)
            {
                await _productService.AddAsync(model);
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await _productService.GetByIdAsync(id));
        }
    }
}
