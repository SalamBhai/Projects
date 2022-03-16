using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheLogoPhilia.ApplicationDbContext;
using TheLogoPhilia.Entities;
using TheLogoPhilia.Interfaces.IRepositories;

namespace TheLogoPhilia.Implementations.Repositories
{
    public class ApplicationAdministratorRepository : BaseRepository<ApplicationAdministrator>, IApplicationAdministratorRepository
    {
          
        
        public ApplicationAdministratorRepository(AppDbContext context) : base(context)
        {
            _context= context;
        }

        public async Task<ApplicationAdministrator> GetApplicationAdministrator(int Id)
        {
          return await _context.ApplicationAdministrators.Include(L => L.User).FirstOrDefaultAsync(L=> L.Id ==Id);
        }
        public async Task<IEnumerable<ApplicationAdministrator>> GetAllApplicationAdministrators()
        {
          return await _context.ApplicationAdministrators.Include(L => L.User).ToListAsync();
        }
    }
}