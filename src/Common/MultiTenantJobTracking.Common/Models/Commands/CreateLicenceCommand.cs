using MultiTenantJobTracking.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class CreateLicenceCommand
    {
        public Guid TenantId { get; set; }
        public LicenceTime LicenceTime { get; set; }
    }
}
