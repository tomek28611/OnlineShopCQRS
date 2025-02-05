
using Microsoft.EntityFrameworkCore;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Repository;
using OnlineShopCQRS.Infrastructure.Data;

namespace OnlineShopCQRS.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext _context;
      

        public ProductRepository(OnlineShopDbContext context)
        {
            _context = context;
           
        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
           return await _context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateProductAsync(int id, ProductEntity product)
        {
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productToUpdate == null) return 0;

            foreach (var property in typeof(ProductEntity).GetProperties())
            {
                if (property.CanWrite)
                {
                    var newValue = property.GetValue(product);
                    property.SetValue(productToUpdate, newValue);
                }
            }

            _context.Products.Update(productToUpdate);
            return await _context.SaveChangesAsync();
        }
    }
}
