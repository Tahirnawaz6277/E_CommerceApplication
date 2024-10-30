using Domain.Entities.Catalog.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }
        public OrderStatus Status { get; set; } // "Pending", "Shipped", "Delivered", etc.

        // Relationships
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
