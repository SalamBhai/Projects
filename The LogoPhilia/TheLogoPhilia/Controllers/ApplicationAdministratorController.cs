using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLogoPhilia.Interfaces.IServices;
using TheLogoPhilia.Models;

namespace TheLogoPhilia.Controllers
{
    [ApiController]
      [Route("api/[controller]")]
  
    public class ApplicationAdministratorController: ControllerBase
    {
         private readonly IApplicationAdministratorService _applicationAdministratorService;
         

        public ApplicationAdministratorController(IApplicationAdministratorService applicationAdministratorService)
        {
            _applicationAdministratorService = applicationAdministratorService;
         
        }
        [HttpPost("CreateApplicationAdministrator")]
          // [Authorize(Roles ="ApplicationAdministrator")]

        public async Task<IActionResult> Create(CreateApplicationAdministratorRequestModel model)
        {
  
              var appAdministrator = await _applicationAdministratorService.CreateApplicationAdministrator(model);
              if(!appAdministrator.Success) return BadRequest(appAdministrator);
              return Ok(appAdministrator);

        }
        [HttpPost("CreateSubAdministrator")]
        // [Authorize(Roles ="ApplicationAdministrator")]
        // [Authorize(Roles ="ApplicationSubAdministrator")]
        public async Task<IActionResult> CreateSubAdministrator(CreateSubAdministratorRequestModel model)
        {
          
              var appAdministrator = await _applicationAdministratorService.CreateSubAdministrator(model);
              if(!appAdministrator.Success) return BadRequest(appAdministrator);
              return Ok(appAdministrator);

        }
         [HttpGet("GetApplicationAdministrator/{Id}")]
         public async Task<IActionResult> GetApplicationUser([FromRoute] int Id)
         {
               var response = await  _applicationAdministratorService.Get(Id);
              if (!response.Success)
               {
                 return BadRequest(response);
                }
             return Ok(response);
         }
        [HttpGet("GetAllApplicationAdministrators")]
         public async Task<IActionResult> GetAllApplicationAdministrators()
         {
               var response = await  _applicationAdministratorService.Get();
              if (!response.Success)
               {
                 return BadRequest(response);
                }
             return Ok(response);
         }
        [HttpDelete("DeleteApplicationAdministrator/{Id}")]
         [Authorize(Roles ="ApplicationAdministrator")]
         public async Task<IActionResult> DeleteApplicationAdmin(int Id)
         {
               var response = await  _applicationAdministratorService.Delete(Id);
              if (!response)
               {
                 return BadRequest(response);
                }
             return Ok(response);
         }
    }
}