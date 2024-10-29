using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Catalog.Models
{
    public class User_payment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Payment_type { get; set; }
        public string Provider { get; set; }
        public int Account_No { get; set; }
        public DateTime? Expiry { get; set; }


    }
}
