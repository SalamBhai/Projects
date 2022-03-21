using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheLogoPhilia.Entities;
using TheLogoPhilia.Models;

namespace TheLogoPhilia.Interfaces.IServices
{
    public interface IApplicationUserPostService
    {
       Task<BaseResponse<ApplicationUserPostViewModel>> Create(CreateApplicationUserPostViewModel model, int UserId);
        Task<BaseResponse<ApplicationUserPostViewModel>> Update(UpdateApplicationUserPostViewModel model, int Id);
        Task<BaseResponse<ApplicationUserPostViewModel>> Get(int Id);
        Task<BaseResponse<IEnumerable<ApplicationUserPostViewModel>>> Get();
        Task<bool> Delete(int Id);
    }
}