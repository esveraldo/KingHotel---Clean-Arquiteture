using KingHotel.Application.Models.ViewsModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Application.Queries.Users
{
    public class GetByIdUserQuery : IRequest<UserDetailsViewModel>
    {
        public GetByIdUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
