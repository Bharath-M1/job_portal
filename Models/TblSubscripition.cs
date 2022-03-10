using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
  [Table("tbl_subscripition")]
  public partial class TblSubscripition
  {
    [Key]
    public int Id { get; set; }
    [Column("userId")]
    public int? UserId { get; set; }
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual TblUser User { get; set; }
  }
}
