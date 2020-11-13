using Kerberos.ClientApp.ApiServices.Interfaces;
using Kerberos.ClientApp.Models;
using Kerberos.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kerberos.ClientApp.ApiServices.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> LogIn(AppUserLoginDto model)
        {
            string jsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient
                .PostAsync("http://localhost:56789/api/Auth/SignIn",
                stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var token = JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());
                _httpContextAccessor.HttpContext.Session.SetString("token", token.Token);
                return true;
            }
            return false;
        }
        public void LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("token");
        }
    }
}
