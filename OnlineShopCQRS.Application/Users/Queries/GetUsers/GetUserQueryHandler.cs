
using AutoMapper;
using MediatR;
using OnlineShopCQRS.Application.Users.Queries.Dto;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Users.Queries.GetUsers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users == null || !users.Any())
            {
                throw new NotFoundException("No users available.");
            }

            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
