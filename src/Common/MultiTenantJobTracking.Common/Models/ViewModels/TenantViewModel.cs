using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.ViewModels
{
    public class TenantViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
