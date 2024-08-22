namespace MultiTenantJobTracking.Common.Results
{
    public interface IResponseResult  
    {
        bool Success { get;  }
        string Message{ get;  }
    }
}
