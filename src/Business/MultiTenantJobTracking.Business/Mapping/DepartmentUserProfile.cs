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
    public class DepartmentUserProfile:Profile
    {
        public DepartmentUserProfile()
        {
            CreateMap<DepartmentUser, DepartmentUserViewModel>().ReverseMap();
            CreateMap<CreateDepartmentUserCommand, DepartmentUser>()
                .ForMember(p=>p.Id,y=>y.MapFrom(z=>z.UserId));
        }
    }
}
