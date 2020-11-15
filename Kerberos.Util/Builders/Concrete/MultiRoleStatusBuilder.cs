using Kerberos.DataTransferObject;
using Kerberos.Util.Builders.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Util.Builders.Concrete
{
    public class MultiRolestatusBuilder : StatusBuilder
    {

        public override Status GenerateStatus(AppUserDto activeUser, string roles)
        {
            Status access = new Status();
            if (roles.Contains(","))
            {
                var acceptedRoles = roles.Split(",");
                foreach (var role in acceptedRoles)
                {
                    if (activeUser.Roles.Contains(role))
                    {
                        access.AccessStatus = true;
                        break;
                    }
                }
            }
            return access;
        }
    }
}
