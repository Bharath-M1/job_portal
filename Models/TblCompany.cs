using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_company")]
  public partial class TblCompany
  {
    public TblCompany()
    {
      TblJobs = new HashSet<TblJob>();
    }
    [Key]
    public int Id { get; set; }
    [Column("company_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string CompanyName { get; set; } = null!;
    [Column("user_id")]
    public int? UserId { get; set; }
    [Column("address")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }
    [Column("contact_no")]
    public long? ContactNo { get; set; }
    [Column("job_posted")]
    public int? JobPosted { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(TblUser.TblCompanies))]
    [JsonIgnore]
    public virtual TblUser? User { get; set; }
    [InverseProperty(nameof(TblJob.Company))]
    [JsonIgnore]
    public virtual ICollection<TblJob> TblJobs { get; set; }
  }
}
