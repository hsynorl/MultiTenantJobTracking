﻿using MultiTenantJobTracking.Client.Services.Abstraction;
using MultiTenantJobTracking.Common.Models.Commands;
using MultiTenantJobTracking.Common.Results;

namespace MultiTenantJobTracking.Client.Services.Concrete
{
    public class TenantService : ITenantService
    {
        private readonly HttpClient _httpClient;

        public TenantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IResponseResult> CreateTenant(CreateTenantCommand createTenantCommand)
        {
            throw new NotImplementedException();
        }
    }


}
