using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiTenantJobTracking.DataAccess.Configuration;
using MultiTenantJobTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantJobTracking.DataAccess.Context
{
    public class MultiTenantJobTrackingDbContext: DbContext
    {
        private readonly IConfiguration configuration;     
        public MultiTenantJobTrackingDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentAdmin> DepartmentAdmins { get; set; }
        public DbSet<DepartmentUser> DepartmentUsers{ get; set; }
        public DbSet<Job> Jobs{ get; set; }
        public DbSet<JobComment> JobComments{ get; set; }
        public DbSet<JobLog> JobLogs { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantUser> TenantUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserJob> UserJobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = configuration.GetConnectionString("sqlServer");
                optionsBuilder.UseSqlServer(connectionString);
                //optionsBuilder.UseSqlServer(Configuration.Configurations.ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>()
                .HasOne(u => u.DepartmentUser)
                .WithOne(du => du.User)
                .HasForeignKey<DepartmentUser>(du => du.Id); // DepartmentUser'daki Id, User Id'ye referans verir

            // DepartmentUser için composite key tanımla
            modelBuilder.Entity<DepartmentUser>()
                .HasKey(du => new { du.Id, du.DepartmentId });


            base.OnModelCreating(modelBuilder);
        }
        }
    }
