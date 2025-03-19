using E_Commerce.Domain.Interfaces;

namespace E_Commerce.Application.Interfaces.IRepository.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
