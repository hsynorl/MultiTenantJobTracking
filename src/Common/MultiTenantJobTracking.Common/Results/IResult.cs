﻿namespace MultiTenantJobTracking.Common.Results
{
    public interface IResult  
    {
        bool Success { get;  }
        string Message{ get;  }
    }
}
