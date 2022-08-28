using KingHotel.Application.Models.ViewsModels.User;
using KingHotel.Domain.IRepository;
using MediatR;

namespace KingHotel.Application.Queries.Users
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetByIdUserQuery, UserDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
     
        public async Task<UserDetailsViewModel> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                return null;
            }

            var userDetailsViewModel = new UserDetailsViewModel(
                user.Name,
                user.Email,
                user.Address.Number,
                user.Address.Street,
                user.Address.City,
                user.Address.ZipCode,
                (int)user.Document
                );

            return userDetailsViewModel;
        }
    }
}
