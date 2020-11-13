using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.DataAccess.Interfaces
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}
