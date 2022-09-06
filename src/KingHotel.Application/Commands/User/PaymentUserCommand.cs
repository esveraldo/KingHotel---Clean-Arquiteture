using MediatR;

namespace KingHotel.Application.Commands.User
{
    public class PaymentUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Cvv { get; set; }
        public string Expires { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
