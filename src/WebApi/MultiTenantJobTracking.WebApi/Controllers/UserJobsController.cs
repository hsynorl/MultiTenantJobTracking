using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;

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
            var result = await userJobService.CreateUserJob(createUserJobCommand);
            return Ok(result);
        }
        [HttpGet("get-user-jobs-by-user-id")]
        public async Task<IActionResult> GetUserJobsByUserId([FromQuery] Guid UserId)
        {
            var result = await userJobService.GetUserJobsByUserId(new GetUserJobsByUserIdQuery { UserId=UserId});
            return Ok(result);
        }
    }
}
