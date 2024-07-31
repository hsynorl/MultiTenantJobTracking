using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Department.ViewModel;
using MultiTenantJobTracking.Common.Models.DepartmentUser.Command;
using MultiTenantJobTracking.Common.Models.DepartmentUser.ViewModel;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
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
            var departmentViewModel=mapper.Map<DepartmentViewModel>(result.Department);    
            return departmentViewModel;
        }
              
    }
}
