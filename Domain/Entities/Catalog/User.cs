using Domain.Entities.Catalog.Payment;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Catalog
{
    public class User : IdentityUser 
    {
        public string FullName { get; set; }

        //public Guid? CreatedBy { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public Guid? LastModifiedBy { get; set; }
        //public DateTime? LastModifiedOn { get; set; }
        //public DateTime? DeletedOn { get; set; }

        //[StringLength(100)]
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public int Telephone { get; set; }

        // Relationships
        public virtual ICollection<UserPayment> User_Payments { get; set; } = new List<UserPayment>();
        public virtual ICollection<User_address> User_Addresses { get; set; } = new List<User_address>();

    }
}
