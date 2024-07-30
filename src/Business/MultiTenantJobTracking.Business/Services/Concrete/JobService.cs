using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Job.Command;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class JobService : IJobService
    {
        private readonly IJobLogService jobLogService;
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper, IJobLogService jobLogService)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
            this.jobLogService = jobLogService;
        }

        public async Task<bool> CreateJob(CreateJobCommand createJobCommand)
        {
            var job = mapper.Map<Job>(createJobCommand);
            var result=await jobRepository.AddAsync(job);
            return result > 0;

        }

        public async Task<bool> DeleteJob(DeleteJobCommand deleteJobCommand)
        {
            var deleteJob = await jobRepository.GetSingleAsync(p => p.Id == deleteJobCommand.JobId);
            var job = mapper.Map<Job>(deleteJob);
            var result=await jobRepository.DeleteAsync(job);
            return result > 0;
        }

    
        public async Task<bool> UpdateJob(UpdateJobCommand updateJobCommand)
        {
            var updateJob = await jobRepository.GetSingleAsync(p => p.Id == updateJobCommand.JobId);
            var job = mapper.Map<Job>(updateJobCommand);
            var result = await jobRepository.UpdateAsync(job);
            return result > 0;
        }

        public async Task<bool> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand)
        {
            var updateJob = await jobRepository.GetSingleAsync(p => p.Id == updateStatusJobCommand.JobId);
            var job = mapper.Map<Job>(updateStatusJobCommand);
            var result = await jobRepository.UpdateAsync(job);
            if( result > 0)
            {
              var logResult= await jobLogService.CreateJobLog(new()
                {
                    JobId = job.Id,
                    JobStatus = updateStatusJobCommand.JobStatus,
                    UserId = updateStatusJobCommand.UserId
                });
                return logResult;
                //TODO roll back yapılabilir
            }
            return false;   
        }
    }
}
