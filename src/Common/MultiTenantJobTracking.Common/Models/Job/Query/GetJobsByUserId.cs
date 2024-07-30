using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Job.Query
{
    public class GetJobsByUserId
    {
        public Guid UserId { get; set; }
    }
}
