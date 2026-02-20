using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraderaAPI.Core.Interfaces;
using TraderaAPI.DTOs;

namespace TraderaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var result = await _userService.RegisterAsync(dto);

            if (result == null)
                return BadRequest("User already exists");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
    }
}

