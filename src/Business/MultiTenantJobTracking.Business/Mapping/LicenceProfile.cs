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
    public class LicenceProfile:Profile
    {
        public LicenceProfile()
        {
            CreateMap<CreateLicenceCommand, Licence>()
                .ForMember(p => p.Id, y => y.MapFrom(z => z.TenantId));
        }
    }
}
