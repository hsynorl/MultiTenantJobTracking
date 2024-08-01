using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class JobCommentsController : ControllerBase
    {
        private readonly IJobCommentService jobCommentService;

        public JobCommentsController(IJobCommentService jobCommentService)
        {
            this.jobCommentService = jobCommentService;
        }

        [HttpGet("get-job-comments-by-job-id")]
        public async Task<IActionResult> GetJobCommentsByJobId(Guid JobId)
        {
            var result = await jobCommentService.GetJobCommentsByJobId(JobId);
            return Ok(result);
        }
        [HttpPost("create-job-comment")]
        public async Task<IActionResult> CreateJobComment(CreateJobCommentCommand createJobCommentCommand)
        {
            var result = await jobCommentService.CreateJobComment(createJobCommentCommand);
            return Ok(result);
        }
    }
}
