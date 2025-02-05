

using MediatR;
using OnlineShopCQRS.Application.Users.Queries.Dto;

namespace OnlineShopCQRS.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
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
