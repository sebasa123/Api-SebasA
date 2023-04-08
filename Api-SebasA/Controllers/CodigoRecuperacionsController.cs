﻿using System;
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
    public class CodigoRecuperacionsController : ControllerBase
    {
        private readonly BD_PROY_P6Context _context;

        public CodigoRecuperacionsController(BD_PROY_P6Context context)
        {
            _context = context;
        }

        // GET: api/CodigoRecuperacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodigoRecuperacion>>> GetCodigoRecuperacions()
        {
          if (_context.CodigoRecuperacions == null)
          {
              return NotFound();
          }
            return await _context.CodigoRecuperacions.ToListAsync();
        }

        // GET: api/CodigoRecuperacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodigoRecuperacion>> GetCodigoRecuperacion(int id)
        {
          if (_context.CodigoRecuperacions == null)
          {
              return NotFound();
          }
            var codigoRecuperacion = await _context.CodigoRecuperacions.FindAsync(id);

            if (codigoRecuperacion == null)
            {
                return NotFound();
            }

            return codigoRecuperacion;
        }

        // GET: api/RecoveryCodes/ValidateCode
        [HttpGet("ValidateCode")]
        public async Task<ActionResult<CodigoRecuperacion>> ValidateCode(string pEmail, string pCodigo)
        {
            if (_context.CodigoRecuperacions == null)
            {
                return NotFound();
            }
            var recoveryCode = await _context.CodigoRecuperacions.
                SingleOrDefaultAsync(e => e.CorreoElec == pEmail
                && e.Codigo == pCodigo &&
                e.EstadoCod == false);

            if (recoveryCode == null)
            {
                return NotFound();
            }

            return recoveryCode;
        }

        // PUT: api/CodigoRecuperacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodigoRecuperacion(int id, CodigoRecuperacion codigoRecuperacion)
        {
            if (id != codigoRecuperacion.Idcod)
            {
                return BadRequest();
            }

            _context.Entry(codigoRecuperacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodigoRecuperacionExists(id))
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

        // POST: api/CodigoRecuperacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CodigoRecuperacion>> PostCodigoRecuperacion(CodigoRecuperacion codigoRecuperacion)
        {
          if (_context.CodigoRecuperacions == null)
          {
              return Problem("Entity set 'BD_PROY_P6Context.CodigoRecuperacions'  is null.");
          }
            _context.CodigoRecuperacions.Add(codigoRecuperacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CodigoRecuperacionExists(codigoRecuperacion.Idcod))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCodigoRecuperacion", new { id = codigoRecuperacion.Idcod }, codigoRecuperacion);
        }

        // DELETE: api/CodigoRecuperacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodigoRecuperacion(int id)
        {
            if (_context.CodigoRecuperacions == null)
            {
                return NotFound();
            }
            var codigoRecuperacion = await _context.CodigoRecuperacions.FindAsync(id);
            if (codigoRecuperacion == null)
            {
                return NotFound();
            }

            _context.CodigoRecuperacions.Remove(codigoRecuperacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CodigoRecuperacionExists(int id)
        {
            return (_context.CodigoRecuperacions?.Any(e => e.Idcod == id)).GetValueOrDefault();
        }
    }
}
