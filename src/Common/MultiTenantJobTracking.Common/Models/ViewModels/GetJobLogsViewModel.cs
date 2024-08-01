using MultiTenantJobTracking.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.ViewModels
{
    public class GetJobLogsViewModel
    {
        public Guid JobId { get; set; }
        public Guid UserId { get; set; }
        public JobStatus JobStatus { get; set; }
    }
}
