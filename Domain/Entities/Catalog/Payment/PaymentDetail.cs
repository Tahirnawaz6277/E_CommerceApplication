using Domain.Entities.Catalog.Order;
using Domain.Entities.Common;
using Domain.Entities.Enums;

namespace Domain.Entities.Catalog.Payment
{
    public class PaymentDetail : AuditableEntity
    {
        public int PaymentDetailId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public string? Provider { get; set; }
        public Payment_Status Status { get; set; } // pending , paid , unpaid

        // Relationships
        public OrderDetail Order { get; set; } = new OrderDetail();

    }
}
