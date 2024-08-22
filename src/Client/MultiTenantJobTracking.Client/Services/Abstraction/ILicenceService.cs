using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Abstraction
{
    public interface ILicenceService
    {
        Task<IResponseResult> CreateLicence(CreateLicenceCommand createLicenceCommand);
        Task<IResponseResult> RenewLicense(RenewLicenceCommand renewLicenceCommand);
    }
}
