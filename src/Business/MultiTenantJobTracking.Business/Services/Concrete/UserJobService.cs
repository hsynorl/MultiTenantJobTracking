using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
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

        public async Task<List<JobViewModel>> GetUserJobsByUserId(GetUserJobsByUserIdQuery getUserJobsByUserIdQuery)
        {
            var result=await userJobRepository.AsQueryable().Include(p=>p.Job).Where(p=>p.UserId== getUserJobsByUserIdQuery.UserId).ToListAsync();
            if (result.Count<1)
            {
                throw new NotFoundException("Kayıt bulunamadı");
            }
            var userJobs=mapper.Map<List<JobViewModel>>(result);
            return userJobs;
        }
    }


}
