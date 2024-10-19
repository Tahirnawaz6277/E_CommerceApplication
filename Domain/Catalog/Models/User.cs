using System.ComponentModel.DataAnnotations;

namespace Domain.Catalog.Models
{
    public class User
    {
        [StringLength(100)]
        public string Username { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Can be either "Admin" or "Customer"
        public DateTime DateCreated { get; set; }
    }
}
