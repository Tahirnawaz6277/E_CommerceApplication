using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS.AuthDto;

namespace E_Commerce.Application.Interfaces.IAuthService
{
    public interface IUserService
    {
        Task<Result<RegisterResponse>> Register(RegistorRequest user);
        Task<Result<LoginResponse>> Login(LoginRequest user);
    }
}