using AutoMapper;
using MultiTenantJobTracking.Common.Models.Depatment.Command;
using MultiTenantJobTracking.Common.Models.Depatment.ViewModel;
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
            CreateMap<Department,CreateDepartmentCommand>();
            CreateMap<Department,DepartmentViewModel>();

        }
    }

}
