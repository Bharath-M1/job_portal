using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_jobs")]
  public partial class TblJob
  {
    [Key]
    public int Id { get; set; }
    [Column("company_id")]
    public int? CompanyId { get; set; }
    [Column("title")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Title { get; set; }
    [Column("description")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Description { get; set; }
    [Column("type")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Type { get; set; }
    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
    [Column("location")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Location { get; set; }
    [Column("salary")]
    public int? Salary { get; set; }
    [Column("no_of_vacancy")]
    public int? NoOfVacancy { get; set; }
    [Column("is_active")]
    [StringLength(1)]
    [Unicode(false)]
    public string? IsActive { get; set; }

    [ForeignKey(nameof(CompanyId))]
    [InverseProperty(nameof(TblCompany.TblJobs))]
    public virtual TblCompany? Company { get; set; }
  }
}
