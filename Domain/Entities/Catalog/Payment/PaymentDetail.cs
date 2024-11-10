using Domain.Entities.Catalog.Order;
using Domain.Entities.Common;
using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Payment
{
    [Table("PaymentDetails",Schema ="payment")]
    public class PaymentDetail : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Amount { get; set; }

        [StringLength(100)]
        public string? Provider { get; set; }
        public Payment_Status Status { get; set; } // pending , paid

        // Relationships

        [ForeignKey("OrderId")]
        public OrderDetail Order { get; set; } = new OrderDetail();

    }
}
