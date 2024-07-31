﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Job.Command;

namespace MultiTenantJobTracking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService jobService;

        public JobsController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet("get-jobs-by-user-id")]
        public async Task<ActionResult> GetJobsByUserId([FromQuery]Guid UserId) {
        
            var result=await jobService.GetJobsByUserId(UserId);
            return Ok(result);  
        }
        [HttpPost("crate-job")]
        public async Task<ActionResult> CreateJob(CreateJobCommand createJobCommand)
        {

            var result = await jobService.CreateJob(createJobCommand);
            return Ok(result);
        }
        [HttpPut("update-job")]
        public async Task<ActionResult> UpdateJob(UpdateJobCommand updateJobCommand)
        {

            var result = await jobService.UpdateJob(updateJobCommand);
            return Ok(result);
        }
        [HttpPut("update-job-status")]
        public async Task<ActionResult> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand)
        {

            var result = await jobService.UpdateJobStatus(updateStatusJobCommand);
            return Ok(result);
        }
        [HttpDelete("delete-job")]
        public async Task<ActionResult> DeleteJob(DeleteJobCommand deleteJobCommand)
        {

            var result = await jobService.DeleteJob(deleteJobCommand);
            return Ok(result);
        }
    }
}
