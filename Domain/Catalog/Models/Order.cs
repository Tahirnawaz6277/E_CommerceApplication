using System.ComponentModel.DataAnnotations;

namespace Domain.Catalog.Models
{
    public class Order
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }
        public string Status { get; set; } // "Pending", "Shipped", "Delivered", etc.

        // Relationships
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
