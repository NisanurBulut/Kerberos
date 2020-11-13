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
        private readonly IBaseRepository<AppRole> _baseRepo;
        public AppRoleManager(IBaseRepository<AppRole> baseRepo) : base(baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<AppRole> FindRoleByName(string roleName)
        {
            await _baseRepo.GetByFilterAsync(a => a.Name == roleName);
        }
    }
}
