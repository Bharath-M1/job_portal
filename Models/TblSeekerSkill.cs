using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_seeker_skills")]
  public partial class TblSeekerSkill
  {
    [Key]
    public int Id { get; set; }
    [Column("seeker_id")]
    public int? SeekerId { get; set; }
    [Column("skillset_Id")]
    public int? SkillsetId { get; set; }
    [Column("skill_level")]
    [StringLength(255)]
    [Unicode(false)]
    public string SkillLevel { get; set; } = null!;
    [JsonIgnore]
    [ForeignKey(nameof(SeekerId))]
    [InverseProperty(nameof(TblSeeker.TblSeekerSkills))]
    public virtual TblSeeker? Seeker { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(SkillsetId))]
    [InverseProperty(nameof(TblSkillset.TblSeekerSkills))]
    public virtual TblSkillset? Skillset { get; set; }
  }
}
