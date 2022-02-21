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
  public class SeekerController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public SeekerController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/Seeker
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSeeker>>> GetTblSeekers()
    {
      return await _context.TblSeekers.ToListAsync();
    }

    // GET: api/Seeker/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblSeeker>> GetTblSeeker(int id)
    {
      var tblSeeker = await _context.TblSeekers.FindAsync(id);

      if (tblSeeker == null)
      {
        return NotFound();
      }

      return tblSeeker;
    }

    // PUT: api/Seeker/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblSeeker(int id, TblSeeker tblSeeker)
    {
      if (id != tblSeeker.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblSeeker).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblSeekerExists(id))
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

    // POST: api/Seeker
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblSeeker>> PostTblSeeker(TblSeeker tblSeeker)
    {
      _context.TblSeekers.Add(tblSeeker);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblSeeker", new { id = tblSeeker.Id }, tblSeeker);
    }

    // DELETE: api/Seeker/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblSeeker(int id)
    {
      var tblSeeker = await _context.TblSeekers.FindAsync(id);
      if (tblSeeker == null)
      {
        return NotFound();
      }

      _context.TblSeekers.Remove(tblSeeker);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblSeekerExists(int id)
    {
      return _context.TblSeekers.Any(e => e.Id == id);
    }
  }
}
