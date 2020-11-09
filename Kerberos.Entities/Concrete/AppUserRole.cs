using Kerberos.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Entities.Concrete
{
   public class AppUserRole:ITable
    {
        public int Id { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
