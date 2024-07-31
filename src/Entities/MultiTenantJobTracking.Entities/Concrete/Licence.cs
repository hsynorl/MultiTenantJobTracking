using MultiTenantJobTracking.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Entities.Concrete
{
    public class Licence:BaseEntity
    {
        public DateTime ExpireDate { get; set; }
        public virtual User User { get; set; }
    }
}
