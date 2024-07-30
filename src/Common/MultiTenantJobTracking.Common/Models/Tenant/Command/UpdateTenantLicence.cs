using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Tenant.Command
{
    public class UpdateTenantLicence
    {
        public Guid TenantId { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
