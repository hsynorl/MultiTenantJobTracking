﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.DepartmentUser.ViewModel
{
    public class DepartmentUserViewModel
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
