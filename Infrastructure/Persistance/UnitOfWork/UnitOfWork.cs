using E_Commerce.Application.Interfaces.IRepository;
using E_Commerce.Application.Interfaces.IRepository.IUnitOfWork;
using E_Commerce.Domain.Interfaces;
using Infrastructure.Persistance.Context;

namespace E_Commerce.Infrastructure.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }


        public UnitOfWork(ApplicationDbContext dbContext, IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _dbContext = dbContext;
            ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
