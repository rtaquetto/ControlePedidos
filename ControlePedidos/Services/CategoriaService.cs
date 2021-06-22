using ControlePedidos.Data;
using ControlePedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ControlePedidos.Services
{
    public class CategoriaService
    {
        private readonly ControlePedidosContext _context;

        public CategoriaService(ControlePedidosContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> FindAllAsync()
        {
            return await _context.Categoria.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
