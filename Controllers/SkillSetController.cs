using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SkillSetController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public SkillSetController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/SkillSet
    /// <summary>Fetching all  skillset</summary>

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSkillset>>> GetTblSkillsets()
    {
      return await _context.TblSkillsets.ToListAsync();
    }

    // GET: api/SkillSet/5
    /// <summary>Fetching particular  skillset</summary>

    [HttpGet("{id}")]
    public async Task<ActionResult<TblSkillset>> GetTblSkillset(int id)
    {
      var tblSkillset = await _context.TblSkillsets.FindAsync(id);

      if (tblSkillset == null)
      {
        return NotFound();
      }

      return tblSkillset;
    }

    // PUT: api/SkillSet/5
    /// <summary>Updating particular  skillset</summary>

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblSkillset(int id, TblSkillset tblSkillset)
    {
      if (id != tblSkillset.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblSkillset).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblSkillsetExists(id))
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

    // POST: api/SkillSet
    /// <summary>Adding new skillset</summary>

    [HttpPost]
    public async Task<ActionResult<TblSkillset>> PostTblSkillset(TblSkillset tblSkillset)
    {
      _context.TblSkillsets.Add(tblSkillset);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblSkillset", new { id = tblSkillset.Id }, tblSkillset);
    }

    // DELETE: api/SkillSet/5
    /// <summary>Removing particular skillset</summary>

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblSkillset(int id)
    {
      var tblSkillset = await _context.TblSkillsets.FindAsync(id);
      if (tblSkillset == null)
      {
        return NotFound();
      }

      _context.TblSkillsets.Remove(tblSkillset);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblSkillsetExists(int id)
    {
      return _context.TblSkillsets.Any(e => e.Id == id);
    }
  }
}
