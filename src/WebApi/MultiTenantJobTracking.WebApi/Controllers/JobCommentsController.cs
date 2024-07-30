using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCommentsController : ControllerBase
    {
        private readonly IJobCommentService jobCommentService;

        public JobCommentsController(IJobCommentService jobCommentService)
        {
            this.jobCommentService = jobCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(Guid JobId)
        {
            var result = await jobCommentService.GetJobCommentsByJobId(JobId);
            return Ok(result);
        }
    }
}
