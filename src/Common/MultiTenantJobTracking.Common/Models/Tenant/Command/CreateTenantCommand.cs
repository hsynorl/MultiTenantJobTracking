using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Tenant.Command
{
    public class CreateTenantCommand
    {
        public string Name { get; set; }
    }
}
