using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Queries
{
    public class GetJobLogsByJobIdQuery
    {
        public Guid JobId { get; set; }
    }
}
