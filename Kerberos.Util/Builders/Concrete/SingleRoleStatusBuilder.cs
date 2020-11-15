using Kerberos.DataTransferObject;
using Kerberos.Util.Builders.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Util.Builders.Concrete
{
    public class SingleRolestatusBuilder : StatusBuilder
    {
        public override Status GenerateStatus(AppUserDto activeUser, string roles)
        {
            Status access = new Status();
            if (activeUser.Roles.Contains(roles))
            {
                access.AccessStatus = true;
            }
            return access;
        }
    }
}
