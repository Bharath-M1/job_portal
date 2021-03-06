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
  public class CompanyController : ControllerBase
  {
    private readonly jobPortalDbContext _context;

    public CompanyController(jobPortalDbContext context)
    {
      _context = context;
    }

    // GET: api/Company
    /// <summary>Get all company details used in admin</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TblCompany>>> GetTblCompanies()
    {
      return await _context.TblCompanies.ToListAsync();
    }


    /// <summary>Get particular company detail</summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<TblCompany>> GetTblCompany(int id)
    {
      var tblCompany = await _context.TblCompanies.FindAsync(id);

      if (tblCompany == null)
      {
        return NotFound();
      }

      return tblCompany;
    }

    // getting company data using user id
    /// <summary>retieveing company data using userid</summary>
    [HttpGet("retrievecompanydata/{id}")]
    public async Task<ActionResult<TblCompany>> GetCompnayData(int id)
    {
      var tblCompany = _context.TblCompanies.Single(data => data.UserId == id);

      if (tblCompany == null)
      {
        return NotFound();
      }

      return tblCompany;
    }

    // PUT: api/Company/5
    /// <summary>Editing the particular company data</summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTblCompany(int id, TblCompany tblCompany)
    {
      if (id != tblCompany.Id)
      {
        return BadRequest();
      }

      _context.Entry(tblCompany).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TblCompanyExists(id))
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

    // POST: api/Company
    /// <summary>Adding new company to jobs 360</summary>
    [HttpPost]
    public async Task<IActionResult> PostTblCompany(TblCompany tblCompany)
    {
      TblUser CurrentCompany = _context.TblUsers.Single(c => c.Id == tblCompany.UserId);
      if (CurrentCompany.Type == "company")
      {
        _context.TblCompanies.Add(tblCompany);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTblCompany", new { id = tblCompany.Id }, tblCompany);
      }
      return BadRequest(new { message = "Selecte user is not a company." });
    }


    // DELETE: api/Company/5
    /// <summary>Deleting a particular company using company id</summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTblCompany(int id)
    {
      var tblCompany = await _context.TblCompanies.FindAsync(id);
      if (tblCompany == null)
      {
        return NotFound();
      }
      _context.TblCompanies.Remove(tblCompany);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    private bool TblCompanyExists(int id)
    {
      return _context.TblCompanies.Any(e => e.Id == id);
    }
  }
}
