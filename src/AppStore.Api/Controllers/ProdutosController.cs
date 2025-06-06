﻿using AppStore.Data.Data;
using AppStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            if (_context.Produtos == null) return NotFound();

            return await _context.Produtos.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            if (_context.Produtos == null) return NotFound();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (_context.Produtos == null) 
            {
                return Problem("Erro ao criar um produto, contato o suporte!");
            }

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            if (_context.UsingSqlLite)
                produto.Id = _context.Produtos.Max(e => e.Id) + 1;

            _context.Produtos.Add(produto); 
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new {id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutProduto(int id, Produto produto)
        {
            if (id !=  produto.Id) return BadRequest();

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExist(id))
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            if (_context.Produtos == null) return NotFound();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            } 

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ProdutoExist(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
