using News_portal.DAL.Entities;
using System.Threading.Tasks;

namespace News_portal.BLL.Interfaces
{
    public interface IAuthentificationService
    {
        Task<ApplicationUser> Authenticate(string username, string password);
    }
}
