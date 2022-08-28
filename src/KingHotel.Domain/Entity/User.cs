using KingHotel.Domain.Enums;
using KingHotel.Domain.VOs;

namespace KingHotel.Domain.Entity
{
    public class User : Base
    {
        public User()
        {

        }
        public User(string name, string email, string password, string role, Address address, DocumentEnum document)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Address = address;
            Document = document;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Address Address { get; private set; }
        public DocumentEnum Document { get; private set; }

        public void UpdatedAtMethod()
        {
            UpdatedAt = DateTime.Now;
        }

        public void UpdateUser(string name, string email, string password, string role, string number, string street, string city, string zipCode, int document)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            new Address(number, street, city, zipCode);
            Document = (DocumentEnum)document;

            UpdatedAtMethod();
        }
    }
}
