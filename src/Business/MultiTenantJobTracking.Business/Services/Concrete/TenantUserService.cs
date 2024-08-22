using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Commands;
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
    public class TenantUserService : ITenantUserService
    {
        private readonly IMapper mapper;
        private readonly ITenantUserRepository tenantUserRepository;

        public TenantUserService(IMapper mapper, ITenantUserRepository tenantUserRepository)
        {
            this.mapper = mapper;
            this.tenantUserRepository = tenantUserRepository;
        }

        public async Task<IResponseResult> CreateTenantUser(CreateTenantUserCommand createTenantCommand)
        {
            var tenantUser = mapper.Map<TenantUser>(createTenantCommand);
            var result=await tenantUserRepository.AddAsync(tenantUser);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
