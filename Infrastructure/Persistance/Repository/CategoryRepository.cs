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

        public async Task<Result<Category>> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbContext.Categories.FirstOrDefaultAsync(cat => cat.CategoryId == id);
                if (result == null)
                {
                    return Result<Category>.Fail("Category Not Found ");
                }
                _dbContext.Categories.Remove(result);
                await _dbContext.SaveChangesAsync();
                return Result<Category>.Success(result, "category successfully deleted");
            }
            catch (Exception ex)
            {
                return Result<Category>.Fail($"Failed to delete this Category : {ex.Message}");
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

        public async Task<Result<Category>> UpdateAsync(Category category, Guid id)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(cat => cat.CategoryId == id);
                if (existingCategory == null)
                {
                    return Result<Category>.Fail("Category not Found");
                }

                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                existingCategory.LastModifiedOn = DateTime.Now;
               
                var updated = _dbContext.Categories.Update(existingCategory);
                await _dbContext.SaveChangesAsync();
                return Result<Category>.Success(existingCategory);
            }
            catch (Exception ex)
            {
                return Result<Category>.Fail($"Failed to update this Category : {ex.Message}");
            }
        }
    }
}