namespace E_Commerce.Application.DTOS.AuthDto
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
