using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Application.Services.Interfaces.AuthService
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputedSha256Hash(string password);
    }
}
