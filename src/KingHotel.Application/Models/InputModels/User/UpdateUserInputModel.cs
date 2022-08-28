namespace KingHotel.Application.Models.InputModels.User
{
    public class UpdateUserInputModel
    {
        public Guid Id { get; set; }
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
