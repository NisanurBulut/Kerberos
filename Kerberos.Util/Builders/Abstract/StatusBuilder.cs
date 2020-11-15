using Kerberos.DataTransferObject;
using Kerberos.Util.Builders.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Util.Builders.Abstract
{
    // builder pattern front endt tarafta en sık kullanılan design pattern'dir
    public abstract class StatusBuilder
    {
        // active user ve accepted roller bana gerekli
        public abstract Status GenerateStatus(AppUserDto activeUser, string roles);
    }
}
