using E_Commerce.Application.Common.Marker;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Application.DTOS
{
    public class CategoryRequest : IDto
    {
        //public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}
