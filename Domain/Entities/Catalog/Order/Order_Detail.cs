using Domain.Entities.Catalog.Payment;
using Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Order
{
    public class Order_Detail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        //[StringLength(255)]
        //public string ShippingAddress { get; set; }
        public OrderStatus Status { get; set; } // "Pending", "Shipped", "Delivered", etc.

        // Relationships
        [ForeignKey("PaymentId")]
        public Payment_Detail? Payment { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
