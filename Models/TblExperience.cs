using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_experience")]
  public partial class TblExperience
  {
    [Key]
    public int Id { get; set; }
    [Column("job_title")]
    [StringLength(255)]
    [Unicode(false)]
    public string JobTitle { get; set; } = null!;
    [Column("company_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string CompanyName { get; set; } = null!;
    [Column("start_date", TypeName = "date")]
    public DateTime StartDate { get; set; }
    [Column("ending_date", TypeName = "date")]
    public DateTime? EndingDate { get; set; }
    [Column("is_current")]
    [StringLength(1)]
    [Unicode(false)]
    public string? IsCurrent { get; set; }
    [Column("description")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Description { get; set; }
    [Column("seeker_id")]
    public int? SeekerId { get; set; }

    [ForeignKey(nameof(SeekerId))]
    [InverseProperty(nameof(TblSeeker.TblExperiences))]
    public virtual TblSeeker? Seeker { get; set; }
  }
}
