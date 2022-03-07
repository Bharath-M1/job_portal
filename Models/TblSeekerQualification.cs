using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_seeker_qualification")]
  public partial class TblSeekerQualification
  {

    [Key]
    public int Id { get; set; }
    [Column("starting_date", TypeName = "date")]
    public DateTime StartingDate { get; set; }
    [Column("completion_date", TypeName = "date")]
    public DateTime? CompletionDate { get; set; }
    [Column("percentage")]
    public double? Percentage { get; set; }
    [Column("institute_name")]
    [StringLength(500)]
    [Unicode(false)]
    public string InstituteName { get; set; } = null!;
    [Column("degere_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string DegereName { get; set; } = null!;
    [Column("seeker_id")]
    public int? SeekerId { get; set; }

    [ForeignKey(nameof(SeekerId))]
    public virtual TblSeeker? Seeker { get; set; }
  }
}
