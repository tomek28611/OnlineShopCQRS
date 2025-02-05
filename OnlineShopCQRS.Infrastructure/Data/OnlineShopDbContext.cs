
using Microsoft.EntityFrameworkCore;
using OnlineShopCQRS.Domain.Entity;

namespace OnlineShopCQRS.Infrastructure.Data
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
