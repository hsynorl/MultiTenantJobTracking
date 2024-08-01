using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class JobLogProfile : Profile
    {
        public JobLogProfile()
        {
            CreateMap<JobLog, GetJobLogsViewModel>().ReverseMap();
            CreateMap<JobLog,CreateJobLogCommand >();
        }
    }

}
