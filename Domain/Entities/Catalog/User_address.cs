using Domain.Entities.Common;

namespace Domain.Entities.Catalog
{
    public class User_address : AuditableEntity
    {
        public Guid User_addressId { get; set; }

        public string UserId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string PhoneNumber { get; set; }

        // navigation properties

        //public User User { get; set; }


    }
}
