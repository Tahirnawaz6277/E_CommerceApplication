using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Catalog.Models
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }
        public int StockQuantity { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }

        // Relations

    }
}
