using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeekerSkillController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public SeekerSkillController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/SeekerSkill
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSeekerSkill>>> GetTblSeekerSkills()
    {
      return await _context.TblSeekerSkills.ToListAsync();
    }

    // GET: api/SeekerSkill/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblSeekerSkill>> GetTblSeekerSkill(int id)
    {
      var tblSeekerSkill = await _context.TblSeekerSkills.FindAsync(id);

      if (tblSeekerSkill == null)
      {
        return NotFound();
      }

      return tblSeekerSkill;
    }

    // PUT: api/SeekerSkill/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblSeekerSkill(int id, TblSeekerSkill tblSeekerSkill)
    {
      if (id != tblSeekerSkill.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblSeekerSkill).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblSeekerSkillExists(id))
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

    // POST: api/SeekerSkill
    [HttpPost]
    public async Task<ActionResult<TblSeekerSkill>> PostTblSeekerSkill(TblSeekerSkill tblSeekerSkill)
    {
      _context.TblSeekerSkills.Add(tblSeekerSkill);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTblSeekerSkill", new { id = tblSeekerSkill.Id }, tblSeekerSkill);
    }

    // DELETE: api/SeekerSkill/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblSeekerSkill(int id)
    {
      var tblSeekerSkill = await _context.TblSeekerSkills.FindAsync(id);
      if (tblSeekerSkill == null)
      {
        return NotFound();
      }

      _context.TblSeekerSkills.Remove(tblSeekerSkill);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool TblSeekerSkillExists(int id)
    {
      return _context.TblSeekerSkills.Any(e => e.Id == id);
    }
  }
}
