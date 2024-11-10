using Domain.Entities.Catalog.Payment;
using Domain.Entities.Common;
using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Order
{
    [Table("OrderDetails",Schema ="order")]
    public class OrderDetail : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }

        public OrderStatus Status { get; set; } // "Pending", "Shipped", "Delivered", etc.

        // Relationships
        [ForeignKey("PaymentId")]
        public PaymentDetail Payment { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
