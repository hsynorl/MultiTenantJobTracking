using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Queries;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobLogsController : ControllerBase
    {
        private readonly IJobLogService jobLogService;

        public JobLogsController(IJobLogService jobLogService)
        {
            this.jobLogService = jobLogService;
        }

        [HttpGet("get-job-log-by-job-id")]
        public async Task<IActionResult> GetJobLogsByJobId([FromQuery]Guid JobId)
        {
            var result = await jobLogService.GetJobLogsByJobId(new GetJobLogsByJobIdQuery { JobId=JobId});
            return Ok(result);  
        }
        [HttpGet("get-job-log-by-user-id")]
        public async Task<IActionResult> GetJobLogsByUserId([FromQuery] Guid UserId)
        {
            var result = await jobLogService.GetJobLogsByUserId(new GetJobLogsByUserIdQuery { UserId=UserId});
            return Ok(result);
        }
    }

}
