using Domain.Entities.Catalog;

namespace E_Commerce.Domain.Interfaces.AuthRepository
{
    public interface IUserRepo
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task UpdateAsync(ApplicationUser user,string id);
        Task DeleteAsync(string id);
    }
}
