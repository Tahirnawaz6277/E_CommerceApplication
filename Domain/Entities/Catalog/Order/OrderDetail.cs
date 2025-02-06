using Domain.Entities.Catalog.Payment;
using Domain.Entities.Common;
using Domain.Entities.Enums;

namespace Domain.Entities.Catalog.Order
{
    public class OrderDetail : AuditableEntity
    {
        public OrderDetail()
        {
            OrderItems = new List<OrderItem>();
            User = new ApplicationUser();
            Payment = new PaymentDetail();
        }
        public Guid OrderDetailId { get; set; }
        public string UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }

        public OrderStatus Status { get; set; } // "Pending", "Shipped", "Delivered", etc.

        // Relationships
        public PaymentDetail Payment { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
