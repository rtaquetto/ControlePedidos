using ControlePedidos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlePedidos.Models;
using ControlePedidos.Services.Exceptions;

namespace ControlePedidos.Services
{
    public class ItemPedidoService
    {
        private readonly ControlePedidosContext _context;

        public ItemPedidoService(ControlePedidosContext context)
        {
            _context = context;
        }

        public async Task<List<ItemPedido>> FindAllAsync()
        {
            return await _context.ItemPedido.ToListAsync();
        }

        public async Task InsertAsync(ItemPedido obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<ItemPedido> FindByIdAsync(int id)
        {
            return await _context.ItemPedido.Include(obj => obj.Produto).FirstOrDefaultAsync(obj => obj.PedidoId == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ItemPedido.FindAsync(id);
            _context.ItemPedido.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItemPedido obj)
        {
            bool HasAny = await _context.ItemPedido.AnyAsync(x => x.PedidoId == obj.PedidoId);
            if (!HasAny)
            {
                throw new NotFoundException("Item do pedido não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
