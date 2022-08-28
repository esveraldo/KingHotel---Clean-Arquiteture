using KingHotel.Application.Models.ViewsModels.User;
using MediatR;

namespace KingHotel.Application.Commands.User
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }    
    }
}
