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
    public class ApplicationUserPostService : IApplicationUserPostService
    {
        private readonly IApplicationUserPostRepository _appUserPostRepository;
        private readonly IApplicationUserRepository _appUserRepository;
        private readonly IUserRepository _UserRepository;

        public ApplicationUserPostService(IApplicationUserPostRepository appUserPostRepository, IApplicationUserRepository appUserRepository, IUserRepository userRepository)
        {
            _appUserPostRepository = appUserPostRepository;
            _appUserRepository = appUserRepository;
            _UserRepository = userRepository;
        }

        public async Task<BaseResponse<ApplicationUserPostViewModel>> Create(CreateApplicationUserPostViewModel model, int UserId)
        {
            var userInPost = await _UserRepository.GetUser(UserId);
           var post = new ApplicationUserPost 
           {
               PostContent = model.PostContent,
               DatePosted = DateTime.UtcNow,
               ApplicationUserId = userInPost.ApplicationUser.Id,
               ApplicationUser = userInPost.ApplicationUser
                
           };
           await _appUserPostRepository.Create(post);
           return new BaseResponse<ApplicationUserPostViewModel>
           {
               Message = "Post Created Successfully",
               Success = true,
               Data = new ApplicationUserPostViewModel
               {
                   ApplicationUserName = post.ApplicationUser.User.UserName,
                   PostContent = post.PostContent,
                   VideoFile = post.VideoFile,
                   DatePosted = post.DatePosted,
                   ApplicationUserId = post.ApplicationUserId,
                   ApplicationUserEmail = post.ApplicationUser.UserEmail,
                   PostId = post.Id,
               }
           };
        }

        

        public async Task<BaseResponse<ApplicationUserPostViewModel>> Get(int Id)
        {
            var appUserPost = await _appUserPostRepository.GetApplicationUserPost(Id);
            var appUserPostReturned =  new ApplicationUserPostViewModel
            {
                ApplicationUserId = appUserPost.ApplicationUserId,
                PostId = appUserPost.Id,
                ApplicationUserName = appUserPost.ApplicationUser.User.UserName,
                ApplicationUserEmail = appUserPost.ApplicationUser.UserEmail,
                PostContent = appUserPost.PostContent,
                VideoFile = appUserPost.VideoFile,
                DatePosted = appUserPost.DatePosted,

                ApplicationUserComments = appUserPost.ApplicationUserComments.Select( L=> new ApplicationUserCommentViewModel
                 {
                   ApplicationUserId = L.ApplicationUserId,
                   ApplicationUserName = L.ApplicationUser.User.UserName,
                   CommentContent = L.CommentContent,
                   PostId = L.PostId,
                   CommentDate = L.CommentDate,
                   PostCreator = L.Post.ApplicationUser.User.UserName,
                   PostDate =L.Post.DateCreated,
                   Id = L.Id,
                  }
                ).ToList(),

            };
            return new BaseResponse<ApplicationUserPostViewModel>
           {
                Message = "User Retrieval Successful",
                Success = true,
                Data= appUserPostReturned,
           };
        }

        public async Task<BaseResponse<IEnumerable<ApplicationUserPostViewModel>>> Get()
        {
           var userPost = await _appUserPostRepository.GetAllPosts();
           var userPostsReturned = userPost.Select(appUserPost=> new ApplicationUserPostViewModel
           {
               ApplicationUserId = appUserPost.ApplicationUserId,
                PostId = appUserPost.Id,
                ApplicationUserName = appUserPost.ApplicationUser.User.UserName,
                ApplicationUserEmail = appUserPost.ApplicationUser.UserEmail,
                PostContent = appUserPost.PostContent,
                VideoFile = appUserPost.VideoFile,
                DatePosted = appUserPost.DatePosted,
                
                ApplicationUserComments = appUserPost.ApplicationUserComments.Select( L=> new ApplicationUserCommentViewModel
                 {
                   ApplicationUserId = L.ApplicationUserId,
                   ApplicationUserName = L.ApplicationUser.User.UserName,
                   CommentContent = L.CommentContent,
                   PostId = L.PostId,
                   CommentDate = L.CommentDate,
                   PostCreator = L.Post.ApplicationUser.User.UserName,
                   PostDate =L.Post.DateCreated,
                   Id = L.Id,
                  }
                ).ToList(),   
           }).ToList();
           return new BaseResponse<IEnumerable<ApplicationUserPostViewModel>>
           {
                Message = "User Retrieval Successful",
                Success = true,
                Data= userPostsReturned,
           };
        }

        public async Task<BaseResponse<ApplicationUserPostViewModel>> Update(UpdateApplicationUserPostViewModel model, int Id)
        {
          var appUserPost= await _appUserPostRepository.GetApplicationUserPost(Id);
          if(appUserPost == null) return new BaseResponse<ApplicationUserPostViewModel>
          {
           Message = "Post Not Found",
           Success = false,
          };
          appUserPost.PostContent = model.PostContent;
          await _appUserPostRepository.Update(appUserPost);
           return new BaseResponse<ApplicationUserPostViewModel>
           {
               Message = "Update Successful",
               Success =true,
               Data = new ApplicationUserPostViewModel
               {
                    ApplicationUserId = appUserPost.ApplicationUserId,
                    PostId = appUserPost.Id,
                    ApplicationUserName = appUserPost.ApplicationUser.User.UserName,
                    ApplicationUserEmail = appUserPost.ApplicationUser.UserEmail,
                   PostContent = appUserPost.PostContent,
                   VideoFile = appUserPost.VideoFile,
                    DatePosted = appUserPost.DatePosted,
                
                  ApplicationUserComments = appUserPost.ApplicationUserComments.Select( L=> new ApplicationUserCommentViewModel
                 {
                   ApplicationUserId = L.ApplicationUserId,
                   ApplicationUserName = L.ApplicationUser.User.UserName,
                   CommentContent = L.CommentContent,
                   PostId = L.PostId,
                   CommentDate = L.CommentDate,
                   PostCreator = L.Post.ApplicationUser.User.UserName,
                   PostDate =L.Post.DateCreated,
                   Id = L.Id,
                  }
                ).ToList(),   
               }
           };
        }

        public async Task<bool> Delete(int Id)
        {
           var post = await _appUserPostRepository.GetApplicationUserPost(Id);
           if(post==null) return false;
           post.IsDeleted = true;
           _appUserPostRepository.SaveChanges();
           return true;
        }
    }
}