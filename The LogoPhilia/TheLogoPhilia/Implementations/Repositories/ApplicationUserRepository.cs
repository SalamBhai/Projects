using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheLogoPhilia.ApplicationDbContext;
using TheLogoPhilia.Entities;
using TheLogoPhilia.Interfaces.IRepositories;

namespace TheLogoPhilia.Implementations.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
           return await _context.ApplicationUsers.Include(L=> L.ApplicationUserAdminMessages).ThenInclude(L=> L.AdministratorMessage).ThenInclude(L=>L.ApplicationUserAdminMessages).ThenInclude(L=>L.ApplicationUser).Include(L=> L.ApplicationUserComments).Include(L=>  L.ApplicationUserNotes).Include(L=> L.ApplicationUserPosts).ToListAsync();
        }

        public async Task<ApplicationUser> GetUser(int id)
        {
            return await _context.ApplicationUsers.Include(L=> L.ApplicationUserAdminMessages).ThenInclude(L=> L.AdministratorMessage).ThenInclude(L=>L.ApplicationUserAdminMessages).ThenInclude(L=>L.ApplicationUser).Include(L=> L.ApplicationUserComments).Include(L=>  L.ApplicationUserNotes).Include(L=> L.ApplicationUserPosts).SingleOrDefaultAsync(L=> L.Id == id);
   
        }
         public async Task<IEnumerable<ApplicationUser>> GetSelectedApplicationUsers(List<int> UserIds)
         {
             return await _context.ApplicationUsers.Include(L=> L.ApplicationUserAdminMessages).ThenInclude(L=> L.AdministratorMessage).ThenInclude(L=>L.ApplicationUserAdminMessages).ThenInclude(L=>L.ApplicationUser).Include(L=> L.ApplicationUserComments).Include(L=>  L.ApplicationUserNotes).Include(L=> L.ApplicationUserPosts).Where(L=> UserIds.Contains(L.Id)).ToListAsync();
         }

        public async Task<IEnumerable<string>> GetUserEmails()
        {
            var userEmails = await _context.ApplicationUsers.Select(L=> L.UserEmail).ToListAsync();
            return userEmails;
        }

        public async Task<IEnumerable<ApplicationUser>> GetBirthDayUsers()
        {
            var users = await _context.ApplicationUsers.Where(L=> L.DateOfBirth.ToShortDateString()== DateTime.UtcNow.ToShortDateString()).ToListAsync();
            return users;
        }
    }
}