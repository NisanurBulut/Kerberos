using Kerberos.Business.StringInfo;
using Kerberos.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Kerberos.Business.Interfaces;

namespace Kerberos.Business.Concrete
{
    public class JwtManager:IJwtService
    {
        public string GenerateJwt(AppUser appUser, List<AppRole> roles)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtInfo.Isuer,
                audience: JwtInfo.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfo.tokenExpiration),
                signingCredentials: credentials,
                claims: GetClaims(appUser, roles));

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);

            // claims kullanıcı bilgileri
        }
        public List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Name));
            }
            return claims;
        }
    }
}
