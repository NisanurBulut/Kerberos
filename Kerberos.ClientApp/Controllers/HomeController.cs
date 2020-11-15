using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.ClientApp.ApiServices.Interfaces;
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
    }
}
