using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.Business.Interfaces;
using Kerberos.Entities.Concrete;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kerberos.WebAPI.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpGet]
        [ServiceFilter(typeof(IsValidIdActionFilter<Product>))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }
    }
}
