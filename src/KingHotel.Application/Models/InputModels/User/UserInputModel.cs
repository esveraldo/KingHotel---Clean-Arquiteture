using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Application.Models.InputModels.User
{
    public class UserInputModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Number { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public int Document { get; set; }
    }
}
