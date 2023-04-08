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
    public class TipoUsuariosController : ControllerBase
    {
        private readonly BD_PROY_P6Context _context;

        public TipoUsuariosController(BD_PROY_P6Context context)
        {
            _context = context;
        }

        // GET: api/TipoUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> GetTipoUsuarios()
        {
          if (_context.TipoUsuarios == null)
          {
              return NotFound();
          }
            return await _context.TipoUsuarios.ToListAsync();
        }

        // GET: api/TipoUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> GetTipoUsuario(int id)
        {
          if (_context.TipoUsuarios == null)
          {
              return NotFound();
          }
            var tipoUsuario = await _context.TipoUsuarios.FindAsync(id);

            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return tipoUsuario;
        }

        // PUT: api/TipoUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUsuario(int id, TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.IdtipoUs)
            {
                return BadRequest();
            }

            _context.Entry(tipoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioExists(id))
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

        // POST: api/TipoUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> PostTipoUsuario(TipoUsuario tipoUsuario)
        {
          if (_context.TipoUsuarios == null)
          {
              return Problem("Entity set 'BD_PROY_P6Context.TipoUsuarios'  is null.");
          }
            _context.TipoUsuarios.Add(tipoUsuario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoUsuarioExists(tipoUsuario.IdtipoUs))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoUsuario", new { id = tipoUsuario.IdtipoUs }, tipoUsuario);
        }

        // DELETE: api/TipoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoUsuario(int id)
        {
            if (_context.TipoUsuarios == null)
            {
                return NotFound();
            }
            var tipoUsuario = await _context.TipoUsuarios.FindAsync(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            _context.TipoUsuarios.Remove(tipoUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoUsuarioExists(int id)
        {
            return (_context.TipoUsuarios?.Any(e => e.IdtipoUs == id)).GetValueOrDefault();
        }
    }
}
