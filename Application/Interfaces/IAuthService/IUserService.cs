using E_Commerce.Domain.Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Interfaces.IAuthService
{
    public interface IUserService
    {
        Task<IdentityUser> Register(RegisterRequestDto user);

    }
}
