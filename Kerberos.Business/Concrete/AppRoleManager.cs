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
    public class AppRoleManager : BaseManager<AppRole>, IAppRoleService
    {
    
        private readonly IAppRoleRepository _appRoleRepo;
        
        public AppRoleManager(IBaseRepository<AppRole> baseRepo, IAppRoleRepository appRoleRepo) : base(baseRepo)
        {
            _appRoleRepo = appRoleRepo;
        }

        public async Task<AppRole> FindRoleByName(string roleName)
        {
           return await _appRoleRepo.GetByFilterAsync(a => a.Name == roleName);
        }
    }
}
