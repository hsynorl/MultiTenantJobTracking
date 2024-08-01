﻿using AutoMapper;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Mapping
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, CreateTenantCommand>().ReverseMap();
        }
    }

}
