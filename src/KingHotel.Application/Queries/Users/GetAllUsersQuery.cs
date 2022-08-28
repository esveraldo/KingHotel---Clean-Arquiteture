using KingHotel.Application.Models.ViewsModels.User;
using MediatR;

namespace KingHotel.Application.Queries.Users
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery()
        {
        }
    }
}
