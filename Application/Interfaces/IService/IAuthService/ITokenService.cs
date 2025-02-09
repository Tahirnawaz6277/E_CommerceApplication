using Domain.Entities.Catalog;

namespace E_Commerce.Application.Interfaces.IService.IAuthService
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}
