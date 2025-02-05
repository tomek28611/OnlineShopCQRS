

using MediatR;
using OnlineShopCQRS.Application.Users.Queries.Dto;

namespace OnlineShopCQRS.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
