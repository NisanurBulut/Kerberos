using Kerberos.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kerberos.ClientApp.ApiServices.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task AddAsync(ProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(int id);
        Task<ProductDto> GetByIdAsync(int id);
    }
}
