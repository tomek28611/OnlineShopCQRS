

using OnlineShopCQRS.Domain.Entity;

namespace OnlineShopCQRS.Domain.Repository
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<UserEntity> GetUserByIdAsync(int id);
        Task<UserEntity> CreateUserAsync(UserEntity user);
        Task<int> UpdateUserAsync(int id, UserEntity user);
        Task<int> DeleteUserAsync(int id);
    }
}
 