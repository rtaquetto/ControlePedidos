﻿using ControlePedidos.Models;
using ControlePedidos.Services;
using ControlePedidos.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlePedidos.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var list = await _pedidoService.FindAllAsync();
            return View(list);
        }

        // GET: Pedidos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _pedidoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            await _pedidoService.InsertAsync(pedido);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pedido/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _pedidoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Pedidos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pedidoService.UpdateAsync(pedido);
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

        // GET: Pedidos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = await _pedidoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: Pedidos/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _pedidoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
