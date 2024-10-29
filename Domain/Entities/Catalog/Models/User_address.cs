using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Models
{
    public class User_address
    {
        public Guid Id { get; set; }

        public Guid  UserId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }

        // navigation properties
        [ForeignKey("UserId")]
        public User user { get; set; }


    }
}
