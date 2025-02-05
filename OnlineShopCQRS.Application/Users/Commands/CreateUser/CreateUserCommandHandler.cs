using AutoMapper;
using MediatR;
using OnlineShopCQRS.Application.Users.Queries.Dto;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new UserCreationException("Email cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                throw new UserCreationException("Full name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
            {
                throw new UserCreationException("Password must be at least 6 characters long.");
            }

            var userEntity = new UserEntity()
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password, 
                IsAdmin = request.IsAdmin,
                RegisterDate = DateTime.UtcNow,
                RecoveryCode = request.RecoveryCode
            };

            var result = await _userRepository.CreateUserAsync(userEntity);
            return _mapper.Map<UserDto>(result);
        }
    }
}
