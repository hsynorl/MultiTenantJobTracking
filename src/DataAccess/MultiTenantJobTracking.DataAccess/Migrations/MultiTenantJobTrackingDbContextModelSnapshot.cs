﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiTenantJobTracking.DataAccess.Context;

#nullable disable

namespace MultiTenantJobTracking.DataAccess.Migrations
{
    [DbContext(typeof(MultiTenantJobTrackingDbContext))]
    partial class MultiTenantJobTrackingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.DepartmentAdmin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("DepartmentAdmins");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.DepartmentUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("DepartmentUsers");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobStatus")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.JobComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("JobComments");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.JobLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("JobStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("JobLogs");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Licence", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Licence");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.TenantUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("TenantUsers");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.UserJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("UserJobs");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Department", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Tenant", "Tenant")
                        .WithMany("Departments")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.DepartmentAdmin", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Department", "Department")
                        .WithMany("DepartmentAdmins")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.User", "User")
                        .WithMany("DepartmentAdmins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.DepartmentUser", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.User", "User")
                        .WithOne("DepartmentUser")
                        .HasForeignKey("MultiTenantJobTracking.Entities.Concrete.DepartmentUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.JobComment", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Job", "Job")
                        .WithMany("JobComments")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.User", "User")
                        .WithMany("JobComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.JobLog", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Job", "Job")
                        .WithMany("JobLogs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.User", "User")
                        .WithMany("JobLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Licence", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Tenant", "Tenant")
                        .WithOne("Licence")
                        .HasForeignKey("MultiTenantJobTracking.Entities.Concrete.Licence", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.TenantUser", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Tenant", "Tenant")
                        .WithMany("TenantAdmins")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.User", "User")
                        .WithMany("TenantAdmin")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.UserJob", b =>
                {
                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.Job", "Job")
                        .WithMany("UserJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantJobTracking.Entities.Concrete.User", "User")
                        .WithMany("UserJobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Department", b =>
                {
                    b.Navigation("DepartmentAdmins");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Job", b =>
                {
                    b.Navigation("JobComments");

                    b.Navigation("JobLogs");

                    b.Navigation("UserJobs");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.Tenant", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Licence")
                        .IsRequired();

                    b.Navigation("TenantAdmins");
                });

            modelBuilder.Entity("MultiTenantJobTracking.Entities.Concrete.User", b =>
                {
                    b.Navigation("DepartmentAdmins");

                    b.Navigation("DepartmentUser")
                        .IsRequired();

                    b.Navigation("JobComments");

                    b.Navigation("JobLogs");

                    b.Navigation("TenantAdmin");

                    b.Navigation("UserJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
