using KingHotel.Application.Services.Interfaces.AuthService;
using KingHotel.Domain.Enums;
using KingHotel.Domain.IRepository;
using KingHotel.Domain.VOs;
using MediatR;

namespace KingHotel.Application.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputedSha256Hash(request.Password);
            var address = new Address(request.Number, request.Street, request.City, request.ZipCode);
            var user = new Domain.Entity.User(request.Name, request.Email, passwordHash, request.Role, address, (DocumentEnum)request.Document);

            await _userRepository.Create(user);

            return user.Id;
        }
    }
}
