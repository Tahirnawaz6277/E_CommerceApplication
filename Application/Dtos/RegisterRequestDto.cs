using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.Entities.Dtos
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
  
        [Required(ErrorMessage = "PhoneNumber is required.")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "Enter Phone Number with 8 to 15 digits.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } // "Admin" or "Customer"
    }
}
