using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Entities.Concrete
{
   public class AppRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
