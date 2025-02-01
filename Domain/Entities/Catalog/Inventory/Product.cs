using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Inventory
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int DiscountId { get; set; }
        public int InventoryId { get; set; }

        // Navigation properties - Foreign key relationships will be configured in Fluent API
        public Category Category { get; set; }
        public Inventory Inventory { get; set; }
        public Discount Discount { get; set; }
    }
}
