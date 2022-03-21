using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLogoPhilia.Entities;

namespace TheLogoPhilia.Interfaces.IRepositories
{
    public interface IApplicationUserPostRepository :  IRepository<ApplicationUserPost>
    {
             Task<ApplicationUserPost> GetApplicationUserPost(int id);
        Task<IEnumerable<ApplicationUserPost>> GetAllPosts();  
    }
}