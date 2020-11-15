using Kerberos.DataTransferObject;
using Kerberos.Util.Builders.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Util.Builders.Concrete
{
    public class StatusBuilderDirector
    {
        private StatusBuilder builder;
        public StatusBuilderDirector(StatusBuilder statusBuilder)
        {
            builder = statusBuilder;
        }
        public Status CallGenerateStatus(AppUserDto activeUser, string roles)
        {
            return this.builder.GenerateStatus(activeUser, roles);
        }
    }
}
