

using Microsoft.EntityFrameworkCore;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Repository;
using OnlineShopCQRS.Infrastructure.Data;

namespace OnlineShopCQRS.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineShopDbContext _context;


        public UserRepository(OnlineShopDbContext context)
        {
            _context = context;

        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await _context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateUserAsync(int id, UserEntity user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userToUpdate == null) return 0;

            foreach (var property in typeof(UserEntity).GetProperties())
            {
                if (property.CanWrite)
                {
                    var newValue = property.GetValue(user);
                    property.SetValue(userToUpdate, newValue);
                }
            }

            _context.Users.Update(userToUpdate);
            return await _context.SaveChangesAsync();
        }
    }
}
