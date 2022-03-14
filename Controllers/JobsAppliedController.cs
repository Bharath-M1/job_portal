using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JobsAppliedController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public JobsAppliedController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/JobsApplied
    /// <summary>Lisitng all jobs applications</summary>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblJobsApplied>>> GetTblJobsApplieds()
    {
      return await _context.TblJobsApplieds.ToListAsync();
    }

    // GET: api/JobsApplied/5
    /// <summary>Fetching particular job applicants</summary>

    [HttpGet("{id}")]
    public async Task<ActionResult<TblJobsApplied>> GetTblJobsApplied(int id)
    {
      var tblJobsApplied = await _context.TblJobsApplieds.FindAsync(id);

      if (tblJobsApplied == null)
      {
        return NotFound();
      }

      return tblJobsApplied;
    }



    // GET: api/JobsApplied/5
    /// <summary>Fetching particular job applicants</summary>

    [HttpGet("jobpostapplicant/{id}")]
    public async Task<ActionResult<IEnumerable<TblJobsApplied>>> GetJobApplied(int id)
    {
      var tblJobsApplied = await _context.TblJobsApplieds.Where(data => data.JobId == id).Include(d => d.Seeker).ToListAsync();

      if (tblJobsApplied == null)
      {
        return NotFound();
      }

      return tblJobsApplied;
    }

    // PUT: api/JobsApplied/5
    /// <summary>updating particular job application</summary>

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblJobsApplied(int id, TblJobsApplied tblJobsApplied)
    {
      if (id != tblJobsApplied.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblJobsApplied).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblJobsAppliedExists(id))
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

    // POST: api/JobsApplied
    /// <summary>Applying for new job using seeker id</summary>

    [HttpPost]
    public async Task<ActionResult<TblJobsApplied>> PostTblJobsApplied(TblJobsApplied tblJobsApplied)
    {
      DateTime now = DateTime.Now;
      tblJobsApplied.AppliedOn = now;
      _context.TblJobsApplieds.Add(tblJobsApplied);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblJobsApplied", new { id = tblJobsApplied.Id }, tblJobsApplied);
    }

    // DELETE: api/JobsApplied/5
    /// <summary>Deleting a particular job application</summary>

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblJobsApplied(int id)
    {
      var tblJobsApplied = await _context.TblJobsApplieds.FindAsync(id);
      if (tblJobsApplied == null)
      {
        return NotFound();
      }

      _context.TblJobsApplieds.Remove(tblJobsApplied);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblJobsAppliedExists(int id)
    {
      return _context.TblJobsApplieds.Any(e => e.Id == id);
    }
  }
}
