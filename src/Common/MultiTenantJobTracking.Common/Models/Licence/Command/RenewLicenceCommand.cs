using MultiTenantJobTracking.Common.Enums;

namespace MultiTenantJobTracking.Common.Models.Licence.Command
{
    public class RenewLicenceCommand
    {
        public Guid UserId { get; set; }
        public LicenceTime LicenceTime { get; set; }
    }
}
