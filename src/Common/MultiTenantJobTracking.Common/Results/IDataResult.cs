namespace MultiTenantJobTracking.Common.Results
{
    public interface IDataResult<T> :IResponseResult
    {
        T Result { get; }   
    }
}
