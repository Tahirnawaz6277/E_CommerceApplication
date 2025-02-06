namespace E_Commerce.Application.DTOS.AuthDto
{
    public class RegisterResponse
    {
        public string FullName { get; set; }
        public string userId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}