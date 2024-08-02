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
            var existDepartmentAdmin=await departmentAdminRepository.GetSingleAsync(p=>p.Id == createDepartmentAdminCommand.UserId);
            if (existDepartmentAdmin is not null)
            {
                throw new ExistingRecordException();
            }
            var departmentAdmin=mapper.Map<DepartmentAdmin>(createDepartmentAdminCommand);
            var result=await departmentAdminRepository.AddAsync(departmentAdmin);
            return result > 0;
        }

        public async Task<bool> DeleteDepartmentAdmin(DeleteDepartmentAdminCommand deleteDepartmentAdminCommand)
        {
            var departmentAdmin=await departmentAdminRepository.GetSingleAsync(p=>p.DepartmentId==deleteDepartmentAdminCommand.DepartmentId);
            if (departmentAdmin is null)
            {
                throw new NotFoundException("Department admin bulunamadı");
            }
            var result=await departmentAdminRepository.DeleteAsync(departmentAdmin);
            return result > 0;
        }

    }
}
