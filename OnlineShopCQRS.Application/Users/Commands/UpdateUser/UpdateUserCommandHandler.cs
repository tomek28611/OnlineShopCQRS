
using MediatR;
using OnlineShopCQRS.Domain.Entity;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new UserUpdateException("Email cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                throw new UserUpdateException("Full name cannot be empty.");
            }

            var updateUserEntity = new UserEntity()
            {
                Id = request.Id,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                IsAdmin = request.IsAdmin ?? false,
                RegisterDate = request.RegisterDate,
                RecoveryCode = request.RecoveryCode
            };

            return await _userRepository.UpdateUserAsync(request.Id, updateUserEntity);
        }
    }
}
