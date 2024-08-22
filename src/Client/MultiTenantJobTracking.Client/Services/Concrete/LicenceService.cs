using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public partial class UserJobService
    {
        public class LicenceService : ILicenceService
        {
            private readonly HttpClient _httpClient;

            public LicenceService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public Task<IResponseResult> CreateLicence(CreateLicenceCommand createLicenceCommand)
            {
                throw new NotImplementedException();
            }
        }

    }
