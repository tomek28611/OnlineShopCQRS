

using OnlineShopCQRS.Application.Common.Mappings;
using OnlineShopCQRS.Domain.Entity;

namespace OnlineShopCQRS.Application.Users.Queries.Dto
{
    public class UserDto : IMapFrom<UserEntity>
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }

        public DateTime? RegisterDate { get; set; }

        public int? RecoveryCode { get; set; }
    }
}
