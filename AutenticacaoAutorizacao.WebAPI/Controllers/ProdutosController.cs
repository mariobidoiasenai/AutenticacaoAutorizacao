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
    public class ProdutosController : ControllerBase
    {
        private readonly AuthContext _context;

        public ProdutosController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
          if (_context.Produtos == null)
          {
              return NotFound();
          }
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("porcategoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>>
            GetProdutosPorCategoria(int categoriaId)
        {
            var listaProdutos = await
                _context
                    .Produtos
                    .Include(p => p.Categoria)
                        .Where(p => p.CategoriaId == categoriaId)
                            .ToListAsync();

            var listaProdutosDto = new List<ProdutoDTO>();

            foreach (var item in listaProdutos)
            {
                var produtoDTO = new ProdutoDTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Descricao = item.Descricao,
                    NomeCategoria = item.Categoria.Nome,
                    UrlImage = item.UrlImage
                };

                listaProdutosDto.Add(produtoDTO);
            }

            return listaProdutosDto;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetProduto(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produto = await _context.Produtos
                .Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);

            ProdutoDTO produtoDTO = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                NomeCategoria = produto.Categoria.Nome,
                UrlImage = produto.UrlImage
            };

            if (produto == null)
            {
                return NotFound();
            }

            return produtoDTO;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
          if (_context.Produtos == null)
          {
              return Problem("Entity set 'AuthContext.Produtos'  is null.");
          }
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
