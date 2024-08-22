using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
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

      

        public async Task<IResponseResult> CreateTenant(CreateTenantCommand createTenantCommand)
        {
            var existTenant=await tenantRepository.GetSingleAsync(p=>p.Name==createTenantCommand.Name);
            if (existTenant is not null)
            {
                return new ErrorResult("Aynı isime sahip tenant var");
            }
            var tenant=mapper.Map<Tenant>(createTenantCommand);
            tenant.CreateDate = DateTime.Now;
            var result=await tenantRepository.AddAsync(tenant);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IDataResult<TenantViewModel>> GetTenantByTenantId(Guid TenantId)
        {
            var result=await tenantRepository.GetSingleAsync(p=>p.Id==TenantId);
            if (result is null)
            {
                return new ErrorDataResult<TenantViewModel>("Kayıt bulunamadı");
            }
            var tenant=mapper.Map<TenantViewModel>(result);
            return new SuccessDataResult<TenantViewModel>(tenant);
        }
    }


}
