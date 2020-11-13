using Kerberos.Business.Interfaces;
using Kerberos.DataAccess.Interfaces;
using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using System.Threading.Tasks;

namespace Kerberos.Business.Concrete
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserService
    {
        private readonly IAppUserRepository _appUserRepo;
        public AppUserManager(IBaseRepository<AppUser> baseRepo, IAppUserRepository appUserRepo) : base(baseRepo)
        {
            _appUserRepo = appUserRepo;
        }

        public async Task<bool> CheckPassword(AppUserLoginDto userLoginDto)
        {
            var user = await _appUserRepo.GetByFilterAsync(a => a.UserName == userLoginDto.UserName);
            return user.Password == userLoginDto.Password ? true : false;
        }

        public async Task<AppUser> FindByUserName(string userName)
        {
            return await _appUserRepo.GetByFilterAsync(a => a.UserName == userName);
        }
    }
}
