using MultiTenantJobTracking.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Job.ViewModel
{
    public class JobViewModel
    {
        public Guid JobId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeadLine { get; set; }
        public JobStatus JobStatus { get; set; }
        public string Description { get; set; }
    }

}
