using KingHotel.Domain.IService.Auth;
using KingHotel.Domain.IService.Payments;
using KingHotel.Infraestructure.Services.Auth;
using KingHotel.Infraestructure.Services.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace KingHotel.Infraestructure.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
