using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Inventory
{
    public class Discount : AuditableEntity
    {
        public Discount()
        {
            Products = new List<Product>();
        }
        public Guid DiscountId { get; set; }

        public string Name { get; set; }

        public string? Discription { get; set; }
        public decimal Discount_percent { get; set; }
        public bool Active { get; set; }

        //relations
        public ICollection<Product> Products { get; set; } 


    }
}
