using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class JobCommentProfile : Profile
    {
        public JobCommentProfile()
        {
            CreateMap<JobComment, CreateJobCommentCommand>();
            CreateMap<JobComment, JobCommentViewModel>().ReverseMap() ;
        }
    }

}
