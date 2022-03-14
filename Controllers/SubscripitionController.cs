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
  public class SubscripitionController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public SubscripitionController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/Subscripition
    /// <summary>Getting all email classified users</summary>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSubscripition>>> GetTblSubscripitions()
    {
      return await _context.TblSubscripitions.ToListAsync();
    }

    // GET: api/Subscripition/5
    /// <summary>Fetching particular email notification user</summary>

    [HttpGet("{id}")]
    public async Task<ActionResult<TblSubscripition>> GetTblSubscripition(int id)
    {
      var tblSubscripition = await _context.TblSubscripitions.FindAsync(id);

      if (tblSubscripition == null)
      {
        return NotFound();
      }

      return tblSubscripition;
    }

    // PUT: api/Subscripition/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>updating particular email notification user</summary>

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblSubscripition(int id, TblSubscripition tblSubscripition)
    {
      if (id != tblSubscripition.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblSubscripition).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblSubscripitionExists(id))
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

    // POST: api/Subscripition
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>Adding new email notification user</summary>

    [HttpPost]
    public async Task<ActionResult<TblSubscripition>> PostTblSubscripition(TblSubscripition tblSubscripition)
    {
      _context.TblSubscripitions.Add(tblSubscripition);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblSubscripition", new { id = tblSubscripition.Id }, tblSubscripition);
    }

    // DELETE: api/Subscripition/5
    /// <summary>Removing particular email notification user</summary>

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblSubscripition(int id)
    {
      var tblSubscripition = await _context.TblSubscripitions.FindAsync(id);
      if (tblSubscripition == null)
      {
        return NotFound();
      }

      _context.TblSubscripitions.Remove(tblSubscripition);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblSubscripitionExists(int id)
    {
      return _context.TblSubscripitions.Any(e => e.Id == id);
    }
  }
}
