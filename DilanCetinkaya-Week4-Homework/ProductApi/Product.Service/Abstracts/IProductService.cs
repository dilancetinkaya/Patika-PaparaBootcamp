using Product.Data.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Service.Abstracts
{
    public interface IProductService
    {
        Task AddAsync(ProductDto productDto);
        Task Delete(int id);
        Task Update(ProductDto productDto, int id);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetAsync(int id);
    }
}
