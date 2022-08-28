using KingHotel.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(Guid id);
        Task SaveChanges();
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
