using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kerberos.Business.Interfaces;
using Kerberos.Business.StringInfo;
using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpGet]
        [Authorize(Roles = RoleInfo.Admin)]
        [ServiceFilter(typeof(IsValidIdActionFilter<Product>))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }
        [HttpPost]
        [Authorize(Roles = RoleInfo.Admin)]
        [IsValidActionFilter]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created("", productDto);
        }
        [HttpPut]
        [Authorize(Roles = RoleInfo.Admin)]
        [IsValidActionFilter]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        [Route("Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // errorInfo.Error.Message
            // loglama
            return Problem(detail: "An exception is occured in server side.");
        }
    }
}
