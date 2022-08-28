using KingHotel.Application.Models.ViewsModels.User;
using KingHotel.Domain.IRepository;
using MediatR;

namespace KingHotel.Application.Queries.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            var userViewModel = users.Select(x => new UserViewModel(x.Name, x.Email, x.Address.ZipCode, (int)x.Document)).ToList();

            return userViewModel;
        }
    }
}
