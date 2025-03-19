using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.Interfaces.IRepository;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Product>> CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.Inventories.AddAsync(product.Inventory);
            return Result<Product>.Success(product);
        }

        public Task<Result<Product>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<Product>>> GetAllAsync()
        {
            //return await (from products in _dbContext.Products.AsNoTracking()
            //              join inventory in _dbContext.Inventories.AsNoTracking()
            //              on products.InventoryId equals inventory.InventoryId
            //              join discount in _dbContext.Discounts.AsNoTracking()
            //              on products.DiscountId equals discount.DiscountId

            //              select new Product
            //              {
            //                  ImageUrl = products.ImageUrl,
            //                  ProductId = products.ProductId,
            //              })
            //              .ToListAsync();

            var products = await _dbContext.Products.Include(inv => inv.Inventory).Include(dis => dis.Discount).ToListAsync();
            return Result<List<Product>>.Success(products);
        }

        public Task<Result<Product>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Product>> UpdateAsync(Product product, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}