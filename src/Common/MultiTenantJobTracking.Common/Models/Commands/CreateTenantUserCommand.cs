using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class CreateTenantUserCommand
    {
        public Guid TenantId { get; set; }
        public Guid UserId { get; set; }
    }
}
