using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeekerController : ControllerBase
  {
    private readonly jobPortalDbContext _context;
    private readonly IAzureStorage _azurestorage;
    public SeekerController(jobPortalDbContext context, IAzureStorage azureStorage)
    {
      _azurestorage = azureStorage;
      _context = context;
    }

    // GET: api/Seeker
    /// <summary>Get all seekers</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblSeeker>>> GetTblSeekers()
    {
      return await _context.TblSeekers.ToListAsync();
    }

    // GET: api/Seeker/5
    /// <summary>Get seeker by id</summary>
    /// <param name="id">description</param>
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
    /// <summary>post seeker details</summary>
    [HttpPost]
    public async Task<IActionResult> PostTblSeeker(TblSeeker tblSeeker)
    {

      TblUser formuser = _context.TblUsers.Single(data => data.Id == tblSeeker.UserId);
      if (formuser.Type == "seeker")
      {
        _context.TblSeekers.Add(tblSeeker);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTblSeeker", new { id = tblSeeker.Id }, tblSeeker);
      }
      return BadRequest(new { message = "Selecte user is not a seeker." });
    }


    // POST: api/Seeker
    /// <summary>service to post data on azure storage</summary>
    [HttpPost("postfiles"), DisableRequestSizeLimit]
    public async Task<IActionResult> Postfiles()
    {
      try
      {
        var formCollection = await Request.ReadFormAsync();
        var file = formCollection.Files.First();
        if (file.Length > 0)
        {
          var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
          string fileURL = await _azurestorage.UploadAsync(file.OpenReadStream(), fileName, file.ContentType);
          return Ok(new { fileURL });
        }
        else
        {
          return BadRequest();
        }
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"Internal server error: {ex}");
      }
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
