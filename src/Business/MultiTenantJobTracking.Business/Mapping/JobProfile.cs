using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<CreateJobCommand, Job>();
            CreateMap<UpdateJobCommand, Job>()
                .ForMember(p=>p.Id,y=>y.MapFrom(z=>z.JobId));
            CreateMap<UpdateStatusJobCommand, Job>()
                .ForMember(p => p.Id, y => y.MapFrom(z => z.JobId));
            CreateMap<Job, JobViewModel>()
                .ForMember(p=>p.JobId,y=>y.MapFrom(z=>z.Id))
                .ReverseMap();

        }
    }

}
