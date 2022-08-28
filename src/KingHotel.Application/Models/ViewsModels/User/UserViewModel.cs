namespace KingHotel.Application.Models.ViewsModels.User
{
    public class UserViewModel
    {
        public UserViewModel(string name, string email, string zipCode, int document)
        {
            Name = name;
            Email = email;
            ZipCode = zipCode;
            Document = document;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string ZipCode { get; private set; }
        public int Document { get; private set; }
    }
}
