﻿using Kerberos.Business.Interfaces;
using Kerberos.DataAccess.Interfaces;
using Kerberos.Entities.Concrete;
using Kerberos.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Kerberos.Business.Concrete
{
    public class AppUserRoleManager<TEntity> : BaseManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IBaseRepository<AppUserRole> baseRepo) : base(baseRepo)
        {
        }
    }
}
