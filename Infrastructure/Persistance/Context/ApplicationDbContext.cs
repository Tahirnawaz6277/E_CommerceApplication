using Domain.Entities.Catalog;
using Domain.Entities.Catalog.Inventory;
using Domain.Entities.Catalog.Order;
using Domain.Entities.Catalog.Payment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistance.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>,IDbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IConfiguration configuration):base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<User_address> UserAddresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<OrderDetail> Order_Details { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetail> Payment_Details { get; set; }
        public DbSet<UserPayment> User_Payments { get; set; }

       

        //public Task<int> SaveChangesAsnyc(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public DbSet<TEntity> Set<TEntity>() where TEntity : class
        //{
        //    throw new NotImplementedException();
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var adminRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "Admin" };
            var customerRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Customer", NormalizedName = "Customer" };
            builder.Entity<IdentityRole>().HasData(adminRole, customerRole);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = _configuration.GetConnectionString("ECommerceConnection");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conString, options => options.UseNetTopologySuite());
            }
        }
    }
  
}
