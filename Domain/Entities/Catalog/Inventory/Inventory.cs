using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Inventory
{
    [Table("Inventories", Schema = "inventory")]
    public class Inventory: AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public int StockQuantity { get; set; }
        public DateTime? Deleted_at { get; set; }

        // Relations

    }
}
