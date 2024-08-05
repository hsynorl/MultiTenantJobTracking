using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.WebApi.Services;
using System.Security.Claims;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly UserHelper userHelper;

        public JobsController(IJobService jobService, UserHelper userHelper)
        {
            this.jobService = jobService;
            this.userHelper = userHelper;
        }
        [HttpGet("get-jobs-by-user-id")]
        [Authorize(Roles = $"{nameof(UserType.User)},{nameof(UserType.DepartmanAdmin)},{nameof(UserType.TenantAdmin)}")]
        public async Task<ActionResult> GetJobsByUserId()
        {
            var userId=userHelper.GetUserId();
            var result = await jobService.GetJobsByUserId(userId);
            return Ok(result);
        }
        [HttpPost("crate-job")]
        [Authorize(Roles = $"{nameof(UserType.DepartmanAdmin)},{nameof(UserType.TenantAdmin)}")]

        public async Task<ActionResult> CreateJob(CreateJobCommand createJobCommand)
        {
            var result = await jobService.CreateJob(createJobCommand);
            return Ok(result);
        }
        [HttpPut("update-job")]
        [Authorize(Roles = $"{nameof(UserType.TenantAdmin)},{nameof(UserType.DepartmanAdmin)}")]
        public async Task<ActionResult> UpdateJob(UpdateJobCommand updateJobCommand)
        {

            var result = await jobService.UpdateJob(updateJobCommand);
            return Ok(result);
        }
        [HttpPut("update-job-status")]
        [Authorize(Roles = nameof(UserType.User))]
        public async Task<ActionResult> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand)
        {

            var result = await jobService.UpdateJobStatus(updateStatusJobCommand);
            return Ok(result);
        }
        [HttpDelete("delete-job")]
        [Authorize(Roles = $"{nameof(UserType.TenantAdmin)},{nameof(UserType.DepartmanAdmin)}")]
        public async Task<ActionResult> DeleteJob(DeleteJobCommand deleteJobCommand)
        {

            var result = await jobService.DeleteJob(deleteJobCommand);
            return Ok(result);
        }
    }
}
