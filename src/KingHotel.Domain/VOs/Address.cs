using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Domain.VOs
{
    public class Address
    {
        public Address(string number, string street, string city, string zipCode)
        {
            Number = number;
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public string Number { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
    }
}
