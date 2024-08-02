using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiTenantJobTracking.Common.Enums;
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
        IConfiguration configuration;
        public MultiTenantJobTrackingDbContext(IConfiguration configuration)
        {
            configuration = configuration;
            Database.Migrate();
        }

        public MultiTenantJobTrackingDbContext(DbContextOptions<MultiTenantJobTrackingDbContext> options, IConfiguration configuration)
            : base(options)
        {
            configuration = configuration;
            Database.Migrate();
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
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User()
            {
                EmailAddress = "admin@gmail.com",
                FirstName = "Hüseyin",
                LastName = "ORAL",
                Password = "admin",
                UserType = UserType.GeneralAdmin,
                PhoneNumber = "05360596086",
                Id = Guid.NewGuid(),

            }) ;

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>()
                .HasOne(u => u.DepartmentUser)
                .WithOne(du => du.User)
                .HasForeignKey<DepartmentUser>(du => du.Id); 

            modelBuilder.Entity<DepartmentUser>()
                .HasKey(du => new { du.Id, du.DepartmentId });


            modelBuilder.Entity<Tenant>()
              .HasOne(u => u.Licence)
              .WithOne(du => du.Tenant)
              .HasForeignKey<Licence>(du => du.Id);



            modelBuilder.Entity<User>()
            .HasOne(u => u.TenantAdmin)
            .WithOne(du => du.User)
            .HasForeignKey<TenantUser>(du => du.Id);
            modelBuilder.Entity<TenantUser>()
              .HasKey(du => new { du.Id, du.TenantId });



            modelBuilder.Entity<User>()
            .HasOne(u => u.DepartmentAdmin)
            .WithOne(du => du.User)
            .HasForeignKey<DepartmentAdmin>(du => du.Id);
          
            modelBuilder.Entity<DepartmentAdmin>()
           .HasKey(du => new { du.Id, du.DepartmentId });

            base.OnModelCreating(modelBuilder);
        }
        }
    }
