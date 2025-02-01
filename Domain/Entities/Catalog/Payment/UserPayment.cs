using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Payment
{
    public class UserPayment : AuditableEntity
    {
        public int UserPaymentId { get; set; }
        public string UserId { get; set; }
        public string Payment_type { get; set; }
        public string? Provider { get; set; }
        public int Account_No { get; set; }
        public DateTime? Expiry { get; set; }


    }
}
