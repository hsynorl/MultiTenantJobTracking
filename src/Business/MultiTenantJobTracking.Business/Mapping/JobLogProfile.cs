using AutoMapper;
using MultiTenantJobTracking.Common.Models.JobLog.Query;
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
