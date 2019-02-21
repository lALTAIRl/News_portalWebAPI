using News_portal.BLL.Interfaces;
using News_portal.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace News_portal.BLL.Services
{
    public class AuthentificateService : IAuthentificationService
    {
        public Task<ApplicationUser> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
