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
    public class CancionesController : ControllerBase
    {
        private readonly BD_PROY_P6Context _context;

        public CancionesController(BD_PROY_P6Context context)
        {
            _context = context;
        }

        // GET: api/Canciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCancions()
        {
          if (_context.Cancions == null)
          {
              return NotFound();
          }
            return await _context.Cancions.ToListAsync();
        }

        // GET: api/Canciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCancion(int id)
        {
          if (_context.Cancions == null)
          {
              return NotFound();
          }
            var cancion = await _context.Cancions.FindAsync(id);

            if (cancion == null)
            {
                return NotFound();
            }

            return cancion;
        }

        // PUT: api/Canciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancion(int id, Cancion cancion)
        {
            if (id != cancion.Idcan)
            {
                return BadRequest();
            }

            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(id))
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

        // POST: api/Canciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion(Cancion cancion)
        {
          if (_context.Cancions == null)
          {
              return Problem("Entity set 'BD_PROY_P6Context.Cancions'  is null.");
          }
            _context.Cancions.Add(cancion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancion", new { id = cancion.Idcan }, cancion);
        }

        // DELETE: api/Canciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancion(int id)
        {
            if (_context.Cancions == null)
            {
                return NotFound();
            }
            var cancion = await _context.Cancions.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Cancions.Remove(cancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CancionExists(int id)
        {
            return (_context.Cancions?.Any(e => e.Idcan == id)).GetValueOrDefault();
        }
    }
}
