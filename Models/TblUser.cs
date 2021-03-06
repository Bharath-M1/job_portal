using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_user")]
  [Index(nameof(Email), Name = "UQ__tbl_user__AB6E6164926B844C", IsUnique = true)]
  public partial class TblUser
  {
    public TblUser()
    {
      TblCompanies = new HashSet<TblCompany>();
      TblSeekers = new HashSet<TblSeeker>();
    }

    [Key]
    public int Id { get; set; }
    [Column("username")]
    [StringLength(255)]
    [Unicode(false)]
    public string Username { get; set; } = null!;
    [Column("email")]
    [StringLength(255)]
    [Unicode(false)]
    [EmailAddress(ErrorMessage = "Not a valid email")]
    public string Email { get; set; } = null!;
    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;
    [Column("type")]
    [StringLength(25)]
    [Unicode(false)]
    [RegularExpression(@"company|seeker|admin", ErrorMessage = "Select between options")]
    [Required]
    public string Type { get; set; } = null!;
    [JsonIgnore]
    [InverseProperty(nameof(TblCompany.User))]
    public virtual ICollection<TblCompany> TblCompanies { get; set; }
    [JsonIgnore]
    [InverseProperty(nameof(TblSeeker.User))]
    public virtual ICollection<TblSeeker> TblSeekers { get; set; }
  }
}
