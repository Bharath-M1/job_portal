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
  public class ExperienceController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public ExperienceController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/Experience
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblExperience>>> GetTblExperiences()
    {
      return await _context.TblExperiences.ToListAsync();
    }

    // GET: api/Experience/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblExperience>> GetTblExperience(int id)
    {
      var tblExperience = await _context.TblExperiences.FindAsync(id);

      if (tblExperience == null)
      {
        return NotFound();
      }

      return tblExperience;
    }

    // PUT: api/Experience/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblExperience(int id, TblExperience tblExperience)
    {
      if (id != tblExperience.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblExperience).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblExperienceExists(id))
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

    // POST: api/Experience
    [HttpPost]
    public async Task<ActionResult<TblExperience>> PostTblExperience(TblExperience tblExperience)
    {
      _context.TblExperiences.Add(tblExperience);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblExperience", new { id = tblExperience.Id }, tblExperience);
    }

    // DELETE: api/Experience/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblExperience(int id)
    {
      var tblExperience = await _context.TblExperiences.FindAsync(id);
      if (tblExperience == null)
      {
        return NotFound();
      }

      _context.TblExperiences.Remove(tblExperience);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblExperienceExists(int id)
    {
      return _context.TblExperiences.Any(e => e.Id == id);
    }
  }
}
