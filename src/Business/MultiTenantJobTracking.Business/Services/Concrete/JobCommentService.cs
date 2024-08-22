using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;
using System.Collections.Generic;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class JobCommentService : IJobCommentService
    {
        private readonly IMapper mapper;
        private readonly IJobCommentRepository jobCommentRepository;

        public JobCommentService(IMapper mapper, IJobCommentRepository jobCommentRepository)
        {
            this.mapper = mapper;
            this.jobCommentRepository = jobCommentRepository;
        }

        public async Task<IResponseResult> CreateJobComment(CreateJobCommentCommand createJobCommand)
        {
            var jobComment = mapper.Map<JobComment>(createJobCommand);
            var result=await jobCommentRepository.AddAsync(jobComment);
            if (result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IDataResult<List<JobCommentViewModel>>> GetJobCommentsByJobId(Guid jobId)
        {
            var result = await jobCommentRepository.GetList(p => p.JobId == jobId);
            if (result.Count<1)
            {
                return new ErrorDataResult<List<JobCommentViewModel>>("Seçilen işe ait yorum bulunamadı");    
            }
            var jobComments = mapper.Map<List<JobCommentViewModel>>(result);
            return new SuccessDataResult<List<JobCommentViewModel>>(jobComments); 
        }
    }

}
