using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Depatment.Command;
using MultiTenantJobTracking.Common.Models.Depatment.ViewModel;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public Task<bool> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentViewModel>> GetDepartments()
        {
            throw new NotImplementedException();
        }
    }
}
