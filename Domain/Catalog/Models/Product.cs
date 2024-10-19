using System.ComponentModel.DataAnnotations;

namespace Domain.Catalog.Models
{
    public class Product
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid CatagoryId { get; set; }
        public Category catagory { get; set; }
        // Relationships
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}
