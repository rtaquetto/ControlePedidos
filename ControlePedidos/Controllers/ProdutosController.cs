using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ControlePedidos.Models;
using ControlePedidos.Models.ViewModels;
using ControlePedidos.Services;
using ControlePedidos.Services.Exceptions;

namespace ControlePedidos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly CategoriaService _categoriaService;

        public ProdutosController(ProdutoService produtoService, CategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var list = await _produtoService.FindAllAsync();
            return View(list);
        }

        // GET: Produtos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaService.FindAllAsync();
            var viewModel = new ProdutoFormViewModel { Categorias = categorias };
            return View(viewModel);
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
                await _produtoService.InsertAsync(produto);
                return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Categoria> categorias = await _categoriaService.FindAllAsync();
            ProdutoFormViewModel viewModel = new ProdutoFormViewModel { Produto = obj, Categorias = categorias };
            return View(viewModel);
        }

        // POST: Produtos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _produtoService.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

        // GET: Produtos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
