using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_skillset")]
  public partial class TblSkillset
  {
    public TblSkillset()
    {
      TblSeekerSkills = new HashSet<TblSeekerSkill>();
    }

    [Key]
    public int Id { get; set; }
    [Column("skillset_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SkillsetName { get; set; }
    [JsonIgnore]
    [InverseProperty(nameof(TblSeekerSkill.Skillset))]
    public virtual ICollection<TblSeekerSkill> TblSeekerSkills { get; set; }
  }
}
