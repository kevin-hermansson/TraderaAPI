using TraderaAPI.Data.Models;
namespace TraderaAPI.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
    }
}
