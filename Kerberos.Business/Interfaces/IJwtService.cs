using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Kerberos.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser appUser, List<AppRole> roles);
        List<Claim> GetClaims(AppUser appUser, List<AppRole> roles);
    }
}
