using System.Collections.Generic;
using System.Threading.Tasks;
using ControlePedidos.Data;
using ControlePedidos.Models;
using ControlePedidos.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ControlePedidos.Services
{
    public class PedidoService
    {
        private readonly ControlePedidosContext _context;

        public PedidoService(ControlePedidosContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindAllAsync()
        {
            return await _context.Pedido.ToListAsync();
        }

        public async Task InsertAsync(Pedido obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> FindByIdAsync(int id)
        {
            return await _context.Pedido.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido obj)
        {
            bool HasAny = await _context.Pedido.AnyAsync(x => x.Id == obj.Id);
            if (!HasAny)
            {
                throw new NotFoundException("Pedido não encontrado");
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
