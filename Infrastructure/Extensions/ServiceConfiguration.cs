using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Interfaces.IRepository;
using E_Commerce.Application.Interfaces.IRepository.IUnitOfWork;
using E_Commerce.Application.Interfaces.IService;
using E_Commerce.Application.Interfaces.IService.IAuthService;
using E_Commerce.Application.Services.AuthService;
using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Interfaces.AuthRepository;
using E_Commerce.Infrastructure.Mapper;
using E_Commerce.Infrastructure.Persistance.Repository;
using E_Commerce.Infrastructure.Persistance.Repository.AuthRepositroy;
using E_Commerce.Infrastructure.Persistance.UnitOfWork;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Infrastructure.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureEcommerceServices(this IServiceCollection Services)
        {
            Services.UseDIConfig();
            return Services;
        }
        public static void UseDIConfig(this IServiceCollection Services)
        {
            UseServices(Services);
        }

        private static void UseServices(IServiceCollection Services)
        {
            Services.AddScoped<IDbContext, ApplicationDbContext>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IUserRepo, UserRepo>();
            Services.AddScoped<IProductService, ProductService>();
            Services.AddTransient<ITokenService, TokenService>();
            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<IProductRepository, ProductRepository>();
            Services.AddAutoMapper(typeof(MappingProfiles));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
