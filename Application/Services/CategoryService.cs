using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Interfaces;

namespace E_Commerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CategoryResponse>> CreateAsync(CategoryRequest categoryData)
        {
            var category = new Category
            {
                Name = categoryData.Name,
                Description = categoryData.Description
            };

            var result = await _categoryRepository.CreateAsync(category);
            if (!result.IsSuccess)
            {
                return Result<CategoryResponse>.Fail(result.Message);
            }

            var response = new CategoryResponse
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };

            return Result<CategoryResponse>.Success(response);
        }

        public async Task<Result<List<CategoryResponse>>> GetAllAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                if (!categories.IsSuccess)
                {
                    return Result<List<CategoryResponse>>.Fail(categories.Message);
                }
                var response = categories.Value.Select(category => new CategoryResponse
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                }).ToList();

                return Result<List<CategoryResponse>>.Success(response, "Categories retrived successfully");
            }
            catch (Exception ex)
            {
                return Result<List<CategoryResponse>>.Fail($"Error retrieving categories : {ex.Message}");
            }
        }

        public async Task<Result<CategoryResponse>> GetByIdAsync(Guid id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                return Result<CategoryResponse>.Fail(result.Message);
            }

            if (result.Value == null)
            {
                return Result<CategoryResponse>.Fail("Category not found");
            }

            var response = new CategoryResponse
            {
                CategoryId = result.Value.CategoryId,
                Name = result.Value.Name,
                Description = result.Value.Description
            };

            return Result<CategoryResponse>.Success(response);
        }
    }
}