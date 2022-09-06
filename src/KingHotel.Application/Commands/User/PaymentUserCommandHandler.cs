using KingHotel.Domain.DTOs.Payments;
using KingHotel.Domain.IRepository;
using KingHotel.Domain.IService.Payments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Application.Commands.User
{
    public class PaymentUserCommandHandler : IRequestHandler<PaymentUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaymentService _paymentService;

        public PaymentUserCommandHandler(IUserRepository userRepository, IPaymentService paymentService)
        {
            _userRepository = userRepository;
            _paymentService = paymentService;
        }

        public async Task<bool> Handle(PaymentUserCommand request, CancellationToken cancellationToken)
        {
            var userPayment = await _userRepository.GetById(request.Id);

            userPayment.Finish();

            var paymentInfoDto = new PaymentInfoDTO(userPayment.Id, request.Number, request.Cvv, request.Expires, request.Name, request.Amount);

            var result = await _paymentService.ProcessPayment(paymentInfoDto);

            if(!result)
            userPayment.SetPaymentPending();

            await _userRepository.SaveChanges();

            return true;
        }
    }
}
