using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Models
{
    public class User_address
    {
        [Key]
        public Guid Id { get; set; }

        public Guid  UserId { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Telephone { get; set; }

        // navigation properties
        [ForeignKey("UserId")]
        public User user { get; set; }


    }
}
