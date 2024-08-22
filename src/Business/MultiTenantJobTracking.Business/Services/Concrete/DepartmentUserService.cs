using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.Common.Results;
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

        public async Task<IResponseResult> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {
            var departmentUser = mapper.Map<DepartmentUser>(createDepartmentUserCommand);
            var result=await departmentUserRepository.AddAsync(departmentUser);
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        public async Task<IDataResult<DepartmentViewModel>> GetUserDepartment(Guid UserId)
        {
            var result=await departmentUserRepository.AsQueryable().Include(p=>p.Department).FirstOrDefaultAsync(p=>p.Id==UserId);
            if (result is null)
            {
                return new ErrorDataResult<DepartmentViewModel>();
            }
            var departmentViewModel=mapper.Map<DepartmentViewModel>(result.Department);    
            return new SuccessDataResult<DepartmentViewModel>(departmentViewModel);
        }

        public async Task<IDataResult<List<UserViewModel>>> GetUsersByDepartmentId(Guid DepartmentId)
        {
            var result = await departmentUserRepository.AsQueryable().Include(p => p.User).Where(p => p.DepartmentId == DepartmentId).ToListAsync();;
            if (result.Count<1)
            {
                return new ErrorDataResult<List<UserViewModel>>();
            }
            var users = mapper.Map<List<UserViewModel>>(result);
            return new SuccessDataResult<List<UserViewModel>>(users);
        }
        public async Task<IResponseResult> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand)
        {
            var departmentAdmin = mapper.Map<DepartmentUser>(createDepartmentAdminCommand);
            var result = await departmentUserRepository.AddAsync(departmentAdmin);
            if (result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
