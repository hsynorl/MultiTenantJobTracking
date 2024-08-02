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
    public class DepartmentAdminProfile:Profile
    {
        public DepartmentAdminProfile()
        {
            CreateMap<CreateDepartmentAdminCommand, DepartmentAdmin>()
                .ForMember(p=>p.Id,y=>y.MapFrom(z=>z.UserId))
                .ForMember(p=>p.DepartmentId,y=>y.MapFrom(z=>z.DepartmentId));
            CreateMap<UpdateDepartmentAdminCommand, DepartmentAdmin>();
            CreateMap<DepartmentAdmin, DepartmentAdminViewModel>()
                .ForMember(p=>p.FirstName ,y=>y.MapFrom(z=>z.User.FirstName)).ReverseMap();
        }
    }
}
