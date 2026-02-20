using TraderaAPI.Core.Interfaces;
using TraderaAPI.Data.Interfaces;
using TraderaAPI.DTOs;
using TraderaAPI.Data.Models;
using System.Xml;
namespace TraderaAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<UserDto?> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepo.GetByEmailAsync(dto.Email);

            if (existingUser != null) return null;

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password };

            var created = await _userRepo.AddAsync(user);

            return new UserDto
            {
                Id = created.Id,
                Name = created.Name,
                Email = created.Email
            };
        }
        public async Task<UserDto?> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            if(user == null)
                return null;

            if(user.Password != dto.Password) 
                return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

    }
}
