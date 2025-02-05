
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopCQRS.Domain.Repository;
using OnlineShopCQRS.Infrastructure.Data;
using OnlineShopCQRS.Infrastructure.Repository;

namespace OnlineShopCQRS.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContextFactory<OnlineShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")) 
            );

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;

        }
    }
}
