﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(jobPortalDbContext))]
    [Migration("20220307063723_removedtable")]
    partial class removedtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Models.TblCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("company_name");

                    b.Property<long?>("ContactNo")
                        .HasColumnType("bigint")
                        .HasColumnName("contact_no");

                    b.Property<int?>("JobPosted")
                        .HasColumnType("int")
                        .HasColumnName("job_posted");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_company");
                });

            modelBuilder.Entity("WebApi.Models.TblExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("company_name");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndingDate")
                        .HasColumnType("date")
                        .HasColumnName("ending_date");

                    b.Property<string>("IsCurrent")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("is_current");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("job_title");

                    b.Property<int?>("SeekerId")
                        .HasColumnType("int")
                        .HasColumnName("seeker_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("SeekerId");

                    b.ToTable("tbl_experience");
                });

            modelBuilder.Entity("WebApi.Models.TblJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("company_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("description");

                    b.Property<string>("IsActive")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("is_active");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("location");

                    b.Property<int?>("NoOfVacancy")
                        .HasColumnType("int")
                        .HasColumnName("no_of_vacancy");

                    b.Property<int?>("Salary")
                        .HasColumnType("int")
                        .HasColumnName("salary");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("tbl_jobs");
                });

            modelBuilder.Entity("WebApi.Models.TblJobsApplied", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AppliedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("applied_on");

                    b.Property<int?>("JobId")
                        .HasColumnType("int")
                        .HasColumnName("job_id");

                    b.Property<int?>("SeekerId")
                        .HasColumnType("int")
                        .HasColumnName("seeker_id");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("SeekerId");

                    b.ToTable("tbl_jobs_applied");
                });

            modelBuilder.Entity("WebApi.Models.TblSeeker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long?>("ContactNo")
                        .HasColumnType("bigint")
                        .HasColumnName("contact_no");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<int?>("JobApplied")
                        .HasColumnType("int")
                        .HasColumnName("job_applied");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Quaification")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("quaification");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_seeker");
                });

            modelBuilder.Entity("WebApi.Models.TblSeekerExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("date")
                        .HasColumnName("completion_date");

                    b.Property<string>("DegereName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("degere_name");

                    b.Property<string>("InstituteName")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("institute_name");

                    b.Property<double?>("Percentage")
                        .HasColumnType("float")
                        .HasColumnName("percentage");

                    b.Property<int?>("SeekerId")
                        .HasColumnType("int")
                        .HasColumnName("seeker_id");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("date")
                        .HasColumnName("starting_date");

                    b.HasKey("Id");

                    b.HasIndex("SeekerId");

                    b.ToTable("TblSeekerExperience");
                });

            modelBuilder.Entity("WebApi.Models.TblSeekerSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("SeekerId")
                        .HasColumnType("int")
                        .HasColumnName("seeker_id");

                    b.Property<string>("SkillLevel")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("skill_level");

                    b.Property<int?>("SkillsetId")
                        .HasColumnType("int")
                        .HasColumnName("skillset_Id");

                    b.HasKey("Id");

                    b.HasIndex("SeekerId");

                    b.HasIndex("SkillsetId");

                    b.ToTable("tbl_seeker_skills");
                });

            modelBuilder.Entity("WebApi.Models.TblSkillset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SkillsetName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("skillset_name");

                    b.HasKey("Id");

                    b.ToTable("tbl_skillset");
                });

            modelBuilder.Entity("WebApi.Models.TblUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Type")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("type");

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UQ__tbl_user__AB6E6164926B844C")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("WebApi.Models.TblCompany", b =>
                {
                    b.HasOne("WebApi.Models.TblUser", "User")
                        .WithMany("TblCompanies")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApi.Models.TblExperience", b =>
                {
                    b.HasOne("WebApi.Models.TblSeeker", "Seeker")
                        .WithMany("TblExperiences")
                        .HasForeignKey("SeekerId");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("WebApi.Models.TblJob", b =>
                {
                    b.HasOne("WebApi.Models.TblCompany", "Company")
                        .WithMany("TblJobs")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApi.Models.TblJobsApplied", b =>
                {
                    b.HasOne("WebApi.Models.TblJob", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");

                    b.HasOne("WebApi.Models.TblSeeker", "Seeker")
                        .WithMany()
                        .HasForeignKey("SeekerId");

                    b.Navigation("Job");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("WebApi.Models.TblSeeker", b =>
                {
                    b.HasOne("WebApi.Models.TblUser", "User")
                        .WithMany("TblSeekers")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApi.Models.TblSeekerExperience", b =>
                {
                    b.HasOne("WebApi.Models.TblSeeker", "Seeker")
                        .WithMany()
                        .HasForeignKey("SeekerId");

                    b.Navigation("Seeker");
                });

            modelBuilder.Entity("WebApi.Models.TblSeekerSkill", b =>
                {
                    b.HasOne("WebApi.Models.TblSeeker", "Seeker")
                        .WithMany("TblSeekerSkills")
                        .HasForeignKey("SeekerId");

                    b.HasOne("WebApi.Models.TblSkillset", "Skillset")
                        .WithMany("TblSeekerSkills")
                        .HasForeignKey("SkillsetId");

                    b.Navigation("Seeker");

                    b.Navigation("Skillset");
                });

            modelBuilder.Entity("WebApi.Models.TblCompany", b =>
                {
                    b.Navigation("TblJobs");
                });

            modelBuilder.Entity("WebApi.Models.TblSeeker", b =>
                {
                    b.Navigation("TblExperiences");

                    b.Navigation("TblSeekerSkills");
                });

            modelBuilder.Entity("WebApi.Models.TblSkillset", b =>
                {
                    b.Navigation("TblSeekerSkills");
                });

            modelBuilder.Entity("WebApi.Models.TblUser", b =>
                {
                    b.Navigation("TblCompanies");

                    b.Navigation("TblSeekers");
                });
#pragma warning restore 612, 618
        }
    }
}
