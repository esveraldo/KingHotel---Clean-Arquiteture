using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Domain.DTOs.Payments
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(Guid id, string number, string cvv, string expires, string name, decimal amount)
        {
            Id = id;
            Number = number;
            Cvv = cvv;
            Expires = expires;
            Name = name;
            Amount = amount;
        }

        public Guid Id { get; private set; }
        public string Number { get; private set; }
        public string Cvv { get; private set; }
        public string Expires { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
    }
}
