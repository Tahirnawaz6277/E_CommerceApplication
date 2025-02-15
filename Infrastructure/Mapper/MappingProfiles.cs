using AutoMapper;
using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.DTOS.Category;
using E_Commerce.Application.DTOS.Product;

namespace E_Commerce.Infrastructure.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            #region -Category Mapping-
            _ = CreateMap<Category,CategoryDTO>();
            _= CreateMap<CreateCategoryRequest,Category>();
            _ = CreateMap<UpdateCategoryRequest,Category>();
            #endregion


            #region -Product Mapping-

            _ = CreateMap<Product, ProductDTO>();
            _= CreateMap<CreateProductRequest,Product>();
            _=CreateMap<UpdateProductRequest,Product>();

            #endregion



        }
    }
}
