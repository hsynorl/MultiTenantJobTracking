using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository tenantRepository;
        private readonly IMapper mapper;

        public TenantService(ITenantRepository tenantRepository, IMapper mapper)
        {
            this.tenantRepository = tenantRepository;
            this.mapper = mapper;
        }

      

        public async Task<bool> CreateTenant(CreateTenantCommand createTenantCommand)
        {
            var existTenant=await tenantRepository.GetSingleAsync(p=>p.Name==createTenantCommand.Name);
            if (existTenant is not null)
            {
                throw new ExistingRecordException("Aynı isime sahip tenant var");
            }
            var tenant=mapper.Map<Tenant>(createTenantCommand);
            var result=await tenantRepository.AddAsync(tenant);
            return result > 0;
        }
    }


}
