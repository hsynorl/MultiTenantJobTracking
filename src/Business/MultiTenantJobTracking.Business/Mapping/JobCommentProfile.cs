using AutoMapper;
using MultiTenantJobTracking.Common.Models.JobComment.Command;
using MultiTenantJobTracking.Common.Models.JobComment.ViewModel;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class JobCommentProfile : Profile
    {
        public JobCommentProfile()
        {
            CreateMap<JobComment, CreateJobCommentCommand>();
            CreateMap<JobComment, JobCommentViewModel>();
        }
    }

}
