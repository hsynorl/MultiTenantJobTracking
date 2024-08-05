namespace MultiTenantJobTracking.Common.Results
{
    public interface IDataResult<T> :IResult
    {
        T Result { get; }   
    }
}
