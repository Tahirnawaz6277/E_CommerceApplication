using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Inventory
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }

}
