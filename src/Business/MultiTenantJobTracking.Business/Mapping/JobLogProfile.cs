using AutoMapper;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class JobLogProfile : Profile
    {
        public JobLogProfile()
        {
            CreateMap<JobLog,GetJobLogsByJobIdQuery >();
        }
    }

}
