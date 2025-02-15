using AutoMapper;
using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS.Product;
using E_Commerce.Application.Interfaces.IRepository.IUnitOfWork;
using E_Commerce.Application.Interfaces.IService;

namespace Infrastructure.Persistance.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<Guid>> CreateAsync(CreateProductRequest createProduct)
        {
            try
            {
                // DTO to Domian  
                var product = _mapper.Map<Product>(createProduct);
                var CreatedProduct = await _unitOfWork.ProductRepository.CreateAsync(product);
                await _unitOfWork.SaveChangesAsync();
                if (!CreatedProduct.IsSuccess)
                {
                    return Result<Guid>.Fail(CreatedProduct.Message);
                }
                return Result<Guid>.Success(CreatedProduct.Value.ProductId);
            }
            catch(Exception ex)
            {
                return Result<Guid>.Fail($"Error creating product: {ex.InnerException.Message}");
            }
        }

        public Task<Result<Guid>> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<ProductDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProductDTO>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Guid>> UpdateAsync(UpdateProductRequest updateProduct, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
