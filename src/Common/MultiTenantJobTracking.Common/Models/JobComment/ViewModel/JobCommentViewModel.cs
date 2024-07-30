using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.JobComment.ViewModel
{
    public class JobCommentViewModel
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public string Comment { get; set; }
    }
}
