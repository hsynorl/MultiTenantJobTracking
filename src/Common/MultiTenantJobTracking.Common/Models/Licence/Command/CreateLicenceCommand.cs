using MultiTenantJobTracking.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Licence.Command
{
    public class CreateLicenceCommand
    {
        public Guid UserId { get; set; }
        public LicenceTime LicenceTime { get; set; }
    }
}
