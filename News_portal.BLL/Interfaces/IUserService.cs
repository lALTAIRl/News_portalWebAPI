using News_portal.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News_portal.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();

        Task<ApplicationUser> GetUserByIdAsync(string id);

        Task<ApplicationUser> GetUserByNameAsync(string username);

        Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password);

        Task UpdateUserAsync(ApplicationUser user, string password = null);

        Task DeleteUserAsync(string id);
    }
}
