namespace KingHotel.Domain.IService.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputedSha256Hash(string password);
    }
}
