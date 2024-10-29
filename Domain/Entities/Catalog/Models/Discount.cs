﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Catalog.Models
{
    public class Discount
    {
        [Key]
        public Guid Id { get; set; }
        public string Discription { get; set; }
        public decimal Discount_percent { get; set; }
        public bool Active { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }

        //relations
        public ICollection<Product> products { get; set; }


    }
}