using Microsoft.EntityFrameworkCore;
using TestCore.Dto;
using TestCore.Dto.Request;
using TestCore.Interfaces;
using TestData;
using TestData.Entities;

namespace TestCore.Services
{
    public class ProductServices : IProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Create(CreateProductRequest productDto)
        {

            var product = new Product
            {
                Description = productDto.Description,
                Name = productDto.Name,
                NetPrice = productDto.NetPrice,
            };

            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task Update(ProductRequest productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Description = productDto.Description,
                Name = productDto.Name,
                NetPrice = productDto.NetPrice,
            };

             _applicationDbContext.Products.Update(product);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await _applicationDbContext.Products.FindAsync(id);
            if (product != null) {
                _applicationDbContext.Products.Remove(product);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
        public async Task<List<ProductResult>> GetProducts()
        {
            var products =  await _applicationDbContext.Products
                .Select(d=> new ProductResult
                {
                  Id = d.Id,
                  Description = d.Description,
                  Name= d.Name, 
                  NetPrice = d.NetPrice
                
                }).ToListAsync();

            return products;
        }
        public async Task<ProductResult> GetProductById(int id)
        {
            var products = await _applicationDbContext.Products
                .Select(d => new ProductResult
                {
                    Id = d.Id,
                    Description = d.Description,
                    Name = d.Name,
                    NetPrice = d.NetPrice

                }).Where(e=> e.Id == id)
                .FirstOrDefaultAsync();

            return products;
        }

    }
}
