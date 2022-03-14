using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_jobs_applied")]
  public partial class TblJobsApplied
  {
    [Key]
    public int Id { get; set; }
    [Column("job_id")]
    public int? JobId { get; set; }
    [Column("seeker_id")]
    public int? SeekerId { get; set; }
    [Column("applied_on", TypeName = "datetime")]
    public DateTime? AppliedOn { get; set; }
    [ForeignKey(nameof(JobId))]
    public virtual TblJob? Job { get; set; }
    [ForeignKey(nameof(SeekerId))]
    // [InverseProperty(nameof(TblSeeker.Id))]
    public virtual TblSeeker? Seeker { get; set; }
  }
}
