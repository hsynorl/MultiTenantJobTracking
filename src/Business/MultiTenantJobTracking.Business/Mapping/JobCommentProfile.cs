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
            CreateMap<CreateJobCommentCommand, JobComment>()
                .ForMember(p=>p.Comment,y=>y.MapFrom(z=>z.Comment))
                .ForMember(p=>p.UserId,y=>y.MapFrom(z=>z.UserId))
                .ForMember(p=>p.JobId,y=>y.MapFrom(z=>z.JobId))
                ;
            CreateMap<JobComment, JobCommentViewModel>().ReverseMap() ;
        }
    }

}
