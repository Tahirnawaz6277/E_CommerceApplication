using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;

namespace E_Commerce.Application.Interfaces.IRepository
{
    public interface IProductRepository 
    {
        Task<Result<List<Product>>> GetAllAsync();
        Task<Result<Product>> GetAsync(Guid id);
        Task<Result<Product>> CreateAsync(Product product);
        Task<Result<Product>> UpdateAsync(Product product,Guid id);
        Task<Result<Product>> DeleteAsync(Guid id);
    }
}
