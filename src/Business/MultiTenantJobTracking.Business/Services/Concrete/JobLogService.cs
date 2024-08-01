using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Enums;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;
using System.Collections.Generic;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class JobLogService : IJobLogService
    {
        private readonly IMapper mapper;
        private readonly IJobLogRepository jobLogRepository;

        public JobLogService(IMapper mapper, IJobLogRepository jobLogRepository)
        {
            this.mapper = mapper;
            this.jobLogRepository = jobLogRepository;
        }

        public async Task<bool> CreateJobLog(CreateJobLogCommand createJobLogCommand)
        {
            var jobLog = mapper.Map<JobLog>(createJobLogCommand);
            jobLog.CreateDate = DateTime.Now;
            var result=await jobLogRepository.AddAsync(jobLog);
            return result > 0;

        }

        public async Task<List<GetJobLogsViewModel>> GetJobLogsByJobId(GetJobLogsByJobIdQuery getJobLogsByJobIdQuery)
        {
            var jobLogs=await jobLogRepository.GetList(p=>p.JobId==getJobLogsByJobIdQuery.JobId);
            if (jobLogs.Count<1)
            { 
                    throw new NotFoundException("İşe ait kayıt bulunamadı");
             }
            var result=mapper.Map<List<GetJobLogsViewModel>>(jobLogs);
            return result;
        }

        public async Task<List<GetJobLogsViewModel>> GetJobLogsByUserId(GetJobLogsByUserIdQuery getJobLogsByUserIdQuery)
        {
            var jobLogs = await jobLogRepository.GetList(p => p.UserId == getJobLogsByUserIdQuery.UserId);
            if (jobLogs.Count < 1)
            {
                throw new NotFoundException("Kullanıcıya ait iş kaydı bulunamadı");
            }
            var result = mapper.Map<List<GetJobLogsViewModel>>(jobLogs);
            return result;
        }

    }



}
