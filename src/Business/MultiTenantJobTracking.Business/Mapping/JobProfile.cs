using AutoMapper;
using MultiTenantJobTracking.Common.Models.Job.Command;
using MultiTenantJobTracking.Common.Models.Job.ViewModel;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, CreateJobCommand>();
            CreateMap<Job, JobViewModel>();
        }
    }

}
