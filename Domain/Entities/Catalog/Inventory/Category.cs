using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Inventory
{
    [Table("Categories", Schema = "inventory")]
    public class Category : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public DateTime? Deleted_at { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
