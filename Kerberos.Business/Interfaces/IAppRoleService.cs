using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Business.Interfaces
{
    public interface IAppRoleService : IBaseService<AppRole>
    {
        Task<AppRole> FindRoleByName(string roleName);
    }
}
