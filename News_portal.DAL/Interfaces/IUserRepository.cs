using News_portal.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News_portal.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();

        Task<ApplicationUser> GetUserByIdAsync(int id);

        Task<ApplicationUser> GetUserByUsernameAsync(string username);

        Task CreateUserAsync(ApplicationUser user);

        Task UpdateUserAsync(ApplicationUser user);

        Task DeleteUserAsync(ApplicationUser user);
    }
}
