﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.Common.Models.JobComment.Query
{
    public class GetJubCommentByJobId
    {
        public Guid JobId { get; set; }
    }
}
