using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.DepartmentUser.Query
{
    public class GetDepartmentByUserId
    {
        public Guid UserId { get; set; }
    }
}
