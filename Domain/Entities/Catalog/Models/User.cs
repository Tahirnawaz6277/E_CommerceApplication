﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Models
{
    public class User : Identity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? Username { get; set; }

        public string Email { get; set; }
        public string? PasswordHash { get; set; }
        public string Role { get; set; } // Can be either "Admin" or "Customer"
        public int Telephone { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime?  Updated_at { get; set; }
    }
}
