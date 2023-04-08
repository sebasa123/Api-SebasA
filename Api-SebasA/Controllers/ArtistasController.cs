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
    public class ArtistasController : ControllerBase
    {
        private readonly BD_PROY_P6Context _context;

        public ArtistasController(BD_PROY_P6Context context)
        {
            _context = context;
        }

        // GET: api/Artistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtista()
        {
          if (_context.Artista == null)
          {
              return NotFound();
          }
            return await _context.Artista.ToListAsync();
        }

        // GET: api/Artistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
          if (_context.Artista == null)
          {
              return NotFound();
          }
            var artista = await _context.Artista.FindAsync(id);

            if (artista == null)
            {
                return NotFound();
            }

            return artista;
        }

        // PUT: api/Artistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtista(int id, Artista artista)
        {
            if (id != artista.Idart)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExists(id))
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

        // POST: api/Artistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
          if (_context.Artista == null)
          {
              return Problem("Entity set 'BD_PROY_P6Context.Artista'  is null.");
          }
            _context.Artista.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtista", new { id = artista.Idart }, artista);
        }

        // DELETE: api/Artistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtista(int id)
        {
            if (_context.Artista == null)
            {
                return NotFound();
            }
            var artista = await _context.Artista.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artista.Remove(artista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistaExists(int id)
        {
            return (_context.Artista?.Any(e => e.Idart == id)).GetValueOrDefault();
        }
    }
}
