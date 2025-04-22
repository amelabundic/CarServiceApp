using AutoCentarBundic.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
//using AutoCentarBundic.Data;
//using AutoCentarBundic.Models;

namespace AutoCentarBundic.Controllers
{
    [Route("api/termin")]
    [ApiController]
    public class TerminController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TerminController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/termin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Termin>>> GetTermini()
        {
            return await _dbContext.Termini.ToListAsync();
        }

        // POST: api/termin
        [HttpPost]
        public async Task<ActionResult> PostTermin(Termin noviTermin)
        {
            _dbContext.Termini.Add(noviTermin);
            await _dbContext.SaveChangesAsync();

            return Ok(noviTermin); // frontend očekuje običan 200 OK s JSON tijelom
        }

        // DELETE: api/termin/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> ObrisiTermin(int id)
        {
            var termin = await _dbContext.Termini.FindAsync(id);
            if (termin == null)
            {
                return NotFound();
            }

            _dbContext.Termini.Remove(termin);
            await _dbContext.SaveChangesAsync();

            return Ok(); // frontend koristi DeleteAsync, očekuje 200 ili 204
        }

        // PUT: api/termin/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTermin(int id, Termin azuriraniTermin)
        {
            if (id != azuriraniTermin.Id)
            {
                return BadRequest();
            }

            var termin = await _dbContext.Termini.FindAsync(id);
            if (termin == null)
            {
                return NotFound();
            }

            termin.Ime = azuriraniTermin.Ime;
            termin.Prezime = azuriraniTermin.Prezime;
            termin.Datum = azuriraniTermin.Datum;
            termin.Automobil = azuriraniTermin.Automobil;
            termin.Problem = azuriraniTermin.Problem;

            await _dbContext.SaveChangesAsync();
            return Ok(); // frontend očekuje status 200 OK, ne koristi CreatedAtAction
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Termin>> GetTerminById(int id)
        {
            var termin = await _dbContext.Termini.FindAsync(id);

            if (termin == null)
            {
                return NotFound();
            }

            return Ok(termin);
        }
        // PUT: api/termin/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTermin(int id, Termin termin)
        //{
        //    if (id != termin.Id)
        //        return BadRequest("ID ne odgovara");

        //    var existing = await _dbContext.Termini.FindAsync(id);
        //    if (existing == null)
        //        return NotFound();

        //    existing.Ime = termin.Ime;
        //    existing.Prezime = termin.Prezime;
        //    existing.Automobil = termin.Automobil;
        //    existing.Problem = termin.Problem;
        //    existing.Datum = termin.Datum;

        //    await _dbContext.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
