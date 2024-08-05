using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<CreateTenantCommand, Tenant>().ReverseMap();
            CreateMap<TenantViewModel, Tenant>()
                .ReverseMap();
        }
    }

}
