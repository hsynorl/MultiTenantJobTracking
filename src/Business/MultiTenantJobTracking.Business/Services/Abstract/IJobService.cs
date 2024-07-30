namespace MultiTenantJobTracking.Business.Services.Abstract
{
    public interface IJobService
    {
        Task<bool> CreateJob();
        Task<bool> UpdateJob();
        Task<bool> DeleteJob();
        Task<bool> UpdateJobStatus();
        Task<bool> GetJobsByUserId();
        Task<bool> GetJobs();

    }

}
