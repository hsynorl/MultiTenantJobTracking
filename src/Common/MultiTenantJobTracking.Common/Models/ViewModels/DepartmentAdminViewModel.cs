﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.ViewModels
{
    public class DepartmentAdminViewModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
    }
}
