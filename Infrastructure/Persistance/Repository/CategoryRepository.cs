using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Domain.Interfaces;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Persistance.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<Result<Category>> CreateAsync(Category categoryData)
        //{
        //    try
        //    {
        //     var data =   await _dbContext.Categories.AddAsync(categoryData);
        //        await _dbContext.SaveChangesAsync();
        //        return Result<Category>.Success(data.Entity);
        //    }
        //    catch(Exception ex)
        //    {
        //        return Result<Category>.Fail(ex.Message);
        //    }
        //}

        public async Task<Result<Category>> CreateAsync(Category categoryData)
        {
            try
            {
                await _dbContext.Categories.AddAsync(categoryData);
                await _dbContext.SaveChangesAsync();
                return Result<Category>.Success(categoryData);
            }
            catch (Exception ex)
            {
                return Result<Category>.Fail($"Failed to create category: {ex.Message}");
            }
        }

        public async Task<Result<List<Category>>> GetAllAsync()
        {
            try
            {
                List<Category> categories = await _dbContext.Categories.ToListAsync();
                return Result<List<Category>>.Success(categories);
            }
            catch (Exception ex)
            {
                return Result<List<Category>>.Fail($"Error retrieving categories:{ex.Message}");
            }
        }

        public async Task<Result<Category>> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

                if (category == null)
                {
                    return Result<Category>.Fail("Category not found");
                }

                return Result<Category>.Success(category);
            }
            catch (Exception ex)
            {
                return Result<Category>.Fail($"Failed to retrieve category: {ex.Message}");
            }
        }
    }
}