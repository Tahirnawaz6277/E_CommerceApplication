using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS.Product;

namespace E_Commerce.Application.Interfaces.IService
{
    public interface IProductService
    {
        Task<Result<Guid>> CreateAsync(CreateProductRequest createProduct);
        Task<Result<Guid>> UpdateAsync(UpdateProductRequest updateProduct, Guid id);
        Task<Result<Guid>> DeleteAsync(Guid Id);
        Task<Result<ProductDTO>> GetByIdAsync(Guid id);
        Task<Result<List<ProductDTO>>> GetAllAsync();

    }
}
