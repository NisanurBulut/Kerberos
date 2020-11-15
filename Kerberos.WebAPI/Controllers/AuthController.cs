using AutoMapper;
using Kerberos.Business.Interfaces;
using Kerberos.Business.StringInfo;
using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using Kerberos.Entities.Token;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Kerberos.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
       
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("Belirsiz kullanıcı adı ya da şifre hatalı");
            }
            if (await _appUserService.CheckPassword(appUserLoginDto))
            {
                var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                var token = _jwtService.GenerateJwt(appUser, roles);
                JwtAccessToken jwtAccessToken = new JwtAccessToken();
                jwtAccessToken.Token = token;
                return Created("", jwtAccessToken);
            }
            return BadRequest("Belirsiz kullanıcı adı ya da şifre hatalı");
        }
        [HttpPost(("[action]"))]
        [IsValidActionFilter]
        public async Task<IActionResult> SignUp(AppUserDto appUserDto,
            [FromServices] IAppUserRoleService appUserRoleService,
            [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByUserName(appUserDto.UserName);
            if (appUser != null)
                return BadRequest($"{appUser.UserName} kullanılıyor.");

            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserDto));
            var user = await _appUserService.FindByUserName(appUser.UserName);
            var role = await appRoleService.FindRoleByName(RoleInfo.Member);
            await appUserRoleService.AddAsync(
                new AppUserRole
                {
                    AppRoleId = role.Id,
                    AppUserId = user.Id
                });
            return Created("", "");
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(User.Identity.Name);
            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };
            return Ok(appUserDto);
        }
    }
}
