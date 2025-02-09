using E_Commerce.Application.Common.Marker;

namespace E_Commerce.Application.DTOS.AuthDto
{
    public class LoginRequest : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
