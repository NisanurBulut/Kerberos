using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.Business.Interfaces;
using Kerberos.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace Kerberos.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpGet]
        public IActionResult SignIn(AppUserLoginDto appUserLoginDto)
        {


            return Created("","");
        }
    }
}
