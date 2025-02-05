using Microsoft.EntityFrameworkCore;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Repository;
using OnlineShopCQRS.Infrastructure.Data;

namespace OnlineShopCQRS.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<OnlineShopDbContext> _contextFactory;

        public UserRepository(IDbContextFactory<OnlineShopDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateUserAsync(int id, UserEntity user)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var userToUpdate = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userToUpdate == null) return 0;

            foreach (var property in typeof(UserEntity).GetProperties())
            {
                if (property.CanWrite)
                {
                    var newValue = property.GetValue(user);
                    property.SetValue(userToUpdate, newValue);
                }
            }

            context.Users.Update(userToUpdate);
            return await context.SaveChangesAsync();
        }
    }
}
