using KingHotel.Domain.IRepository;
using KingHotel.Domain.IService.Auth;
using MediatR;

namespace KingHotel.Application.Commands.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUser = await _userRepository.GetById(request.Id);
            if (updateUser == null)
                return Guid.Empty;

            var passwordHash = _authService.ComputedSha256Hash(request.Password);
            updateUser.UpdateUser(request.Name, request.Email, passwordHash, request.Role, request.Number, request.Street, request.City, request.ZipCode, request.Document, request.Status);
            //await _userRepository.Update(updateUser);
            await _userRepository.SaveChanges();

            return updateUser.Id;
        }
    }
}
