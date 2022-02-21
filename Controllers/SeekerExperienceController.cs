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
  public class SeekerExperienceController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public SeekerExperienceController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/SeekerExperience
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSeekerExperience>>> GetTblSeekerExperience()
    {
      return await _context.TblSeekerExperience.ToListAsync();
    }

    // GET: api/SeekerExperience/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblSeekerExperience>> GetTblSeekerExperience(int id)
    {
      var tblSeekerExperience = await _context.TblSeekerExperience.FindAsync(id);

      if (tblSeekerExperience == null)
      {
        return NotFound();
      }

      return tblSeekerExperience;
    }

    // PUT: api/SeekerExperience/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblSeekerExperience(int id, TblSeekerExperience tblSeekerExperience)
    {
      if (id != tblSeekerExperience.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblSeekerExperience).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblSeekerExperienceExists(id))
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

    // POST: api/SeekerExperience
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblSeekerExperience>> PostTblSeekerExperience(TblSeekerExperience tblSeekerExperience)
    {
      _context.TblSeekerExperience.Add(tblSeekerExperience);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblSeekerExperience", new { id = tblSeekerExperience.Id }, tblSeekerExperience);
    }

    // DELETE: api/SeekerExperience/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblSeekerExperience(int id)
    {
      var tblSeekerExperience = await _context.TblSeekerExperience.FindAsync(id);
      if (tblSeekerExperience == null)
      {
        return NotFound();
      }

      _context.TblSeekerExperience.Remove(tblSeekerExperience);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblSeekerExperienceExists(int id)
    {
      return _context.TblSeekerExperience.Any(e => e.Id == id);
    }
  }
}
