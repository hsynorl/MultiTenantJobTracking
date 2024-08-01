using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
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

        public async Task<bool> CreateJobComment(CreateJobCommentCommand createJobCommand)
        {
            var jobComment = mapper.Map<JobComment>(createJobCommand);
            var result=await jobCommentRepository.AddAsync(jobComment);
            return result > 0;
        }

        public async Task<List<JobCommentViewModel>> GetJobCommentsByJobId(Guid jobId)
        {
            var result = await jobCommentRepository.GetList(p => p.JobId == jobId);
            if (result.Count<1)
            {
                throw new NotFoundException("Seçilen işe ait yorum bulunamadı");
            }
            var jobComments = mapper.Map<List<JobCommentViewModel>>(result);
            return jobComments; 
        }

        public async Task<List<JobCommentViewModel>> GetJobCommentsByUserId(Guid UserId)
        {
            var result =await jobCommentRepository.GetList(p => p.UserId == UserId);
            if (result.Count < 1)
            {
                throw new NotFoundException("Kullanıcıya ait yorum bulunamadı");
            }
            var jobComments = mapper.Map<List<JobCommentViewModel>>(result);
            return jobComments;
        }
    }

}
