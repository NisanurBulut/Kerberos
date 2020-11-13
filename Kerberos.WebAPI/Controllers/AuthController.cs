using AutoMapper;
using Kerberos.Business.Interfaces;
using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kerberos.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
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
        [HttpPost(("[action]"))]
        [IsValidActionFilter]
        public async Task<IActionResult> SignUp(AppUserDto appUserDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserDto.UserName);
            if (appUser != null)
                return BadRequest($"{appUser.UserName} kullanılıyor.");
           await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserDto));
            return Created("", "");
        }
    }
}
