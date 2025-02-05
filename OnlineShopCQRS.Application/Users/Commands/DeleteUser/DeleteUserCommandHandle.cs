
using MediatR;
using OnlineShopCQRS.Application.Users.Commands.DeleteUser.OnlineShopCQRS.Application.Users.Commands.DeleteUser;
using OnlineShopCQRS.Domain.Exceptions;
using OnlineShopCQRS.Domain.Repository;

namespace OnlineShopCQRS.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                throw new NotFoundException($"User with ID {request.Id} does not exist.");
            }

            var deletedCount = await _userRepository.DeleteUserAsync(request.Id);

            return deletedCount;
        }
    }
}
