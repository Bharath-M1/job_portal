using System;
using System.Collections.Generic;

namespace WebApi.Models
{
  public partial class TblSeekerExperience
  {
    public int Id { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public double? Percentage { get; set; }
    public string InstituteName { get; set; } = null!;
    public string DegereName { get; set; } = null!;
    public int? SeekerId { get; set; }

    public virtual TblSeeker? Seeker { get; set; }
  }
}
