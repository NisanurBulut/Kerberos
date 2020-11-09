using Kerberos.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Entities.Concrete
{
    public class AppRole : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
