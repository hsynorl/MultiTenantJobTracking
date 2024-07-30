using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.DepartmentAdmin.Command
{
    public class CreateDepartmentAdminCommand
    {
        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
