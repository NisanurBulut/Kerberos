using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.Business.Interfaces
{
    public interface IAppUserService:IBaseService<AppUser>
    {
        Task<AppUser> FindByUserName(string userName);
        Task<bool> CheckPassword(AppUserLoginDto userLoginDto);
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}
