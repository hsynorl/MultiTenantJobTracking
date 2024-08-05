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
            .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.Job.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Job.Title))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.Job.CreateDate))
            .ForMember(dest => dest.DeadLine, opt => opt.MapFrom(src => src.Job.DeadLine))
            .ForMember(dest => dest.JobStatus, opt => opt.MapFrom(src => src.Job.JobStatus))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Job.Description))
            .ReverseMap();
                
                
        }
    }
}
