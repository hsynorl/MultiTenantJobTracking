using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class JobService : IJobService
    {
        private readonly HttpClient _httpClient;

        public JobService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResponseResult> CreateJob(CreateJobCommand createJobCommand)
        {
            var response = await _httpClient.PostAsJsonAsync("Jobs/create-job", createJobCommand);
            var responseViewModel = await response.Content.ReadFromJsonAsync<Result>();
            return responseViewModel;
        }

        public async Task<IResponseResult> UpdateJob(UpdateJobCommand updateJobCommand)
        {
            var response = await _httpClient.PutAsJsonAsync("Jobs/update-job", updateJobCommand);
            var responseViewModel = await response.Content.ReadFromJsonAsync<Result>();
            return responseViewModel;
        }
    }





}
