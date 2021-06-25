using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlePedidos.Data;
using ControlePedidos.Models;
using ControlePedidos.Services;
using ControlePedidos.Models.ViewModels;
using ControlePedidos.Services.Exceptions;

namespace ControlePedidos.Controllers
{
    public class ItemPedidosController : Controller
    {
        private readonly ItemPedidoService _itemPedidoService;
        private readonly ProdutoService _produtoService;

        public ItemPedidosController(ItemPedidoService itemPedidoService, ProdutoService produtoService)
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
        public async Task<IActionResult> Create(ItemPedido itemPedido)
        {
            await _itemPedidoService.InsertAsync(itemPedido);
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemPedidos/Edit
        public async Task<IActionResult> Edit(int? id)
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
            List<Produto> produtos = await _produtoService.FindAllAsync();
            ItemPedidoFormViewModel viewModel = new ItemPedidoFormViewModel { ItemPedido = obj, Produtos = produtos };
            return View(viewModel);
        }

        // POST: ItemPedidos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.Id)
            {
                return NotFound();
            }

            try
            {
                await _itemPedidoService.UpdateAsync(itemPedido);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }

        // GET: ItemPedidos/Delete
        public async Task<IActionResult> Delete(int? id)
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

        // POST: ItemPedidos/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemPedidoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
