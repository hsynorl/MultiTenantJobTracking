using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Queries
{
    public class GetChatQuery
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
