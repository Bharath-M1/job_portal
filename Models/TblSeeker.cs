using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_seeker")]
  public partial class TblSeeker
  {
    public TblSeeker()
    {
      TblExperiences = new HashSet<TblExperience>();
      TblSeekerQualifications = new HashSet<TblSeekerQualification>();
      TblSeekerSkills = new HashSet<TblSeekerSkill>();
    }

    [Key]
    public int Id { get; set; }
    [Column("first_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FirstName { get; set; }
    [Column("last_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LastName { get; set; }
    [Column("contact_no")]
    public long? ContactNo { get; set; }
    [Column("user_id")]
    public int? UserId { get; set; }
    [Column("quaification")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Quaification { get; set; }
    [Column("job_applied")]
    public int? JobApplied { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(TblUser.TblSeekers))]
    public virtual TblUser? User { get; set; }
    [InverseProperty(nameof(TblExperience.Seeker))]
    public virtual ICollection<TblExperience> TblExperiences { get; set; }
    [InverseProperty(nameof(TblSeekerQualification.Seeker))]
    public virtual ICollection<TblSeekerQualification> TblSeekerQualifications { get; set; }
    [InverseProperty(nameof(TblSeekerSkill.Seeker))]
    public virtual ICollection<TblSeekerSkill> TblSeekerSkills { get; set; }
  }
}
