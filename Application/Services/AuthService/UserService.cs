using Domain.Entities.Catalog;
using E_Commerce.Application.Interfaces.IAuthService;
using E_Commerce.Domain.Entities.Dtos;
using E_Commerce.Domain.Interfaces.AuthRepository;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Application.Services.AuthService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUserRepo userRepo, UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityUser> Register(RegisterRequestDto userData)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(userData.Role))
                {
                    throw new ArgumentException($"Role '{userData.Role}' does not exist.");
                }
                var existingUser = await _userRepo.GetByEmailAsync(userData.Email);
                if (existingUser != null)
                {
                    throw new ApplicationException("User with this email is already exist!");
                }
                var user = new ApplicationUser
                {
                    FullName = userData.FullName,
                    UserName = userData.Email,
                    Email = userData.Email,
                    PhoneNumber = userData.MobileNumber
                };
                var CreateUser = await _userManager.CreateAsync(user, userData.Password);

                if (!CreateUser.Succeeded)
                {
                    throw new ApplicationException($"User creation failed: {string.Join(", ", CreateUser.Errors)}");
                }

                // assign role
                var RoleUser = await _userManager.AddToRoleAsync(user, userData.Role);
                if (!RoleUser.Succeeded)
                {
                    await _userManager.DeleteAsync(user);
                    throw new ApplicationException($"Failed to assign role '{userData.Role}' to user.");

                }
                return user;
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
