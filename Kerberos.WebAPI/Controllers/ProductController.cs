using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kerberos.Business.Interfaces;
using Kerberos.Entities.Concrete;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Kerberos.WebAPI.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
        [Route("Error")]
        public IActionResult Error()
        {
            var errorInfo=HttpContext.Features.Get<IExceptionHandlerPathFeature>();
           // errorInfo.Error.Message
           // loglama
            return Problem(detail:"An exception is occured in server side.");
        }
    }
}
