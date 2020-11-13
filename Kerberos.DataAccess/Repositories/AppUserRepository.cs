using Kerberos.DataAccess.Context;
using Kerberos.DataAccess.Interfaces;
using Kerberos.Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kerberos.DataAccess.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository()
        {

        }
        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            // ef core 5 include.where()
            using var context = new DatabaseContext();
            return await context.tAppUser.Join(context.tAppUserRoles, u => u.Id, ur => ur.AppUserId,
                 (user, userRole) => new
                 {
                     appUser = user,
                     appUserRole = userRole
                 }).Join(context.tAppRole, two => two.appUserRole.AppRoleId, ar => ar.Id,
                 (twoTable, appRole) => new
                 {
                     user = twoTable.appUser,
                     userrole = twoTable.appUserRole,
                     role = appRole
                 }).Where(I => I.user.UserName == userName)
                 .Select(a => new AppRole
                 {
                     Id = a.role.Id,
                     Name = a.role.Name
                 }).ToListAsync();
        }
    }
}
