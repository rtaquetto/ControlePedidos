using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlePedidos.Models;

namespace ControlePedidos.Data
{
    public class ControlePedidosContext : DbContext
    {
        public ControlePedidosContext (DbContextOptions<ControlePedidosContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .ToTable("tb_categoria")
                .HasKey(c => c.Id);
            modelBuilder.Entity<ItemPedido>()
                .ToTable("tb_item_pedido")
                .HasKey(ip => ip.Id);
            modelBuilder.Entity<Pedido>()
                .ToTable("tb_pedido")
                .HasKey(pe => pe.Id);
            modelBuilder.Entity<Produto>()
                .ToTable("tb_produto")
                .HasKey(pr => pr.Id);
        }
    }
}
