using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class UserJobProfile:Profile
    {
        public UserJobProfile()
        {
            CreateMap<CreateUserJobCommand, UserJob>();  
            CreateMap<UserJob, JobViewModel>()
                .ForMember(p=>p.JobStatus,y=>y.MapFrom(z=>z.Job.JobStatus))
                .ForMember(p=>p.Description,y=>y.MapFrom(z=>z.Job.Description))
                .ForMember(p=>p.DeadLine,y=>y.MapFrom(z=>z.Job.DeadLine))
                .ForMember(p=>p.CreateDate,y=>y.MapFrom(z=>z.Job.CreateDate))
                .ForMember(p=>p.Title,y=>y.MapFrom(z=>z.Job.Title))
                .ForMember(p=>p.JobId,y=>y.MapFrom(z=>z.JobId))
                
                ;  
        }
    }
}
