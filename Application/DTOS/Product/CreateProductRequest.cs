using E_Commerce.Application.Common.Marker;
using E_Commerce.Application.DTOS.Inventory;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOS.Product
{
    public class CreateProductRequest : IDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        //[Url(ErrorMessage = "Invalid URL format.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Inventory is required.")]
        public CreateInventoryRequest Inventory { get; set; }
    }
}