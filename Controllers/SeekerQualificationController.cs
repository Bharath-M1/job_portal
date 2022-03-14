using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeekerQualificationController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public SeekerQualificationController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/SeekerQualification
    /// <summary>listing all seekers qualifications</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSeekerQualification>>> GetTblSeekerQualification()
    {
      return await _context.TblSeekerQualifications.ToListAsync();
    }

    // GET: api/SeekerQualification/5
    /// <summary>Getting single users qualification</summary>

    [HttpGet("{id}")]
    public async Task<ActionResult<TblSeekerQualification>> GetTblSeekerQualification(int id)
    {
      var tblSeekerQualification = await _context.TblSeekerQualifications.FindAsync(id);

      if (tblSeekerQualification == null)
      {
        return NotFound();
      }

      return tblSeekerQualification;
    }

    // PUT: api/SeekerQualification/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>Editing users qualification</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblSeekerQualification(int id, TblSeekerQualification tblSeekerQualification)
    {
      if (id != tblSeekerQualification.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblSeekerQualification).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblSeekerQualificationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/SeekerQualification
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>Inserting new qualification to user</summary>

    [HttpPost]
    public async Task<ActionResult<TblSeekerQualification>> PostTblSeekerQualification(TblSeekerQualification tblSeekerQualification)
    {
      _context.TblSeekerQualifications.Add(tblSeekerQualification);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblSeekerQualification", new { id = tblSeekerQualification.Id }, tblSeekerQualification);
    }

    // DELETE: api/SeekerQualification/5
    /// <summary>Removing users qualification</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblSeekerQualification(int id)
    {
      var tblSeekerQualification = await _context.TblSeekerQualifications.FindAsync(id);
      if (tblSeekerQualification == null)
      {
        return NotFound();
      }

      _context.TblSeekerQualifications.Remove(tblSeekerQualification);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblSeekerQualificationExists(int id)
    {
      return _context.TblSeekerQualifications.Any(e => e.Id == id);
    }
  }
}
