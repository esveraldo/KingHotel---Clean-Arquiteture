using KingHotel.Application.Services.Interfaces.AuthService;
using KingHotel.Infraestructure.Services.Auth;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Infraestructure.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
