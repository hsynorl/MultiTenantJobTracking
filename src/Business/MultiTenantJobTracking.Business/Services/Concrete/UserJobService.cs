using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
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

        public async Task<IResponseResult> CreateUserJob(CreateUserJobCommand createUserJobCommand)
        {
            var userJob = mapper.Map<UserJob>(createUserJobCommand);
            var result=await userJobRepository.AddAsync(userJob);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }

    }


}
