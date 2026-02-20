using TraderaAPI.DTOs;
namespace TraderaAPI.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> RegisterAsync(UserRegisterDto dto);
        Task<UserDto?> LoginAsync(UserLoginDto dto);
    }
}
