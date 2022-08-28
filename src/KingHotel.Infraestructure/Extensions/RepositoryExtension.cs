using KingHotel.Domain.IRepository;
using KingHotel.Infraestructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Infraestructure.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
