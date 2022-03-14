using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using BC = BCrypt.Net.BCrypt;
using WebApi.Services;
using WebApi.Helpers;

namespace WebApi.Controllers
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
    /// <summary>Get all registered users</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblUser>>> GetTblUsers()
    {
      return await _context.TblUsers.ToListAsync();
    }


    // GET: api/User/5
    /// <summary>Get particular registered user using user id</summary>
    [Authorize]
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
    /// <summary>Updating particular user data in user table</summary>
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
    /// <summary>Adding new user to jobs360</summary>\
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> PostTblUser(TblUser tblUser)
    {
      if (!_context.TblUsers.Any(options => options.Email == tblUser.Email))
      {
        try
        {
          var mail = new MailRequest();
          mail.ToEmail = tblUser.Email;
          mail.Subject = "job access created";
          mail.Body = "some checking message";
          await _mailService.SendEmailAsync(mail);
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
      else
      {
        return BadRequest(new { Message = "user already exist" });
      }
    }


    //login controller method
    /// <summary>Login method it generates jwt token</summary>
    [HttpPost("authenticate")]
    public IActionResult Authenticate(Login userData)
    {
      var response = _userService.Authenticate(userData);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }


    // DELETE: api/User/5
    /// <summary>Delete particular user from jobs360</summary>
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
