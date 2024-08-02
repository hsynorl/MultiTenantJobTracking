using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.ViewModels
{
    public class MessageViewModel
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
    }
}
