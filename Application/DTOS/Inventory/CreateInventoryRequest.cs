using E_Commerce.Application.Common.Marker;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOS.Inventory
{
    public class CreateInventoryRequest : IDto
    {
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0.01, 1000, ErrorMessage = "Quantity must be greater than zero.")]
        public int StockQuantity { get; set; }
    }
}
