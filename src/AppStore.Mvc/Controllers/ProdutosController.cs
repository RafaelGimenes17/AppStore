using AppStore.Data.Data;
using AppStore.Data.Models;
using AppStore.Mvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Mvc.Controllers
{
    [Authorize]
    [Route("meus-produtos")]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;
        //private readonly IImageUploadService _imageUploadService;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
            //_imageUploadService = imageUploadService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Sucesso = "Listagem bem sucedida!";

            return _context.Produtos != null ?
                View(await _context.Produtos.ToListAsync()) :
                Problem("Entity set AppDbContext.Produtos' is null.");
        }

        [Route("detalhes/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [Route("novo")]
        public IActionResult Create()
        {
            return View();
        }
                
        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,ImagemUpload,Preco,QuantidadeEstoque,CategoriaId,VendedorId")] Produto produto)
        {
            ModelState.Remove("Categoria");
            ModelState.Remove("Vendedor");
            ModelState.Remove("VendedorId");

            if (ModelState.IsValid)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(produto.ImagemUpload, imgPrefixo))
                {
                    return View(produto);
                }

                produto.Imagem = imgPrefixo + produto.ImagemUpload.FileName;
                produto.VendedorId = "b089d169-04c5-4697-9851-54d3660062a4";

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [Route("editar/{id:int}")]
        public async Task<IActionResult> Edit(int id)
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
            return View(produto);
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,ImagemUpload,Preco,QuantidadeEstoque")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            ModelState.Remove("CategoriaId");
            ModelState.Remove("VendedorId");

            var produtoDb = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (ModelState.IsValid)
            {
                try
                {
                    produto.Imagem = produtoDb.Imagem;

                    if (produto.ImagemUpload != null)
                    {
                        var imgPrefixo = Guid.NewGuid() + "_";

                        if (!await UploadArquivo(produto.ImagemUpload, imgPrefixo))
                        {
                            return View(produto);
                        }

                        produto.Imagem = imgPrefixo + produto.ImagemUpload.FileName;
                    }

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["Sucesso"] = "Aluno editado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [Route("excluir/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost("excluir/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
