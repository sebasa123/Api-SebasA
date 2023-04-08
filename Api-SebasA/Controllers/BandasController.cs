using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_SebasA.Models;

namespace Api_SebasA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandasController : ControllerBase
    {
        private readonly BD_PROY_P6Context _context;

        public BandasController(BD_PROY_P6Context context)
        {
            _context = context;
        }

        // GET: api/Bandas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banda>>> GetBanda()
        {
          if (_context.Banda == null)
          {
              return NotFound();
          }
            return await _context.Banda.ToListAsync();
        }

        // GET: api/Bandas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banda>> GetBanda(int id)
        {
          if (_context.Banda == null)
          {
              return NotFound();
          }
            var banda = await _context.Banda.FindAsync(id);

            if (banda == null)
            {
                return NotFound();
            }

            return banda;
        }

        // PUT: api/Bandas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanda(int id, Banda banda)
        {
            if (id != banda.Idban)
            {
                return BadRequest();
            }

            _context.Entry(banda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandaExists(id))
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

        // POST: api/Bandas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banda>> PostBanda(Banda banda)
        {
          if (_context.Banda == null)
          {
              return Problem("Entity set 'BD_PROY_P6Context.Banda'  is null.");
          }
            _context.Banda.Add(banda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanda", new { id = banda.Idban }, banda);
        }

        // DELETE: api/Bandas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanda(int id)
        {
            if (_context.Banda == null)
            {
                return NotFound();
            }
            var banda = await _context.Banda.FindAsync(id);
            if (banda == null)
            {
                return NotFound();
            }

            _context.Banda.Remove(banda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BandaExists(int id)
        {
            return (_context.Banda?.Any(e => e.Idban == id)).GetValueOrDefault();
        }
    }
}
