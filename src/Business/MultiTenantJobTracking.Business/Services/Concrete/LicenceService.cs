using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;
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

        public async Task<IResponseResult> CheckLicenceExpireTime(Guid TenantId)
        {
            var result = await licenceRepository.GetSingleAsync(p => p.Id == TenantId);
            if (result is null)
            {
                throw new NotFoundException();
            }
            if (result.ExpireDate > DateTime.Now)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IResponseResult> CreateLicence(CreateLicenceCommand createLicenceCommand)
        {
            var licence = mapper.Map<Licence>(createLicenceCommand);
            licence.ExpireDate = DateTime.Now.AddDays((int)createLicenceCommand.LicenceTime);
            var result = await licenceRepository.AddAsync(licence);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IResponseResult> RenewLicense(RenewLicenceCommand renewLicenceCommand)
        {
            var licence= await licenceRepository.GetSingleAsync(p => p.Id == renewLicenceCommand.TenantId);
            if (licence is null)
            {
                return new ErrorResult("Lisans bulunamadı"); 
            }
            licence.ExpireDate = DateTime.Now.AddDays((int)renewLicenceCommand.LicenceTime);
            var result=await licenceRepository.UpdateAsync(licence);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
