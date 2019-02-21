using News_portal.BLL.Interfaces;
using News_portal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace News_portal.BLL.Services
{
    public class UserService : IUserService
    {


        public Task<ApplicationUser> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> Create(ApplicationUser user, string password)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ApplicationUser user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
