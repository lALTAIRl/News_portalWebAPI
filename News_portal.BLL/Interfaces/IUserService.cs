using News_portal.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News_portal.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(string username, string password);

        Task<IEnumerable<ApplicationUser>> GetAll();

        Task<ApplicationUser> GetById(int id);

        Task<ApplicationUser> Create(ApplicationUser user, string password);

        Task Update(ApplicationUser user, string password = null);

        Task Delete(int id);
    }
}
