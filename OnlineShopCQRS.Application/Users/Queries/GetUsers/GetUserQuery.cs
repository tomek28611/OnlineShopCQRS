
using MediatR;
using OnlineShopCQRS.Application.Users.Queries.Dto;

namespace OnlineShopCQRS.Application.Users.Queries.GetUsers
{
    public class GetUserQuery : IRequest<List<UserDto>>
    {
    }
}
