
namespace OnlineShopCQRS.Application.Users.Commands.DeleteUser
{
    using MediatR;

    namespace OnlineShopCQRS.Application.Users.Commands.DeleteUser
    {
        public class DeleteUserCommand : IRequest<int>
        {
            public int Id { get; set; }
        }
    }

}
