using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
