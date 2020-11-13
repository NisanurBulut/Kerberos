using Kerberos.DataTransferObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerberos.ClientApp.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> LogIn(AppUserLoginDto model);
        void LogOut();
    }
}
