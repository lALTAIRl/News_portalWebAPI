using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using News_portal.DAL.Data;
using News_portal.DAL.Entities;
using News_portal.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News_portal.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Set<ApplicationUser>().AsNoTracking().ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            return await _context.Set<ApplicationUser>().FindAsync(id);
        }

        public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.UserName == username);
        }

        public async Task CreateUserAsync(ApplicationUser user)
        {
            await _context.AddAsync(user);
            await Save();
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            await Task.Run(() =>
            {
                _context.Entry(user).State = EntityState.Modified;
            });
            await Save();
        }

        public async Task DeleteUserAsync(ApplicationUser user)
        {
            _context.Remove(user);
            await Save();
        }

        public async Task Save() => await _context.SaveChangesAsync();

    }
}
