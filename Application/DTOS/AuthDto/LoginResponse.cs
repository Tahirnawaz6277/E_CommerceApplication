using E_Commerce.Application.Common.Marker;

namespace E_Commerce.Application.DTOS.AuthDto
{
    public class LoginResponse : IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
