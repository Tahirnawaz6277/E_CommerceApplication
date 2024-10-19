using System.ComponentModel.DataAnnotations;

namespace Domain.Catalog.Models
{
    public class Category
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }

}
