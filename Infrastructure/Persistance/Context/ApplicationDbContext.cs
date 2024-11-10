﻿using Domain.Entities.Catalog;
using Domain.Entities.Catalog.Inventory;
using Domain.Entities.Catalog.Order;
using Domain.Entities.Catalog.Payment;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }


        public DbSet<User> Users { get; set; }
        public DbSet<User_address> UserAddresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetail> Payment_Details { get; set; }
        public DbSet<UserPayment> User_Payments { get; set; }


    }
}
