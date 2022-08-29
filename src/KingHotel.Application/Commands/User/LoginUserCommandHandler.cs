using KingHotel.Application.Models.ViewsModels.User;
using KingHotel.Domain.IRepository;
using KingHotel.Domain.IService.Auth;
using MediatR;

namespace KingHotel.Application.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utilizar o mesmo algoritimo para criar o hash dessa senha
            var passwordHash = _authService.ComputedSha256Hash(request.Password);
            //Buscar no banco de dados um usuário que tenha o email e senha em formato hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            //Se não existir erro no login
            if (user == null)
            {
                return null;
            }
            //Se exister gerar token com dados do usuario
            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
