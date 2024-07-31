using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Common.Models.Licence.Command
{
    public class RenewLicenceCommand
    {
        public Guid TenantId { get; set; }
        public LicenceTime LicenceTime { get; set; }
    }
}
