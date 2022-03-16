using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLogoPhilia.Interfaces.IServices;
using TheLogoPhilia.Models;

namespace TheLogoPhilia.Controllers
{
   [ApiController] 
   [Route("api/[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public ApplicationUserController(IApplicationUserService applicationUserService,IWebHostEnvironment webhostEnvironment)
        {
            _applicationUserService = applicationUserService;
            _webhostEnvironment = webhostEnvironment;
        }
        [HttpPost("CreateApplicationUser")]
         public async Task<IActionResult> CreateRole([FromBody] ApplicationUserCreateRequestModel model)
            {
             var response = await  _applicationUserService.CreateApplicationUser(model);
             if (!response.Success)
             {
                 return BadRequest(response);
             }
             return Ok(response);
            }
        [HttpPut("UpdateApplicationUser/{Id}")]
         public async Task<IActionResult> UpdateApplicationUser([FromBody] ApplicationUserUpdateRequestModel model, [FromRoute]  int Id)
         {
               var response = await  _applicationUserService.UpdateApplicationUser(model,Id);
             if (!response.Success)
             {
                 return BadRequest(response);
             }
             return Ok(response);
         }
        [HttpGet("GetApplicationUser/{Id}")]
         public async Task<IActionResult> GetApplicationUser([FromRoute]  int Id)
         {
               var response = await  _applicationUserService.Get(Id);
              if (!response.Success)
               {
                 return BadRequest(response);
                }
             return Ok(response);
         }
        [HttpGet("GetAllApplicationUsers")]
         public async Task<IActionResult> GetAllApplicationUsers()
         {
               var response = await  _applicationUserService.Get();
              if (!response.Success)
               {
                 return BadRequest(response);
                }
             return Ok(response);
         }
        [HttpDelete("DeleteApplicationUser/{Id}")]
         public async Task<IActionResult> DeleteApplicationUsers( int Id)
         {
               var response = await  _applicationUserService.Delete(Id);
              if (!response)
               {
                 return BadRequest(response);
                }
             return Ok(response);
         }
         

    }
}