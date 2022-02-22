using Microsoft.EntityFrameworkCore;
using WebApi.Models;
namespace WebApi.Data;
#pragma warning disable CS1591

public class jobPortalDbContext : DbContext
{
  public jobPortalDbContext(DbContextOptions options) : base(options)
  {
  }
  public virtual DbSet<TblCompany> TblCompanies { get; set; } = null!;
  public virtual DbSet<TblExperience> TblExperiences { get; set; } = null!;
  public virtual DbSet<TblJob> TblJobs { get; set; } = null!;
  public virtual DbSet<TblJobsApplied> TblJobsApplieds { get; set; } = null!;
  public virtual DbSet<TblSeeker> TblSeekers { get; set; } = null!;
  public virtual DbSet<TblSeekerQualification> TblSeekerQualifications { get; set; } = null!;
  public virtual DbSet<TblSeekerSkill> TblSeekerSkills { get; set; } = null!;
  public virtual DbSet<TblSkillset> TblSkillsets { get; set; } = null!;
  public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
  public DbSet<TblSeekerExperience> TblSeekerExperience { get; set; }
}
#pragma warning disable CS1591
