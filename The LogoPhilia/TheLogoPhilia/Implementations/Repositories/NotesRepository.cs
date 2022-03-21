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
    public class NotesRepository : BaseRepository<Notes>, INotesRepository
    {
        public NotesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notes>> GetNotesOfUser(int UserId)
        {
            return await _context.Notes.Include(N=> N.ApplicationUser).Where(N=>N.ApplicationUserId==UserId).ToListAsync();
        }
    }
}