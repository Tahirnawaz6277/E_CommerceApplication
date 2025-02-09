using Domain.Entities.Catalog;
using E_Commerce.Application.Common.ResultPattern;
using E_Commerce.Application.DTOS.AuthDto;
using E_Commerce.Application.Interfaces.IService.IAuthService;
using E_Commerce.Domain.Interfaces.AuthRepository;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Services.AuthService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(
            IUserRepo userRepo,
            ITokenService tokenService,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result<LoginResponse>> Login(LoginRequest user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser is null)
            {
                Result<LoginResponse>.Fail("Incorrect userName");
            }
            var checkPassword = await _userManager.CheckPasswordAsync(existingUser, user.Password);

            if (checkPassword)
            {
                var existingRole = await _userManager.GetRolesAsync(existingUser);
                if (existingRole != null && existingRole.Any())
                {
                    var token = _tokenService.GenerateJwtToken(existingUser);

                    var response = new LoginResponse
                    {
                        Name = existingUser.FullName,
                        Email = existingUser.Email,
                        Role = existingUser.Role,
                        AccessToken = token
                    };

                    return Result<LoginResponse>.Success(response, "User login successfully");
                }
            }
            return Result<LoginResponse>.Fail("Incorrect userName or password");
        }

        public async Task<Result<RegisterResponse>> Register(RegistorRequest userData)
        {
            userData.Role = userData.Role.ToLower(); // Normalize the role
            if (userData.Role != "admin" && userData.Role != "customer")
            {
                return Result<RegisterResponse>.Fail("Invalid role specified");
            }

            if (!await _roleManager.RoleExistsAsync(userData.Role.ToLower()))
            {
                return Result<RegisterResponse>.Fail($"Role '{userData.Role.ToLower()}' does not exist.");
            }
          
            var existingUser = await _userRepo.GetByEmailAsync(userData.Email);
            if (existingUser != null)
            {
                return Result<RegisterResponse>.Fail("User with this email already exists!");
            }

            ApplicationUser user = new ApplicationUser
            {
                FullName = userData.FullName,
                UserName = userData.Email,
                Email = userData.Email,
                PhoneNumber = userData.MobileNumber,
                Role = userData.Role.ToLower()
            };

            var createUser = await _userManager.CreateAsync(user, userData.Password);
            if (!createUser.Succeeded)
            {
                return Result<RegisterResponse>.Fail($"User creation failed: {string.Join(", ", createUser.Errors)}");
            }

            // Assign role
            var roleUser = await _userManager.AddToRoleAsync(user, userData.Role.ToLower());
            if (!roleUser.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return Result<RegisterResponse>.Fail($"Failed to assign role '{userData.Role.ToLower()}' to user.");
            }

            var userResponse = new RegisterResponse
            {
                userId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };

            return Result<RegisterResponse>.Success(userResponse, "User registerd Successfully");
        }
    }
}