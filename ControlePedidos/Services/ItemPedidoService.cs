using ControlePedidos.Data;
using ControlePedidos.Models;
using ControlePedidos.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await _context.ItemPedido
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ItemPedido.FindAsync(id);
            _context.ItemPedido.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItemPedido obj)
        {
            bool HasAny = await _context.ItemPedido.AnyAsync(x => x.Id == obj.Id);
            if (!HasAny)
            {
                throw new NotFoundException("Produto não encontrado");
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
