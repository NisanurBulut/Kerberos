﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataTransferObject
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
