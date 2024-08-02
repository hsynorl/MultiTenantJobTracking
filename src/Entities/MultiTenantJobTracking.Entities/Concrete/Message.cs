using MultiTenantJobTracking.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class Message:BaseEntity
    {
        public Guid ReceiverUserId { get; set; }
        public Guid SenderUserId { get; set; }
        public string Content{ get; set; }
        public DateTime SendDate{ get; set; }
        public virtual User SenderUser { get; set; }
        public virtual User ReceiverUser { get; set; }
    }
}
