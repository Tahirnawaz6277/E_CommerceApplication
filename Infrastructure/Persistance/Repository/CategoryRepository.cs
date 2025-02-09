using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Domain.Interfaces;
using Infrastructure.Persistance.Context;

namespace E_Commerce.Infrastructure.Persistance.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Category>> CreateAsync(Category categoryData)
        {
            await _dbContext.Categories.AddAsync(categoryData);
            await _dbContext.SaveChangesAsync();
            return Result<Category>.Success(categoryData);
        }
    }
}
