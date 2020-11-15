using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kerberos.ClientApp.ApiServices.Concrete;
using Kerberos.ClientApp.ApiServices.Interfaces;
using Kerberos.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace Kerberos.ClientApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.LogIn(model))
                {
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı.");
            }
            return View(model);
        }
    }
}
