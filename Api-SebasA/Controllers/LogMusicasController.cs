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
    public class LogMusicasController : ControllerBase
    {
        private readonly BD_PROY_P6Context _context;

        public LogMusicasController(BD_PROY_P6Context context)
        {
            _context = context;
        }

        // GET: api/LogMusicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogMusica>>> GetLogMusicas()
        {
          if (_context.LogMusicas == null)
          {
              return NotFound();
          }
            return await _context.LogMusicas.ToListAsync();
        }

        // GET: api/LogMusicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogMusica>> GetLogMusica(int id)
        {
          if (_context.LogMusicas == null)
          {
              return NotFound();
          }
            var logMusica = await _context.LogMusicas.FindAsync(id);

            if (logMusica == null)
            {
                return NotFound();
            }

            return logMusica;
        }

        // GET: api/LogMusicas/5
        [HttpGet("GetLogMusicaListByUser")]
        public async Task<ActionResult<IEnumerable<LogMusica>>> GetLogMusicaListByID(int pUserID)
        {
            var logList = await _context.LogMusicas.Where(u => u.IdusFk == pUserID).ToListAsync();

            if (logList == null)
            {
                return NotFound();
            }

            return logList;
        }

        // PUT: api/LogMusicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogMusica(int id, LogMusica logMusica)
        {
            if (id != logMusica.Idlog)
            {
                return BadRequest();
            }

            _context.Entry(logMusica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogMusicaExists(id))
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

        // POST: api/LogMusicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogMusica>> PostLogMusica(LogMusica logMusica)
        {
          if (_context.LogMusicas == null)
          {
              return Problem("Entity set 'BD_PROY_P6Context.LogMusicas'  is null.");
          }
            _context.LogMusicas.Add(logMusica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogMusica", new { id = logMusica.Idlog }, logMusica);
        }

        // DELETE: api/LogMusicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogMusica(int id)
        {
            if (_context.LogMusicas == null)
            {
                return NotFound();
            }
            var logMusica = await _context.LogMusicas.FindAsync(id);
            if (logMusica == null)
            {
                return NotFound();
            }

            _context.LogMusicas.Remove(logMusica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogMusicaExists(int id)
        {
            return (_context.LogMusicas?.Any(e => e.Idlog == id)).GetValueOrDefault();
        }
    }
}
