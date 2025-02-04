using E_Commerce.Application.Interfaces.IAuthService;
using E_Commerce.Domain.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto userData)
        {
            try
            {
                var user = await _userService.Register(userData);
                return Ok(new { UserId = user.Id, Email = user.Email, Role = userData.Role });

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
