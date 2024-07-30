using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.DepartmentAdmin.Query
{
    public class GetDepartmentAdminsByDepartmentIdQuery
    {
        public Guid DepartmentId { get; set; }
    }
}
