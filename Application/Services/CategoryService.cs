using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS.Category;
using E_Commerce.Application.Interfaces;
using E_Commerce.Domain.Interfaces;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Guid>> CreateAsync(CreateCategoryRequest categoryData)
    {
        var category = new Category
        {
            Name = categoryData.Name,
            Description = categoryData.Description
        };

        var result = await _categoryRepository.CreateAsync(category);
        if (!result.IsSuccess)
        {
            return Result<Guid>.Fail(result.Message);
        }

        return Result<Guid>.Success(result.Value.CategoryId);
    }

    public async Task<Result<Guid>> DeleteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Result<Guid>.Fail("Id cannot be empty");
        }

        var result = await _categoryRepository.DeleteAsync(id);
        if (!result.IsSuccess)
        {
            return Result<Guid>.Fail(result.Message);
        }

        return Result<Guid>.Success(id, result.Message);
    }

    public async Task<Result<CategoryDTO>> GetByIdAsync(Guid id)
    {
        var result = await _categoryRepository.GetByIdAsync(id);
        if (!result.IsSuccess)
        {
            return Result<CategoryDTO>.Fail(result.Message);
        }

        if (result.Value == null)
        {
            return Result<CategoryDTO>.Fail("Category not found");
        }

        var response = new CategoryDTO
        {
            CategoryId = result.Value.CategoryId,
            Name = result.Value.Name,
            Description = result.Value.Description
        };

        return Result<CategoryDTO>.Success(response);
    }

    public async Task<Result<List<CategoryDTO>>> GetAllAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (!categories.IsSuccess)
            {
                return Result<List<CategoryDTO>>.Fail(categories.Message);
            }

            var response = categories.Value.Select(category => new CategoryDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            }).ToList();

            return Result<List<CategoryDTO>>.Success(response, "Categories retrieved successfully");
        }
        catch (Exception ex)
        {
            return Result<List<CategoryDTO>>.Fail($"Error retrieving categories: {ex.Message}");
        }
    }

    public async Task<Result<Guid>> UpdateAsync(UpdateCategoryRequest categoryRequest, Guid id)
    {
        var category = new Category
        {
            CategoryId = id,
            Name = categoryRequest.Name,
            Description = categoryRequest.Description
        };

        var result = await _categoryRepository.UpdateAsync(category, id);
        if (!result.IsSuccess)
        {
            return Result<Guid>.Fail(result.Message);
        }

        return Result<Guid>.Success(id);
    }
}