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
    /// <summary>Get seeker by id</summary>>
    /// <param name="id">description</param>>
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
    /// <summary>
    /// post seeker details
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<TblSeeker>> PostTblSeeker(TblSeeker tblSeeker)
    {
      TblUser formuser = _context.TblUsers.Single(data => data.Id == tblSeeker.UserId);
      // Console.WriteLine($"\n\n{formuser.Email}\n\n");
      // Console.WriteLine($"\n\n{formuser}\n\n");
      if (formuser.Type == "seeker")
      {
        _context.TblSeekers.Add(tblSeeker);
        await _context.SaveChangesAsync();
        // return StatusCode(StatusCodes.Status201Created);
        return CreatedAtAction("GetTblSeeker", new { id = tblSeeker.Id }, tblSeeker);
      }
      return StatusCode(StatusCodes.Status422UnprocessableEntity);

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
