using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Licence.Command;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Concrete;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class LicenceService : ILicenceService
    {
        private readonly ILicenceRepository licenceRepository;
        private readonly IMapper mapper;
        public LicenceService(ILicenceRepository licenceRepository, IMapper mapper)
        {
            this.licenceRepository = licenceRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CheckLicenceExpireTime(Guid TenanId)
        {
            var result = await licenceRepository.GetSingleAsync(p => p.Id == TenanId);
            if (result == null)
            {
                throw new Exception("Not Found");
            }
            if (result.ExpireDate > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CreateLicence(CreateLicenceCommand createLicenceCommand)
        {
            var licence = mapper.Map<Licence>(createLicenceCommand);
            licence.ExpireDate = DateTime.Now.AddDays((int)createLicenceCommand.LicenceTime);
            var result = await licenceRepository.AddAsync(licence);
            return result > 0;
        }

        public async Task<bool> RenewLicense(RenewLicenceCommand renewLicenceCommand)
        {
            var licence= await licenceRepository.GetSingleAsync(p => p.Id == renewLicenceCommand.TenantId);
            licence.ExpireDate = DateTime.Now.AddDays((int)renewLicenceCommand.LicenceTime);
            var result=await licenceRepository.UpdateAsync(licence);
            return result > 0;  
        }
    }
}
