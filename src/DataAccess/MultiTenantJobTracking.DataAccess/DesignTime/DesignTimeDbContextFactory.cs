using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MultiTenantJobTracking.DataAccess.Context;
using Microsoft.Extensions.Configuration;


namespace MultiTenantJobTracking.DataAccess.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MultiTenantJobTrackingDbContext>
    {
        public MultiTenantJobTrackingDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MultiTenantJobTrackingDbContext> dbContextOptionsBuilder = new();
            string connectionString = "Server=localhost;Database=MultiTenantJobTrackingDb;User Id=sa;Password=og~8O+nwAT%5c0a8V8G]G+tEi;TrustServerCertificate=True;";

            dbContextOptionsBuilder.UseSqlServer(connectionString);
            var configuration = new ConfigurationBuilder().Build();
            return new MultiTenantJobTrackingDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
