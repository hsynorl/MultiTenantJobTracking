using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Queries
{
    public class GetJobCommentByJobId
    {
        public Guid JobId { get; set; }
    }
}
