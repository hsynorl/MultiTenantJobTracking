﻿using AutoMapper;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }

        public async Task<IResponseResult> CreateDepartment(CreateDepartmentCommand createDepartmentCommand)
        {
            var existDepartment=await departmentRepository.GetSingleAsync(p=>p.Name==createDepartmentCommand.Name); 
            if (existDepartment is not null)
            {
                throw new ExistingRecordException();
            }
            var department=mapper.Map<Department>(createDepartmentCommand);
            var result=await departmentRepository.AddAsync(department);
            return new SuccessResult("Created Department");
        }

        public async Task<IDataResult<List<DepartmentViewModel>>> GetDepartmentsByTenantId(GetDepartmentsQuery getDepartmentsQuery)
        {
            var result = await departmentRepository.GetList(p => p.TenantId == getDepartmentsQuery.TenantId);
            if (result.Count < 1)
            {
                throw new NotFoundException();
            }
            var departments=mapper.Map<List<DepartmentViewModel>>(result);
            return new SuccessDataResult<List<DepartmentViewModel>>(departments);
        }
    }
}
