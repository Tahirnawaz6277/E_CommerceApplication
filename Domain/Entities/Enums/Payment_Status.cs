using System.ComponentModel;

namespace Domain.Entities.Enums
{
    public enum Payment_Status
    {
        [Description("Paid")]
        Paid = 1,
        [Description("Pending")]
        Pending = 2
    }
}
