using Kerberos.ClientApp.ApiServices.Interfaces;
using Kerberos.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kerberos.ClientApp.ApiServices.Concrete
{
    public class ProductManager : IProductService
    {
        // buraya token gelmeli, bu sebeple sessiona erişmeli
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<ProductDto>> GetAllAsync()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                using var httpClient = new HttpClient();
                // http clientin default header'a token eklenmeli
                // AuthenticationHeaderValue ilk parametre şemadır
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await httpClient.GetAsync("http://localhost:56789/api/product");
                if(responseMessage.IsSuccessStatusCode)
                {
                   return JsonConvert.DeserializeObject<List<ProductDto>>(await responseMessage.Content.ReadAsStringAsync());
                }
            }
            return null;
        }
    }
}
