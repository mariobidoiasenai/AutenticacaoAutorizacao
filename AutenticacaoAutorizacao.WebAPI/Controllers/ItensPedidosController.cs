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
    public class ItensPedidosController : ControllerBase
    {
        private readonly AuthContext _context;

        public ItensPedidosController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/ItensPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItensPedido()
        {
          if (_context.ItensPedido == null)
          {
              return NotFound();
          }
            return await _context.ItensPedido.ToListAsync();
        }

        // GET: api/ItensPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetItemPedido(int id)
        {
          if (_context.ItensPedido == null)
          {
              return NotFound();
          }
            var itemPedido = await _context.ItensPedido.FindAsync(id);

            if (itemPedido == null)
            {
                return NotFound();
            }

            return itemPedido;
        }

        // PUT: api/ItensPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPedido(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPedidoExists(id))
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

        // POST: api/ItensPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemPedido>> PostItemPedido(ItemPedido itemPedido)
        {
          if (_context.ItensPedido == null)
          {
              return Problem("Entity set 'AuthContext.ItensPedido'  is null.");
          }
            _context.ItensPedido.Add(itemPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPedido", new { id = itemPedido.Id }, itemPedido);
        }

        // DELETE: api/ItensPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido(int id)
        {
            if (_context.ItensPedido == null)
            {
                return NotFound();
            }
            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            _context.ItensPedido.Remove(itemPedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemPedidoExists(int id)
        {
            return (_context.ItensPedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
