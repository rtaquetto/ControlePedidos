using ControlePedidos.Data;
using ControlePedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlePedidos.Services.Exceptions;

namespace ControlePedidos.Services
{
    public class ProdutoService
    {
        private readonly ControlePedidosContext _context;

        public ProdutoService(ControlePedidosContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task InsertAsync(Produto obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produto.Include(obj => obj.Categoria).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto obj)
        {
            bool HasAny = await _context.Produto.AnyAsync(x => x.Id == obj.Id);
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
