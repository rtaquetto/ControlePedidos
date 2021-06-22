using ControlePedidos.Models.ViewModels;
using ControlePedidos.Models;
using ControlePedidos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlePedidos.Services.Exceptions;

namespace ControlePedidos.Controllers
{
    public class ItemPedidoController : Controller
    {
        private readonly ItemPedidoService _itemPedidoService;
        private readonly ProdutoService _produtoService;

        public ItemPedidoController(ItemPedidoService itemPedidoService, ProdutoService produtoService)
        {
            _itemPedidoService = itemPedidoService;
            _produtoService = produtoService;
        }

        // GET: ItemPedidos
        public async Task<IActionResult> Index()
        {
            var list = await _itemPedidoService.FindAllAsync();
            return View(list);
        }

        // GET: ItemPedidos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _itemPedidoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: ItemPedidos/Create
        public async Task<IActionResult> Create()
        {
            var produtos = await _produtoService.FindAllAsync();
            var viewModel = new ItemPedidoFormViewModel { Produtos = produtos };
            return View(viewModel);
        }

        // POST: ItemPedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Codigo,Nome,ValorUnitario")] Produto produto)
        public async Task<IActionResult> Create(ItemPedido itemPedido)
        {
            //if (ModelState.IsValid)
            //{
            await _itemPedidoService.InsertAsync(itemPedido);
            return RedirectToAction(nameof(Index));
            //}
            //return View(produto);
        }

        // GET: ItemPedidos/Edit
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var obj = await _itemPedidoService.FindByIdAsync(id.Value);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    List<Produto> produtos = await _produtoService.FindAllAsync();
        //    ProdutoFormViewModel viewModel = new ItemPedidoFormViewModel { ItemPedido = obj, Produtos = produtos };
        //    return View(viewModel);
        //}

        // POST: ItemPedidos/Edit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ItemPedido itemPedido)
        //{
        //    if (id != itemPedido.Id)
        //    {
        //        return BadRequest();
        //    }

        //    //if (ModelState.IsValid)
        //    //{
        //    try
        //    {
        //        await _itemPedidoService.UpdateAsync(itemPedido);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch (DbConcurrencyException)
        //    {
        //        return BadRequest();
        //    }
        //    //return RedirectToAction(nameof(Index));
        //    //}
        //    //return View(produto);
        //}

        // GET: ItemPedidos/Delete
        //public async Task<IActionResult> Delete(int? id)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var produto = await _context.Produto.FirstOrDefaultAsync(m => m.Codigo == id);
            var obj = await _itemPedidoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: ItemPedidos/Delete
        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            //var produto = await _context.Produto.FindAsync(id);
            await _itemPedidoService.RemoveAsync(id);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ProdutoExists(int id)
        //{
        //    return _produtoService.Any(e => e.Codigo == id);
        //}
    }
}
