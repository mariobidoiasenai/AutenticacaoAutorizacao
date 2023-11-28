using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutenticacaoAutorizacao.Models;
using AutenticacaoAutorizacao.WebAPI.Data;

namespace AutenticacaoAutorizacao.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadorasController : ControllerBase
    {
        private readonly AuthContext _context;

        public TransportadorasController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/Transportadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transportadora>>> GetTransportadoras()
        {
          if (_context.Transportadoras == null)
          {
              return NotFound();
          }
            return await _context.Transportadoras.ToListAsync();
        }

        // GET: api/Transportadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transportadora>> GetTransportadora(int id)
        {
          if (_context.Transportadoras == null)
          {
              return NotFound();
          }
            var transportadora = await _context.Transportadoras.FindAsync(id);

            if (transportadora == null)
            {
                return NotFound();
            }

            return transportadora;
        }

        // PUT: api/Transportadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportadora(int id, Transportadora transportadora)
        {
            if (id != transportadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(transportadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportadoraExists(id))
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

        // POST: api/Transportadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transportadora>> PostTransportadora(Transportadora transportadora)
        {
          if (_context.Transportadoras == null)
          {
              return Problem("Entity set 'AuthContext.Transportadoras'  is null.");
          }
            _context.Transportadoras.Add(transportadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportadora", new { id = transportadora.Id }, transportadora);
        }

        // DELETE: api/Transportadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportadora(int id)
        {
            if (_context.Transportadoras == null)
            {
                return NotFound();
            }
            var transportadora = await _context.Transportadoras.FindAsync(id);
            if (transportadora == null)
            {
                return NotFound();
            }

            _context.Transportadoras.Remove(transportadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransportadoraExists(int id)
        {
            return (_context.Transportadoras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
