using Microsoft.EntityFrameworkCore;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Repository;
using OnlineShopCQRS.Infrastructure.Data;

namespace OnlineShopCQRS.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<OnlineShopDbContext> _contextFactory;

        public ProductRepository(IDbContextFactory<OnlineShopDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateProductAsync(int id, ProductEntity product)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var productToUpdate = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productToUpdate == null) return 0;

            foreach (var property in typeof(ProductEntity).GetProperties())
            {
                if (property.CanWrite)
                {
                    var newValue = property.GetValue(product);
                    property.SetValue(productToUpdate, newValue);
                }
            }

            context.Products.Update(productToUpdate);
            return await context.SaveChangesAsync();
        }
    }
}
