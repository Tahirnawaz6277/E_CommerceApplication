using Domain.Entities.Catalog;
using E_Commerce.Domain.Interfaces.AuthRepository;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Persistance.Repository.AuthRepositroy
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            try
            {
                return await _dbContext.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateAsync(ApplicationUser user, string id)
        {
            throw new NotImplementedException();
        }
    }
}
