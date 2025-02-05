
using MediatR;

namespace OnlineShopCQRS.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int? RecoveryCode { get; set; }
    }
}
