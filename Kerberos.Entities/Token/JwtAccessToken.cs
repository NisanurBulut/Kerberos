using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
