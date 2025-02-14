using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS.Category;

namespace E_Commerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<Guid>> CreateAsync(CreateCategoryRequest category);
        Task<Result<List<CategoryDTO>>> GetAllAsync();
        Task<Result<CategoryDTO>> GetByIdAsync(Guid id);
        Task<Result<Guid>> DeleteAsync(Guid id);
        Task<Result<Guid>> UpdateAsync(UpdateCategoryRequest category,Guid id);


    }
}