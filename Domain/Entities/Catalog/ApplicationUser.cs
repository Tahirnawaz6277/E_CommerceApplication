using Domain.Entities.Catalog.Payment;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Catalog
{
    public class ApplicationUser : IdentityUser 
    {
        public string FullName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Role { get; set; }

        // Relationships
        public virtual ICollection<UserPayment> User_Payments { get; set; } = new List<UserPayment>();
        public virtual ICollection<User_address> User_Addresses { get; set; } = new List<User_address>();

    }
}
