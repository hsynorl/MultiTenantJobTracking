using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.UserJob.Command
{
    public class CreateUserJobCommand
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
    }
}
