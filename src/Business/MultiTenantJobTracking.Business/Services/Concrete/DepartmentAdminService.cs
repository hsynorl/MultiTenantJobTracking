using AutoMapper;
using MultiTenantJobTracking.Business.Services.Abstract;
using MultiTenantJobTracking.Common.CustomExceptions;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Models.Queries;
using MultiTenantJobTracking.Common.Models.ViewModels;
using MultiTenantJobTracking.DataAccess.Repositories.Abstract;
using MultiTenantJobTracking.Entities.Concrete;

namespace MultiTenantJobTracking.Business.Services.Concrete
{
    public class DepartmentAdminService : IDepartmentAdminService
    {
        private readonly IMapper mapper;
        private readonly IDepartmentAdminRepository departmentAdminRepository;

        public DepartmentAdminService(IMapper mapper, IDepartmentAdminRepository departmentAdminRepository)
        {
            this.mapper = mapper;
            this.departmentAdminRepository = departmentAdminRepository;
        }

        public async Task<bool> CreateDepartmentAdmin(CreateDepartmentAdminCommand createDepartmentAdminCommand)
        {
            var departmentAdmin=mapper.Map<DepartmentAdmin>(createDepartmentAdminCommand);
            var result=await departmentAdminRepository.AddAsync(departmentAdmin);
            return result > 0;
        }

        public async Task<bool> DeleteDepartmentAdmin(DeleteDepartmentAdminCommand deleteDepartmentAdminCommand)
        {
            var departmentAdmin=await departmentAdminRepository.GetSingleAsync(p=>p.DepartmentId==deleteDepartmentAdminCommand.DepartmentId);
            if (departmentAdmin == null)
            {
                throw new NotFoundException("Department admin bulunamadı");
            }
            var result=await departmentAdminRepository.DeleteAsync(departmentAdmin);
            return result > 0;
        }

        public async Task<List<DepartmentAdminViewModel>> GetDepartmentAdminsByDepartmentId(GetDepartmentAdminsByDepartmentIdQuery getDepartmentAdminsByDepartmentIdQuery)
        {
            var result = await departmentAdminRepository.GetList(p => p.DepartmentId == getDepartmentAdminsByDepartmentIdQuery.DepartmentId);
            if (result == null)
            {
                throw new NotFoundException("Department admin bulunamadı");
            }
            var departmentAdmins=mapper.Map<List<DepartmentAdminViewModel>>(result);
            return departmentAdmins;
        }

        public async Task<bool> UpdateDepartmentAdmin(UpdateDepartmentAdminCommand updateDepartmentAdminCommand)
        {
            var updateDepartmentAdmin = await departmentAdminRepository.GetSingleAsync(p => p.Id == updateDepartmentAdminCommand.UpdateDepartmentId);
            if (updateDepartmentAdmin == null)
            {
                throw new NotFoundException("Department admin bulunamadı");
            }
            var departmentAdmin = mapper.Map<DepartmentAdmin>(updateDepartmentAdminCommand);
            var result = await departmentAdminRepository.UpdateAsync(departmentAdmin);
            return result > 0;
        }
    }
}
