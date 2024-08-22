using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
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
        private readonly IUserJobRepository userJobRepository;
        private readonly IJobLogService jobLogService;
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper, IJobLogService jobLogService, IUserJobRepository userJobRepository)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
            this.jobLogService = jobLogService;
            this.userJobRepository = userJobRepository;
        }

        public async Task<IResponseResult> CreateJob(CreateJobCommand createJobCommand)
        {
            var job = mapper.Map<Job>(createJobCommand);
            var result=await jobRepository.AddAsync(job);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IResponseResult> DeleteJob(DeleteJobCommand deleteJobCommand)
        {
            var deleteJob = await jobRepository.GetSingleAsync(p => p.Id == deleteJobCommand.JobId);
            var job = mapper.Map<Job>(deleteJob);
            var result=await jobRepository.DeleteAsync(job);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IDataResult<List<JobViewModel>>> GetJobsByUserId(Guid userId)
        {
            var result = await userJobRepository.AsQueryable().Include(p => p.Job).Where(p => p.UserId == userId).ToListAsync();
            if (result.Count < 1)
            {
                return new ErrorDataResult<List<JobViewModel>>("Kullanıcıya atanmış iş bulunmadı");
            }
            var jobs=mapper.Map<List<JobViewModel>>(result);  
            return new SuccessDataResult<List<JobViewModel>>(jobs);    
        }

        public async Task<IResponseResult> UpdateJob(UpdateJobCommand updateJobCommand)
        {
            var updateJob = await jobRepository.GetSingleAsync(p => p.Id == updateJobCommand.JobId);
            if (updateJob is null)
            {
                return new ErrorResult("İş bulunamadı");
            }
            var job = mapper.Map<Job>(updateJobCommand);
            var result = await jobRepository.UpdateAsync(job);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        
        public async Task<IResponseResult> UpdateJobStatus(UpdateStatusJobCommand updateStatusJobCommand)
        {
            var updateJob = await jobRepository.GetSingleAsync(p => p.Id == updateStatusJobCommand.JobId);
            if (updateJob is null)
            {
                return new ErrorResult("İş bulunamadı");
            }
            updateJob.JobStatus = updateStatusJobCommand.JobStatus;
            var result = await jobRepository.UpdateAsync(updateJob);
            if( result > 0)
            {
              var logResult= await jobLogService.CreateJobLog(new()
                {
                    JobId = updateJob.Id,
                    JobStatus = updateStatusJobCommand.JobStatus,
                    UserId = updateStatusJobCommand.UserId
                });
                return new SuccessResult();
            }
            return new ErrorResult();   
        }
    }
}
