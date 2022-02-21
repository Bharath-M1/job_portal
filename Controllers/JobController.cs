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
  public class JobController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public JobController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/Job
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblJob>>> GetTblJobs()
    {
      return await _context.TblJobs.ToListAsync();
    }

    // GET: api/Job/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblJob>> GetTblJob(int id)
    {
      var tblJob = await _context.TblJobs.FindAsync(id);

      if (tblJob == null)
      {
        return NotFound();
      }

      return tblJob;
    }

    // PUT: api/Job/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblJob(int id, TblJob tblJob)
    {
      if (id != tblJob.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblJob).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblJobExists(id))
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

    // POST: api/Job
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblJob>> PostTblJob(TblJob tblJob)
    {
      _context.TblJobs.Add(tblJob);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblJob", new { id = tblJob.Id }, tblJob);
    }

    // DELETE: api/Job/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblJob(int id)
    {
      var tblJob = await _context.TblJobs.FindAsync(id);
      if (tblJob == null)
      {
        return NotFound();
      }

      _context.TblJobs.Remove(tblJob);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblJobExists(int id)
    {
      return _context.TblJobs.Any(e => e.Id == id);
    }
  }
}
