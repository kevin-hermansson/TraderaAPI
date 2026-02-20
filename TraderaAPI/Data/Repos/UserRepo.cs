using Microsoft.EntityFrameworkCore;
using TraderaAPI.Data.Interfaces;
using TraderaAPI.Data.Models;

namespace TraderaAPI.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly TraderaDbContext _db;
        public UserRepo(TraderaDbContext db)
        {
            _db = db;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

    }
}
