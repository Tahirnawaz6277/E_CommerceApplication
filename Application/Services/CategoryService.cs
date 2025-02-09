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
                //CategoryId = categoryData.Id,
                Name = categoryData.Name,
                Description = categoryData.Description

            };

            var categoryRepo = await _categoryRepository.CreateAsync(category);
            var respones = new CategoryResponse
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };
            return Result<CategoryResponse>.Success(respones);
        }
    }
}
