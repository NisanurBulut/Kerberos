using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Business.StringInfo
{
    public class JwtInfo
    {
        public const string Isuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "nisanurnisanur11"; // 16 karakter
        public const double tokenExpiration = 30; 
    }
}
