using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.DepartmentUser.Command;
using MultiTenantJobTracking.Common.Models.DepartmentUser.ViewModel;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class DepartmentUserService : IDepartmentUserService
    {
        private readonly IDepartmentUserRepository departmentUserRepository;

        public DepartmentUserService(IDepartmentUserRepository departmentUserRepository)
        {
            this.departmentUserRepository = departmentUserRepository;
        }

        public Task<bool> CreateDepartmentUser(CreateDepartmentUserCommand createDepartmentUserCommand)
        {

            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartmentUser(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentUserViewModel> GetDepartmentUsers(Guid UserId)
        {
            throw new NotImplementedException();
        }
    }
}
