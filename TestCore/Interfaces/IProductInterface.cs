using TestCore.Dto;
using TestCore.Dto.Request;

namespace TestCore.Interfaces
{
    public interface IProductInterface
    {
        Task Create(CreateProductRequest productDto);
        Task Update(ProductRequest productDto);
        Task Delete(int id);
        Task<List<ProductResult>> GetProducts();
        Task<ProductResult> GetProductById(int id);
    }
}
