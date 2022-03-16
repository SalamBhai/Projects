using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLogoPhilia.Entities;
using TheLogoPhilia.Interfaces.IRepositories;
using TheLogoPhilia.Interfaces.IServices;
using TheLogoPhilia.Models;

namespace TheLogoPhilia.Implementations.Services
{
    public class ApplicationUserCommentService : IApplicationUserCommentService
    {
        private readonly IApplicationUserCommentRepository _applicationUserCommentRepository;
        private readonly IUserRepository _UserRepository;

        public ApplicationUserCommentService(IApplicationUserCommentRepository applicationUserCommentRepository, IUserRepository UserRepository)
        {
            _applicationUserCommentRepository = applicationUserCommentRepository;
            _UserRepository = UserRepository;
        }

        public async Task<BaseResponse<ApplicationUserCommentViewModel>> CreateComment(CreateApplicationUserCommentModel model, int UserId)
        {
            var userInPost = await _UserRepository.GetUser(UserId);
             var appUser = userInPost.ApplicationUser;
           var comment = new  ApplicationUserComment
           {
               ApplicationUser = appUser,
               ApplicationUserId = appUser.Id,
               CommentContent = model.CommentContent,
               CommentDate = DateTime.UtcNow,
               DateCreated = DateTime.UtcNow,
               
               PostId = model.PostId,
           };
           await _applicationUserCommentRepository.Create(comment);
           return new BaseResponse<ApplicationUserCommentViewModel>
           {
              Message = " Successful Initialization",
              Success = true,
              Data = new ApplicationUserCommentViewModel
              {  
                  PostId = comment.PostId,
                  ApplicationUserId = comment.ApplicationUserId,
                  ApplicationUserName = comment.ApplicationUser.User.UserName,
                  CommentContent = comment.CommentContent,
                  CommentDate = comment.CommentDate,
                  PostCreator = comment.Post.ApplicationUser.User.UserName,
                  PostDate = comment.Post.DateCreated,
                  Id = comment.Id,
              }
           };
        }

        public async Task<bool> Delete(int Id)
        {
           var comment = await _applicationUserCommentRepository.GetApplicationUserComment(Id);
           if(comment == null) return false;
           comment.IsDeleted = true;
           _applicationUserCommentRepository.SaveChanges();
           return true;
        }

        public  async Task<BaseResponse<ApplicationUserCommentViewModel>> Get(int Id)
        {
           var comment = await _applicationUserCommentRepository.GetApplicationUserComment(Id);
           if(comment == null) return new BaseResponse<ApplicationUserCommentViewModel>
           {
                  Message = "Could Not Fetch",
                  Success = true,
           };
           return new BaseResponse<ApplicationUserCommentViewModel>
           {
              Message = "Successfully gotten",
              Success = true,
              Data = new ApplicationUserCommentViewModel
              {
                  ApplicationUserId = comment.ApplicationUserId,
                  ApplicationUserName = comment.ApplicationUser.User.UserName,
                  CommentContent = comment.CommentContent,
                  CommentDate = comment.CommentDate,
                  PostCreator = comment.Post.ApplicationUser.User.UserName,
                  PostDate = comment.Post.DatePosted,
                  PostId = comment.PostId,
                  Id = comment.Id,
              }

           };
        }

        public  async Task<BaseResponse<IEnumerable<ApplicationUserCommentViewModel>>> Get()
        {
           var  applicationUserComments = await _applicationUserCommentRepository.GetApplicationUserComments();
           var applicationUserCommentsReturned = applicationUserComments.Select(comment => new ApplicationUserCommentViewModel
           {
                   ApplicationUserId = comment.ApplicationUserId,
                  ApplicationUserName = comment.ApplicationUser.User.UserName,
                  CommentContent = comment.CommentContent,
                  CommentDate = comment.CommentDate,
                  PostCreator = comment.Post.ApplicationUser.User.UserName,
                  PostDate = comment.Post.DatePosted,
                  PostId = comment.PostId,  
                  Id = comment.Id,
           }).ToList();
           return new BaseResponse<IEnumerable<ApplicationUserCommentViewModel>>
           { 
               Message = "Successful Retrieval",
               Success = true,
               Data = applicationUserCommentsReturned,
           };
        }

        public async  Task<BaseResponse<IEnumerable<ApplicationUserCommentViewModel>>> GetCommentsOfAPost(int PostId)
        {
           var postComments = await _applicationUserCommentRepository.GetCommentsOfAPost(PostId);
           if(postComments.Count()==0) return new BaseResponse<IEnumerable<ApplicationUserCommentViewModel>>
           {
               Message = "Post Has No Comments yet",
               Success = false,
           };
           var postCommentsReturned = postComments.Select(comment=> new ApplicationUserCommentViewModel
           {
                 ApplicationUserId = comment.ApplicationUserId,
                  ApplicationUserName = comment.ApplicationUser.User.UserName,
                  CommentContent = comment.CommentContent,
                  CommentDate = comment.CommentDate,
                  PostCreator = comment.Post.ApplicationUser.User.UserName,
                  PostDate = comment.Post.DatePosted,
                  PostId = comment.PostId, 
                  Id = comment.Id,
           }).ToList();
            return new BaseResponse<IEnumerable<ApplicationUserCommentViewModel>>
           { 
               Message = "Successful Retrieval",
               Success = true,
               Data = postCommentsReturned,
           };
        }

        public async Task<BaseResponse<ApplicationUserCommentViewModel>> UpdateComment(UpdateApplicationUserCommentModel model, int Id)
        {
             var comment = await _applicationUserCommentRepository.GetApplicationUserComment(Id);
             if(comment == null) return new BaseResponse<ApplicationUserCommentViewModel>
             {
                 Message = " Comment Not Found",
                 Success = false,
             };
             comment.CommentContent = comment.CommentContent ?? model.CommentContent;
             await _applicationUserCommentRepository.Update(comment);
             return new BaseResponse<ApplicationUserCommentViewModel>
             {
                  Message = "Success In Updating",
                  Success = true,
                  Data = new ApplicationUserCommentViewModel
                  {
                       ApplicationUserId = comment.ApplicationUserId,
                      ApplicationUserName = comment.ApplicationUser.User.UserName,
                      CommentContent = comment.CommentContent,
                      CommentDate = comment.CommentDate,
                      PostCreator = comment.Post.ApplicationUser.User.UserName,
                     PostDate = comment.Post.DatePosted,
                     PostId = comment.PostId, 
                     Id = comment.Id,
                  }
             };
        }
    }
}