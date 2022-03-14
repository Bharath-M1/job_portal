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
    /// <summary>Get all jobs detail for job listing page it also have search filters</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblJob>>> GetTblJobs()
    {
      // string skills = HttpContext.Request.Query["skills"].ToString();
      // string[] skillsArray = skills.Split(',');
      // Console.WriteLine($"\n\n{skills.Length},{skillsArray.Length <= 1},{skillsArray[0]},{skillsArray.Length}\n\n");&& skills.Length < 1
      string type = HttpContext.Request.Query["type"].ToString();
      if (!String.IsNullOrEmpty(type))
      {
        return await _context.TblJobs.Where(data => data.Type == type).ToListAsync();
      }
      return await _context.TblJobs.ToListAsync();
    }

    // GET: api/Job/5
    /// <summary>Get particular job detail for job detail page</summary>
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

    //company posted jobs
    /// <summary>Get Total jobs posted by single company using company id</summary>
    [HttpGet("retievetotaljobs/{id}")]
    public async Task<ActionResult<IEnumerable<TblJob>>> GetTotalJobsPosted(int id)
    {
      var tblJob = await _context.TblJobs.Include(data => data.CompanyId).Where(data => data.CompanyId == id).ToListAsync();
      if (tblJob == null)
      {
        return NotFound();
      }

      return tblJob;
    }

    // PUT: api/Job/5
    /// <summary>Edit particular job using the id</summary>
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
    /// <summary>posting a new job by company</summary>
    [HttpPost]
    public async Task<ActionResult<TblJob>> PostTblJob(TblJob tblJob)
    {
      // TblCompany data = _context.TblCompany.Single(x=>x.);
      _context.TblJobs.Add(tblJob);
      await _context.SaveChangesAsync();
      return CreatedAtAction("GetTblJob", new { id = tblJob.Id }, tblJob);
    }

    // DELETE: api/Job/5
    /// <summary>Delete a particular job</summary>

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
