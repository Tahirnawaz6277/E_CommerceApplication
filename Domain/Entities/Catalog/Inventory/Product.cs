using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Inventory
{
    public class Product : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? DiscountId { get; set; }
        public Guid InventoryId { get; set; }

        // Navigation properties - Foreign key relationships will be configured in Fluent API
        public Category Category { get; set; }
        public Inventory Inventory { get; set; }
        public Discount? Discount { get; set; }
    }
}
