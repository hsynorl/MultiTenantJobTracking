using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.DataAccess.Repositories.Concrete;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class DepartmentUserService : IDepartmentUserService
    {
        private readonly IDepartmentUserRepository departmentUserRepository;
        private readonly IMapper mapper;

        public DepartmentUserService(IDepartmentUserRepository departmentUserRepository, IMapper mapper)
        {
            this.departmentUserRepository = departmentUserRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            var departmentUser = mapper.Map<DepartmentUser>(createDepartmentUserCommand);
            var result=await departmentUserRepository.AddAsync(departmentUser);
            return result > 0;
        }
        public async Task<DepartmentViewModel> GetUserDepartment(Guid UserId)
        {
            var result=await departmentUserRepository.AsQueryable().Include(p=>p.Department).FirstOrDefaultAsync(p=>p.Id==UserId);
            if (result is null)
            {
                throw new NotFoundException();
            }
            var departmentViewModel=mapper.Map<DepartmentViewModel>(result.Department);    
            return departmentViewModel;
        }

        public async Task<List<UserViewModel>> GetUsersByDepartmentId(Guid DepartmentId)
        {
            var result = await departmentUserRepository.AsQueryable().Include(p => p.User).Where(p => p.DepartmentId == DepartmentId).ToListAsync();;
            if (result.Count<1)
            {
                throw new NotFoundException();
            }
            var users = mapper.Map<List<UserViewModel>>(result);
            return users;
        }
        public async Task<bool> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand)
        {
            var departmentAdmin = mapper.Map<DepartmentUser>(createDepartmentAdminCommand);
            var result = await departmentUserRepository.AddAsync(departmentAdmin);
            return result > 0;
        }
    }
}
