using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
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
            CreateMap<UserJob,CreateUserJobCommand>();  
        }
    }
}
