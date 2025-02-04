using Domain.Entities.Catalog.Payment;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Catalog
{
    public class ApplicationUser : IdentityUser 
    {
        public string FullName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        //public Guid? CreatedBy { get; set; }
        //public Guid? LastModifiedBy { get; set; }
        //public DateTime? LastModifiedOn { get; set; }
        //public DateTime? DeletedOn { get; set; }

        // Relationships
        public virtual ICollection<UserPayment> User_Payments { get; set; } = new List<UserPayment>();
        public virtual ICollection<User_address> User_Addresses { get; set; } = new List<User_address>();

    }
}
