﻿using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Inventory
{
    [Table("Products",Schema ="inventory")]
    public class Product : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CatagoryId { get; set; }
        public Guid DiscountId { get; set; }
        public Guid InventoryId { get; set; }
        public DateTime? Deleted_at { get; set; }

        // Relationships

        [ForeignKey("CatagoryId")]
        public Category category { get; set; }

        [ForeignKey("DiscountId")]
        public Inventory inventory { get; set; }

        [ForeignKey("InventoryId")]
        public Discount discount { get; set; }
        //public OrderItem OrderItem { get; set; } = new OrderItem();

    }

}
