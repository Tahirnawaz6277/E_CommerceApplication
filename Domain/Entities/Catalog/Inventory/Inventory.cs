using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Inventory
{
    public class Inventory: AuditableEntity
    {
        public Guid InventoryId { get; set; }
        public int StockQuantity { get; set; }

    }
}
