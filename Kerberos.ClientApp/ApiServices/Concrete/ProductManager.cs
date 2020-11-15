using Kerberos.ClientApp.ApiServices.Interfaces;
using Kerberos.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task AddAsync(ProductDto model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                string jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await httpClient.
                PostAsync("http://localhost:56789/api/Product/Add", stringContent);

            }
        }
        public async Task DeleteAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await httpClient.
                DeleteAsync($"http://localhost:56789/api/Product/{id}");
            }
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
                var responseMessage = await httpClient.GetAsync("http://localhost:56789/api/Product");
                if(responseMessage.IsSuccessStatusCode)
                {
                   return JsonConvert.DeserializeObject<List<ProductDto>>(await responseMessage.Content.ReadAsStringAsync());
                }
            }
            return null;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                using var httpClient = new HttpClient();
                // http clientin default header'a token eklenmeli
                // AuthenticationHeaderValue ilk parametre şemadır
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await httpClient.GetAsync($"http://localhost:56789/api/Product/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result= JsonConvert.DeserializeObject<ProductDto>(await responseMessage.Content.ReadAsStringAsync());
                    return result;
                }
            }
            return null;
        }

        public async Task UpdateAsync(ProductDto model)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                string jsonData = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await httpClient.
                PutAsync("http://localhost:56789/api/Product/Update", stringContent);

            }
        }
    }
}
