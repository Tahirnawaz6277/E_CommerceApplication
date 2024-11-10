using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Payment
{
    [Table("UserPayments", Schema = "payment")]
    public class UserPayment : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [StringLength(100)]
        public string Payment_type { get; set; }

        [StringLength(100)]
        public string Provider { get; set; }
        public int Account_No { get; set; }
        public DateTime? Expiry { get; set; }


    }
}
