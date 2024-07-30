using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Department.Query
{
    public class GetDepartmentsQuery
    {
        public Guid TenantId { get; set; }
    }
}
