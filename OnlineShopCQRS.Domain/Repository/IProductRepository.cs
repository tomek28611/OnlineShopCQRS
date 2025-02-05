
using OnlineShopCQRS.Domain.Entity;

namespace OnlineShopCQRS.Domain.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAllProductsAsync();
        Task<ProductEntity> GetProductByIdAsync(int id);
        Task<ProductEntity> CreateProductAsync(ProductEntity product);
        Task<int> UpdateProductAsync(int id, ProductEntity product);
        Task<int> DeleteProductAsync(int id);
    }
}
