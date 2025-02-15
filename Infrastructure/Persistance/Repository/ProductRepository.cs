using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.Interfaces.IRepository;
using Infrastructure.Persistance.Context;

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
            return Result<Product>.Success(product);
        }

        public Task<Result<Product>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Product>>> GetAllAsync()
        {
            throw new NotImplementedException();
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