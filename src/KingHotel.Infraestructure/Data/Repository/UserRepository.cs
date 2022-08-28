using KingHotel.Domain.Entity;
using KingHotel.Domain.IRepository;
using KingHotel.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KingHotel.Infraestructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly KingHotelContext _kingHotelContext;

        public UserRepository(KingHotelContext kingHotelContext)
        {
            _kingHotelContext = kingHotelContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _kingHotelContext.Users.ToListAsync();
        }
        public async Task<User?> GetById(Guid id)
        {
            return await _kingHotelContext.Users.SingleOrDefaultAsync(x => x.Id == id); 
        }
        public async Task Create(User user)
        {
            await _kingHotelContext.AddAsync(user);
            await SaveChanges();
        }

        public async Task Update(User user)
        {
            _kingHotelContext.Update(user);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var obj = await GetById(id);

            if (obj != null)
            {
                _kingHotelContext.Remove(obj);
                await SaveChanges();
            }
        }

        public async Task SaveChanges()
        {
            await _kingHotelContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _kingHotelContext.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
