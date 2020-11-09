using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kerberos.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
