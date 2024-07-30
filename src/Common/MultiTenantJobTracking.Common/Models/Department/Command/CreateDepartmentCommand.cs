using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.Department.Command
{
    public class CreateDepartmentCommand
    {
        public Guid TenantId { get; set; }
        public string Name { get; set; }
    }
   
}
