using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.Models.Department.Command;
using MultiTenantJobTracking.Common.Models.Department.Query;
using MultiTenantJobTracking.Common.Models.Department.ViewModel;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<bool> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            var department=mapper.Map<Department>(createDepartmentCommand);
            var result=await departmentRepository.AddAsync(department);
            return result > 0;
        }

        public async Task<List<DepartmentViewModel>> GetDepartments(GetDepartmentsQuery getDepartmentsQuery)
        {
            var resutl= await departmentRepository.GetList(p => p.TenantId == getDepartmentsQuery.TenantId);
            var departments=mapper.Map<List<DepartmentViewModel>>(resutl);
            return departments;
        }
    }
}
