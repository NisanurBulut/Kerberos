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
        private readonly IAppUserService _appUserService;
        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }
        [HttpGet]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if (appUser==null)
            {
                return BadRequest("Belirsiz kullanıcı adı ya da şifre hatalı");
            }
            if(await _appUserService.CheckPassword(appUserLoginDto))
            {
                var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                var token = _jwtService.GenerateJwt(appUser,roles);
                return Created("", "");
            }
            return BadRequest("Belirsiz kullanıcı adı ya da şifre hatalı");
        }
    }
}
