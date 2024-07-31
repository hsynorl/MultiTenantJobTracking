using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.UserJob.Command;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJobsController : ControllerBase
    {
        private readonly IUserJobService userJobService;

        public UserJobsController(IUserJobService userJobService)
        {
            this.userJobService = userJobService;
        }

        [HttpPost("create-user-job")]
        public async Task<IActionResult> CreateUserJob(CreateUserJobCommand createUserJobCommand) { 
        var result=await userJobService.CreateUserJob(createUserJobCommand);    
            return Ok(result);  
        }

    }
}
