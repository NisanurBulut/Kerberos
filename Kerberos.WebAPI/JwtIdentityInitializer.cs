using Kerberos.Business.Interfaces;
using Kerberos.Business.StringInfo;
using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerberos.WebAPI
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindRoleByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.AddAsync(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }
            var memberRole = await appRoleService.FindRoleByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.AddAsync(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("nisanur");
            if (adminUser == null)
            {
                await appUserService.AddAsync(new AppUser
                {
                    UserName="nisanur",
                    FullName="nisanur bulut",
                    Password="1"
                });
            }
            var role = await appRoleService.FindRoleByName(RoleInfo.Admin);
            var user = await appUserService.FindByUserName("nisanur");
            await appUserRoleService.AddAsync(new AppUserRole
            {
                AppUserId = user.Id,
                AppRoleId=role.Id
            });
        }
    }
}
