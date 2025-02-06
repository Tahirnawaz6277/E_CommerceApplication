using E_Commerce.Application.DTOS.AuthDto;
using E_Commerce.Application.Interfaces.IAuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace E_Commerce.Api.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistorRequest userData)
        {
            
            if (userData is null)
            {
                return BadRequest("userData cannot be null");
            }
            var user = await _userService.Register(userData);

            return user.IsSuccess
                ? Ok(user)
                : BadRequest(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {

            var key = new byte[32]; // 256-bit key
            RandomNumberGenerator.Fill(key);
            var base64Key = Convert.ToBase64String(key); // Use this as your JWT key

            Console.WriteLine(base64Key);
            if (loginRequest is null)
            {
                return BadRequest("Login request cannot be null");
            }
            var user = await _userService.Login(loginRequest);

            return user.IsSuccess
                ? Ok(user)
                : BadRequest(user);
        }
    }
}