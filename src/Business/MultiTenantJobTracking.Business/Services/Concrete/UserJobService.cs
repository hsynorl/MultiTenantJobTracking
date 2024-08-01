using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class UserJobService : IUserJobService
    {
        private readonly IUserJobRepository userJobRepository;
        private readonly IMapper mapper;

        public UserJobService(IUserJobRepository userJobRepository, IMapper mapper)
        {
            this.userJobRepository = userJobRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateUserJob(CreateUserJobCommand createUserJobCommand)
        {
            var userJob = mapper.Map<UserJob>(createUserJobCommand);
            var result=await userJobRepository.AddAsync(userJob);
            return result > 0;
        }
    }


}
