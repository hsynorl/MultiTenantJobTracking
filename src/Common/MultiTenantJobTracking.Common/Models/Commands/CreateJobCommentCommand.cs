using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Commands
{
    public class CreateJobCommentCommand
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public string Comment { get; set; }
    }
}
