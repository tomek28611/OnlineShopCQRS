
using AutoMapper;
using MediatR;
using OnlineShopCQRS.Application.Users.Queries.Dto;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException($"User ID {request.UserId} not exist.");
            }
            return _mapper.Map<UserDto>(user);
        }
    }
}
