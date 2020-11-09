using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Entities.Concrete
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
