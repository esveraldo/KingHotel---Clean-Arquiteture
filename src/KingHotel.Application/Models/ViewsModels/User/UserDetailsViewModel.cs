namespace KingHotel.Application.Models.ViewsModels.User
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string name, string email, string number, string street, string city, string zipCode, int document)
        {
            Name = name;
            Email = email;
            Number = number;
            Street = street;
            City = city;
            ZipCode = zipCode;
            Document = document;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public int Document { get; private set; }
    }
}
