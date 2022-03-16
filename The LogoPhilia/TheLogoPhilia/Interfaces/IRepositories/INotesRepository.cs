using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLogoPhilia.Entities;

namespace TheLogoPhilia.Interfaces.IRepositories
{
    public interface INotesRepository : IRepository<Notes>
    {
         Task<IEnumerable<Notes>> GetNotesOfUser(int UserId);
    }
}