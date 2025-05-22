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
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public TerminController(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: api/termin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Termin>>> GetTermini()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Termini.ToListAsync();
        }

        // POST: api/termin
        [HttpPost]
        public async Task<ActionResult> PostTermin(Termin noviTermin)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Termini.Add(noviTermin);
            await context.SaveChangesAsync();
            return Ok(noviTermin);
        }

        // DELETE: api/termin/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> ObrisiTermin(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var termin = await context.Termini.FindAsync(id);
            if (termin == null)
            {
                return NotFound();
            }

            context.Termini.Remove(termin);
            await context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/termin/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTermin(int id, Termin azuriraniTermin)
        {
            using var context = _contextFactory.CreateDbContext();
            if (id != azuriraniTermin.Id)
            {
                return BadRequest();
            }

            var termin = await context.Termini.FindAsync(id);
            if (termin == null)
            {
                return NotFound();
            }

            termin.Ime = azuriraniTermin.Ime;
            termin.Prezime = azuriraniTermin.Prezime;
            termin.Datum = azuriraniTermin.Datum;
            termin.Automobil = azuriraniTermin.Automobil;
            termin.Problem = azuriraniTermin.Problem;

            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Termin>> GetTerminById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var termin = await context.Termini.FindAsync(id);

            if (termin == null)
            {
                return NotFound();
            }

            return Ok(termin);
        }
    }

}
