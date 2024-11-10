using Domain.Entities.Catalog.Payment;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog
{
    public class User :IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? Username { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Telephone { get; set; }

        // Relationships
        public virtual ICollection<UserPayment> User_Payments { get; set; } = new List<UserPayment>();
        public virtual ICollection<User_address> User_Addresses { get; set; } = new List<User_address>();

    }
}
