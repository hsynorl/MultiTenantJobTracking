using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Tenant.Command;
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

        public async Task<bool> CheckLicenceExpireTime(Guid TenantId)
        {
            var result=await tenantRepository.GetSingleAsync(p=>p.Id== TenantId);   
            if (result == null)
            {
                throw new Exception("Not Found");
            }
            if (result.ExpireDate>DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateTenant(CreateTenantCommand createTenantCommand)
        {
            var tenant=mapper.Map<Tenant>(createTenantCommand);
            var result=await tenantRepository.AddAsync(tenant);
            return result > 0;
        }

        public async Task<bool> UpdateLicence(UpdateTenantLicenceCommand updateTenantLicenceCommand)
        {
            var updateLicenceTenant = await tenantRepository.GetSingleAsync(p => p.Id == updateTenantLicenceCommand.TenantId);
            if (updateLicenceTenant is null)
            {
                throw new Exception("Not Found!");
            }
            updateLicenceTenant.ExpireDate = updateTenantLicenceCommand.ExpireDate;
            var result = await tenantRepository.UpdateAsync(updateLicenceTenant);
            return result > 0;  
        }
    }


}
