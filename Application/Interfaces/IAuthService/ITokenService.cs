using Domain.Entities.Catalog;

namespace E_Commerce.Application.Interfaces.IAuthService
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}
