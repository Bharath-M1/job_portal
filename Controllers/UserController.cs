using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using BC = BCrypt.Net.BCrypt;
using WebApi.Services;
using WebApi.Helpers;

namespace WebApi.Cotrollers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly jobPortalDbContext _context;
    private IUserService _userService;
    private readonly IMailService _mailService;
    public UserController(jobPortalDbContext context, IUserService userService, IMailService mailService)
    {
      _userService = userService;
      _context = context;
      _mailService = mailService;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblUser>>> GetTblUsers()
    {
      return await _context.TblUsers.ToListAsync();
    }


    [Authorize]
    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TblUser>> GetTblUser(int id)
    {
      var tblUser = await _context.TblUsers.FindAsync(id);

      if (tblUser == null)
      {
        return NotFound();
      }

      return tblUser;
    }


    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblUser(int id, TblUser tblUser)
    {
      if (id != tblUser.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblUser).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblUserExists(id))
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


    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TblUser>> PostTblUser(TblUser tblUser)
    {
      try
      {
        var usrmail = new MailRequest();
        usrmail.ToEmail = tblUser.Email;
        usrmail.Subject = "job access created";
        usrmail.Body = "some checking message";
        await _mailService.SendEmailAsync(usrmail);
        tblUser.Password = BC.HashPassword(tblUser.Password);
        _context.TblUsers.Add(tblUser);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTblUser", new { id = tblUser.Id }, tblUser);
      }
      catch (Exception ex)
      {
        throw;
      }


    }


    [HttpPost("authenticate")]
    public IActionResult Authenticate(Login model)
    {
      var response = _userService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }


    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblUser(int id)
    {
      var tblUser = await _context.TblUsers.FindAsync(id);
      if (tblUser == null)
      {
        return NotFound();
      }

      _context.TblUsers.Remove(tblUser);
      await _context.SaveChangesAsync();

      return NoContent();
    }


    private bool TblUserExists(int id)
    {
      return _context.TblUsers.Any(e => e.Id == id);
    }
  }
}
