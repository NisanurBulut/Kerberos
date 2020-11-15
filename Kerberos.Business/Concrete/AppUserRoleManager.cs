using Kerberos.Business.Interfaces;
using Kerberos.DataAccess.Interfaces;
using Kerberos.Entities.Concrete;
using Kerberos.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Kerberos.Business.Concrete
{
    public class AppUserRoleManager : BaseManager<AppUserRole>, IAppUserRoleService
    {
        private readonly IAppUserRoleRepository _appUserRoleRepo;
        public AppUserRoleManager(IBaseRepository<AppUserRole> baseRepo, IAppUserRoleRepository appUserRoleRepo) : base(baseRepo)
        {
            _appUserRoleRepo = appUserRoleRepo;
        }

        public async Task<bool> CheckExistAppUserRole(AppUserRole appUserRole)
        {
            var result = await _appUserRoleRepo.GetByFilterAsync(a => a.AppRoleId == appUserRole.AppRoleId && a.AppUserId == appUserRole.AppUserId);
            return result == null ? false : true;
        }
    }
}