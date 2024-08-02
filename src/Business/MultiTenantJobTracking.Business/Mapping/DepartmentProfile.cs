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
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<CreateDepartmentCommand,Department >()
                .ForMember(p => p.TenantId, y => y.MapFrom(z => z.TenantId))
                .ForMember(p => p.Name, y => y.MapFrom(z => z.Name));

            CreateMap<Department,DepartmentViewModel>()
                .ForMember(p=>p.Id,y=>y.MapFrom(z=> z.Id))  
                .ForMember(p=>p.Name,y=>y.MapFrom(z=> z.Name))  
                .ReverseMap();

        }
    }

}
